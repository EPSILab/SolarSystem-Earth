using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.Common.Utils;
using SolarSystem.Earth.DataAccess.Exceptions;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager.Managers;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Access to members table
    /// </summary>
    public class MembreDAL : IMembreReader<Membre, Ville>, ISearchable<Membre>, ILogin<Membre, RecupMotDePasse>, IManager<Membre>
    {
        #region Attributes

        /// <summary>
        /// Access to role table
        /// </summary>
        private readonly IReader<Role> _roleDAL = new RoleDAL();

        #endregion

        #region IMembreReader methods

        /// <summary>
        /// Get a member
        /// </summary>
        /// <param name="code">Member id</param>
        /// <returns>Matching member</returns>
        public Membre Get(int code)
        {
            Membre membre = (from m in SunAccess.Instance.Membre
                             where m.Code_Membre == code
                             select m).First();

            return membre;
        }

        /// <summary>
        /// Get all members
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<Membre> Get()
        {
            return Get(null, null, null, null);
        }

        /// <summary>
        /// Get all bureau members
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<Membre> GetBureau()
        {
            return GetBureau(null);
        }

        /// <summary>
        /// Get bureau members of a city
        /// </summary>
        /// <param name="ville">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<Membre> GetBureau(Ville ville)
        {
            Role role = _roleDAL.Get(2);
            return Get(ville, role, true, false);
        }

        /// <summary>
        /// Get actives members of a city
        /// </summary>
        /// <param name="ville">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<Membre> GetMembresActives(Ville ville)
        {
            Role role = _roleDAL.Get(1);
            return Get(ville, role, true, false);
        }

        /// <summary>
        /// Get bureau and actives members
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<Membre> GetBureauAndMembresActives()
        {
            return GetBureauAndMembresActives(null);
        }

        /// <summary>
        /// Get bureau and actives members of a city
        /// </summary>
        /// <param name="ville">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<Membre> GetBureauAndMembresActives(Ville ville)
        {
            return Get(ville, null, true, false);
        }

        /// <summary>
        /// Get all alumnis
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<Membre> GetAlumnis()
        {
            return GetAlumnis(null);
        }

        /// <summary>
        /// Get alumnis of a city
        /// </summary>
        /// <param name="ville">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<Membre> GetAlumnis(Ville ville)
        {
            return Get(ville, null, true, true);
        }

        /// <summary>
        /// Get members waiting for an admin validation
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<Membre> GetWaitingForValidation()
        {
            Role role = _roleDAL.Get(0);
            return Get(null, role, false, false);
        }

        /// <summary>
        /// A private method called by all others public Get methods
        /// </summary>
        /// <param name="ville">Concerned city</param>
        /// <param name="role">Role of members</param>
        /// <param name="activesOnly">Actives/Not actives/All</param>
        /// <param name="alumnisOnly">Alumnis/Not alumnis/All</param>
        /// <returns></returns>
        private IEnumerable<Membre> Get(Ville ville, Role role, bool? activesOnly, bool? alumnisOnly)
        {
            IEnumerable<Membre> results = (from m in SunAccess.Instance.Membre
                                           orderby m.Nom, m.Prenom
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

        /// <summary>
        /// Returns last member id
        /// </summary>
        /// <returns>Id the last inserted member</returns>
        public int GetLastInsertedId()
        {
            return (from membre in SunAccess.Instance.Membre
                    orderby membre.Code_Membre descending
                    select membre).First().Code_Membre;
        }

        #endregion

        #region ILogin methods

        /// <summary>
        /// Connect a user and returns all members informations 
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Crypted password</param>
        /// <returns></returns>
        public Membre Login(string username, string password)
        {
            Membre result = (from membre in SunAccess.Instance.Membre
                             where membre.Pseudo == username && membre.Mot_de_passe == password
                             select membre).First();

            DateTime limit = DateTime.Now.AddDays(-2);

            // Clean all old lost password requests
            IEnumerable<RecupMotDePasse> requests = (from r in SunAccess.Instance.RecupMotDePasse
                                                     where r.Date < limit
                                                     select r);

            foreach (var request in requests)
            {
                SunAccess.Instance.RecupMotDePasse.DeleteObject(request);
            }

            SunAccess.Instance.SaveChanges();

            return result;
        }

        /// <summary>
        /// Change a password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="oldPassword">Old password crypted</param>
        /// <param name="newPassword">New password crypted</param>
        public void ChangePassword(string username, string oldPassword, string newPassword)
        {
            Membre result = (from membre in SunAccess.Instance.Membre
                             where membre.Pseudo == username && membre.Mot_de_passe == oldPassword
                             select membre).First();

            result.Mot_de_passe = newPassword;

            SunAccess.Instance.SaveChanges();
        }

        /// <summary>
        /// Determines if an user exists in the database
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Crypted password</param>
        /// <returns>A boolean which determines if the user exists</returns>
        public bool Exists(string username, string password)
        {
            bool exists = (from membre in SunAccess.Instance.Membre
                           where membre.Pseudo == username && membre.Mot_de_passe == password
                           select membre).Any();

            return exists;
        }

        /// <summary>
        /// Determines if an user exists in the database
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>A boolean which determines if the user exists</returns>
        public bool Exists(string username)
        {
            bool exists = (from membre in SunAccess.Instance.Membre
                           where membre.Pseudo == username
                           select membre).Any();

            return exists;
        }

        /// <summary>
        /// Register a new user, but inactive
        /// </summary>
        /// <param name="membre">Member to create</param>
        /// <returns>New member id</returns>
        public int Register(Membre membre)
        {
            membre.Code_Role = 0;
            membre.URL = string.Format("{0}-{1}", membre.Prenom, membre.Nom);

            IRulesManager<Membre> rulesManager = new MembreRulesManager();
            rulesManager.Check(membre);

            SunAccess.Instance.Membre.AddObject(membre);
            SunAccess.Instance.SaveChanges();

            return membre.Code_Membre;
        }

        /// <summary>
        /// Create a request to recover password
        /// </summary>
        /// <param name="username">Username for control</param>
        /// <param name="email">Email for control</param>
        /// <returns>Password recover informations</returns>
        public RecupMotDePasse RequestLostPassword(string username, string email)
        {
            Membre result = (from membre in SunAccess.Instance.Membre
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

                SunAccess.Instance.RecupMotDePasse.AddObject(recupMotDePasse);
                SunAccess.Instance.SaveChanges();

                recupMotDePasse.Membre = null;

                return recupMotDePasse;
            }

            throw new UserNotExistsException();
        }

        /// <summary>
        /// Set a new password after a lost password request
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="newPassword">Crypted new password</param>
        /// <param name="key">The generated key for lost password request</param>
        public void SetNewPasswordAfterLost(string username, string newPassword, string key)
        {
            RecupMotDePasse recupMotDePasse = (from r in SunAccess.Instance.RecupMotDePasse
                                               where r.Membre.Pseudo == username && r.Cle == key
                                               select r).FirstOrDefault();

            if (recupMotDePasse == null)
            {
                throw new LostPasswordRequestNotFoundException();
            }

            Membre membre = (from m in SunAccess.Instance.Membre
                             where m.Code_Membre == recupMotDePasse.Code_Membre
                             select m).First();

            if (recupMotDePasse.Date.AddDays(2) <= DateTime.Now)
            {
                membre.Mot_de_passe = newPassword;
                SunAccess.Instance.RecupMotDePasse.DeleteObject(recupMotDePasse);
                SunAccess.Instance.SaveChanges();
            }
            else
            {
                SunAccess.Instance.RecupMotDePasse.DeleteObject(recupMotDePasse);
                SunAccess.Instance.SaveChanges();

                throw new LostPasswordTimeElapsedException();
            }

        }

        #endregion

        #region ISearchable methods

        /// <summary>
        /// Get members corresponding to a keywords
        /// </summary>
        /// <param name="keywords">Search keywords separated by a space</param>
        /// <returns></returns>
        public IEnumerable<Membre> Search(string keywords)
        {
            IEnumerable<Membre> membres = new List<Membre>();

            if (!string.IsNullOrWhiteSpace(keywords))
            {
                keywords = keywords.ToLower();

                membres = (from membre in SunAccess.Instance.Membre
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

        /// <summary>
        /// Create a member
        /// </summary>
        /// <param name="element">Member to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New conference id</returns>
        public int Add(Membre element, string username, string password)
        {
            if (Exists(username, password))
            {
                IRulesManager<Membre> rulesManager = new MembreRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Membre.AddObject(element);
                SunAccess.Instance.SaveChanges();

                return element.Code_Membre;
            }

            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a member
        /// </summary>
        /// <param name="element">Member conference</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
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

                SunAccess.Instance.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException(username);
            }
        }

        /// <summary>
        /// Delete a member
        /// </summary>
        /// <param name="code">Member id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            if (Exists(username, password))
            {
                Membre membre = Get(code);
                SunAccess.Instance.Membre.DeleteObject(membre);

                SunAccess.Instance.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException(username);
            }
        }

        #endregion
    }
}