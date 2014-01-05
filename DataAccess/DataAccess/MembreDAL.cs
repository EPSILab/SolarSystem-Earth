using System;
using System.Collections.Generic;
using System.Linq;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.Common.Utils;
using SolarSystem.Earth.DataAccess.Exceptions;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class MembreDAL : DALBase, IMembreReader<Membre, Ville>, ISearchable<Membre>, ILogin<Membre, RecupMotDePasse>, IManager<Membre>
    {
        #region Attributes

        private IReader<Role> _roleDAL = new RoleDAL();

        #endregion

        #region IMembreReader methods

        public Membre Get(int code)
        {
            Membre membre = (from m in Db.Membre
                             where m.Code_Membre == code
                             select m).First();

            return membre;
        }

        public IEnumerable<Membre> Get()
        {
            return Get(null, null, null, null);
        }

        public IEnumerable<Membre> GetBureau()
        {
            return GetBureau(null);
        }

        public IEnumerable<Membre> GetBureau(Ville ville)
        {
            Role role = _roleDAL.Get(2);
            return Get(ville, role, true, false);
        }

        public IEnumerable<Membre> GetMembresActives(Ville ville)
        {
            Role role = _roleDAL.Get(1);
            return Get(ville, role, true, false);
        }

        public IEnumerable<Membre> GetBureauAndMembresActives()
        {
            return GetBureauAndMembresActives(null);
        }

        public IEnumerable<Membre> GetBureauAndMembresActives(Ville ville)
        {
            return Get(ville, null, true, false);
        }

        public IEnumerable<Membre> GetAlumnis()
        {
            return GetAlumnis(null);
        }

        public IEnumerable<Membre> GetAlumnis(Ville ville)
        {
            return Get(ville, null, true, true);
        }

        public IEnumerable<Membre> GetWaitingForValidation()
        {
            Role role = _roleDAL.Get(0);
            return Get(null, role, false, false);
        }

        private IEnumerable<Membre> Get(Ville ville, Role role, bool? activesOnly, bool? alumnisOnly)
        {
            IEnumerable<Membre> results = (from m in Db.Membre
                                           orderby m.Nom
                                           orderby m.Prenom
                                           select m);

            if (ville != null)
            {
                results = (from m in results
                           where m.Code_Ville == ville.Code_Ville
                           select m);
            }

            if (role != null)
            {
                results = (from m in results
                           where m.Code_Role == role.Code_Role
                           select m);
            }

            if (activesOnly.HasValue)
            {
                if (activesOnly.Value)
                {
                    results = (from m in results
                               where m.Actif
                               select m);
                }
                else
                {
                    results = (from m in results
                               where !m.Actif
                               select m);
                }
            }

            if (alumnisOnly.HasValue)
            {
                if (alumnisOnly.Value)
                {
                    results = (from m in results
                               where !m.Classe.Encore_Presente
                               select m);
                }
                else
                {
                    results = (from m in results
                               where m.Classe.Encore_Presente
                               select m);
                }
            }

            return results;
        }

        public int GetLastInsertedId()
        {
            return (from membre in Db.Membre
                    orderby membre.Code_Membre descending
                    select membre).First().Code_Membre;
        }

        #endregion

        #region ILogin methods

        public Membre Login(string username, string password)
        {
            Membre result = (from membre in Db.Membre
                             where membre.Pseudo == username && membre.Mot_de_passe == password
                             select membre).First();

            DateTime limit = DateTime.Now.AddDays(-2);

            // Clean all old lost password requests
            IEnumerable<RecupMotDePasse> requests = (from r in Db.RecupMotDePasse
                                                     where r.Date < limit
                                                     select r);

            foreach (var request in requests)
            {
                Db.RecupMotDePasse.DeleteObject(request);
            }

            Db.SaveChanges();

            return result;
        }

        public void ChangePassword(string username, string oldPassword, string newPassword)
        {
            Membre result = (from membre in Db.Membre
                             where membre.Pseudo == username && membre.Mot_de_passe == oldPassword
                             select membre).First();

            result.Mot_de_passe = newPassword;

            Db.SaveChanges();
        }

        public bool Exists(string username, string password)
        {
            bool exists = (from membre in Db.Membre
                           where membre.Pseudo == username && membre.Mot_de_passe == password
                           select membre).Any();

            return exists;
        }

        public bool Exists(string username)
        {
            bool exists = (from membre in Db.Membre
                           where membre.Pseudo == username
                           select membre).Any();

            return exists;
        }

        public int Register(Membre membre)
        {
            membre.Code_Role = 0;
            membre.URL = string.Format("{0}-{1}", membre.Prenom, membre.Nom);

            IRulesManager<Membre> rulesManager = new MembreRulesManager();
            rulesManager.Check(membre);

            Db.Membre.AddObject(membre);
            Db.SaveChanges();

            return membre.Code_Membre;
        }

        public RecupMotDePasse RequestLostPassword(string username, string email)
        {
            Membre result = (from membre in Db.Membre
                             where membre.Pseudo == username
                             select membre).FirstOrDefault();

            if (result != null)
            {

                RecupMotDePasse recupMotDePasse = new RecupMotDePasse
                {
                    Code_Membre = result.Code_Membre,
                    Date = DateTime.Now,
                    Cle = MD5HasherUtil.Hash(string.Format("{0}{1}", result.Pseudo, DateTime.Now))
                };

                Db.RecupMotDePasse.AddObject(recupMotDePasse);

                return recupMotDePasse;
            }

            throw new UserNotExistsException();
        }

        public void SetNewPasswordAfterLost(string username, string newPassword, string key)
        {
            RecupMotDePasse recupMotDePasse = (from r in Db.RecupMotDePasse
                                               where r.Membre.Pseudo == username && r.Cle == key
                                               select r).FirstOrDefault();

            if (recupMotDePasse == null)
            {
                throw new LostPasswordRequestNotFoundException();
            }

            Membre membre = (from m in Db.Membre
                             where m.Code_Membre == recupMotDePasse.Code_Membre
                             select m).First();

            if (recupMotDePasse.Date.AddDays(2) <= DateTime.Now)
            {
                membre.Mot_de_passe = newPassword;
                Db.RecupMotDePasse.DeleteObject(recupMotDePasse);
                Db.SaveChanges();
            }
            else
            {
                Db.RecupMotDePasse.DeleteObject(recupMotDePasse);
                Db.SaveChanges();

                throw new LostPasswordTimeElapsedException();
            }

        }

        #endregion

        #region ISearchable methods

        public IEnumerable<Membre> Search(string keywords)
        {
            IEnumerable<Membre> membres = new List<Membre>();

            if (!string.IsNullOrWhiteSpace(keywords))
            {
                keywords = keywords.ToLower();

                membres = (from membre in Db.Membre
                           where membre.Nom.ToLower().Contains(keywords)
                                 || membre.Prenom.ToLower().Contains(keywords)
                                 || membre.Ville.Libelle.ToLower().Contains(keywords)
                           orderby membre.Nom
                           orderby membre.Prenom
                           select membre);
            }

            return membres;
        }

        #endregion

        #region IManager methods

        public int Add(Membre element, string username, string password)
        {
            if (Exists(username, password))
            {
                IRulesManager<Membre> rulesManager = new MembreRulesManager();
                rulesManager.Check(element);

                Db.Membre.AddObject(element);
                Db.SaveChanges();

                return element.Code_Membre;
            }
            throw new AccessDeniedException();
        }

        public void Edit(Membre element, string username, string password)
        {
            if (Exists(username, password))
            {
                IRulesManager<Membre> rulesManager = new MembreRulesManager();
                rulesManager.Check(element);

                Membre m = Get(element.Code_Membre);

                m.Code_Classe = element.Code_Classe;
                m.Code_Role = element.Code_Role;
                m.Code_Ville = element.Code_Ville;
                m.Nom = element.Nom;
                m.Prenom = element.Prenom;
                m.Pseudo = element.Pseudo;
                m.Mot_de_passe = element.Mot_de_passe;
                m.Email_perso = element.Email_perso;
                m.Email_EPSI = element.Email_EPSI;
                m.Telephone_mobile = element.Telephone_mobile;
                m.Ville_origine = element.Ville_origine;
                m.Site_web = element.Site_web;
                m.URL_Facebook = element.URL_Facebook;
                m.URL_Twitter = element.URL_Twitter;
                m.URL_Viadeo = element.URL_Viadeo;
                m.URL_LinkedIn = element.URL_LinkedIn;
                m.Statut = element.Statut;
                m.Presentation = element.Presentation;
                m.Image = element.Image;
                m.URL = element.URL;

                Db.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException();
            }
        }

        public void Delete(int code, string username, string password)
        {
            if (Exists(username, password))
            {
                Membre membre = Get(code);
                Db.Membre.DeleteObject(membre);

                Db.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException();
            }
        }

        #endregion
    }
}