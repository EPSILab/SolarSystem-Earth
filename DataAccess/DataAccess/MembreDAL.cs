using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class MembreDAL : DALBase, IReaderTwoFilters<Membre, Ville, Role>, ISearchable<Membre>, ILogin, IManager<Membre>
    {
        #region IReaderTwoFilters methods

        public Membre Get(int code)
        {
            Membre membre = (from m in Db.Membre
                             where m.Code_Membre == code
                             select m).First();

            return membre;
        }

        public IEnumerable<Membre> Get()
        {
            return Get(0, 0);
        }

        public IEnumerable<Membre> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(indexFirstElement, numberOfResults, SortOrder.Ascending);
        }

        public IEnumerable<Membre> Get(int indexFirstElement, int numberOfResults, SortOrder order)
        {
            return Get(null, null, indexFirstElement, numberOfResults, order);
        }

        public IEnumerable<Membre> Get(Ville ville, Role role, int indexFirstResult, int numberOfResults, SortOrder order)
        {
            IEnumerable<Membre> results = (from m in Db.Membre
                                           select m);

            if (ville != null)
            {
                results = (from m in results
                           where m.Ville.Code_Ville == ville.Code_Ville
                           select m);
            }

            if (role != null)
            {
                results = (from m in results
                           where m.Role.Code_Role == role.Code_Role
                           select m);
            }
            else
            {
                results = (from m in results
                           where m.Role.Code_Role > 0 && m.Role.Code_Role < 4
                           select m);
            }

            if (order == SortOrder.Descending)
            {
                results = (from m in results
                           orderby m.Nom, m.Prenom, m.Ville.Libelle, m.Role.Code_Role descending
                           select m);
            }
            else
            {
                results = (from m in results
                           orderby m.Nom descending, m.Prenom, m.Ville.Libelle, m.Role.Code_Role descending
                           select m);
            }

            results = results.Skip(indexFirstResult);

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
            }

            return results;
        }

        #endregion

        #region ISearch methods

        public int GetLastInsertedId()
        {
            return (from membre in Db.Membre
                    orderby membre.Code_Membre descending
                    select membre).First().Code_Membre;
        }

        #endregion

        #region IManager methods

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

        public int Login(string username, string password)
        {
            Membre results = (from membre in Db.Membre
                              where membre.Pseudo == username && membre.Mot_de_passe == password
                              select membre).First();

            return results != null ? results.Code_Membre : 0;
        }

        public bool Exists(string username, string password)
        {
            bool exists = (from membre in Db.Membre
                           where membre.Pseudo == username && membre.Mot_de_passe == password
                           select membre).Any();

            return exists;
        }

        public IEnumerable<Membre> Get(int indexFirstResult, int numberOfResults, string username, string password)
        {
            if (Exists(username, password))
            {
                IEnumerable<Membre> results = (from m in Db.Membre
                                               select m);

                return results;
            }

            return null;
        }

        public Membre Get(int code, string username, string password)
        {
            if (Exists(username, password))
            {
                return Get(code);
            }

            return null;
        }

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

            return 0;
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
        }

        public void Delete(int code, string username, string password)
        {
            if (Exists(username, password))
            {
                Membre membre = Get(code);
                Db.Membre.DeleteObject(membre);

                Db.SaveChanges();
            }
        }

        #endregion
    }
}