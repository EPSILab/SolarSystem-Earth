using System.Collections.Generic;
using System.Linq;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class ConferenceDAL : DALBase, IReader2Filters<Conference, Ville, bool?>, ISearchable<Conference>, IManager<Conference>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        #endregion

        #region IReader2Filters methods

        public Conference Get(int code)
        {
            return (from c in Db.Conference
                    where c.Code_Conference == code
                    select c).First();
        }

        public IEnumerable<Conference> Get()
        {
            return Get(0, 0);
        }

        public IEnumerable<Conference> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(null, null, indexFirstElement, numberOfResults);
        }

        public IEnumerable<Conference> Get(bool? published)
        {
            return Get(published, 0, 0);
        }

        public IEnumerable<Conference> Get(bool? published, int indexFirstResult, int numberOfResults)
        {
            return Get(null, published, indexFirstResult, numberOfResults);
        }

        public IEnumerable<Conference> Get(Ville ville, bool? published)
        {
            return Get(ville, published, 0, 0);
        }

        public IEnumerable<Conference> Get(Ville ville)
        {
            return Get(ville, 0, 0);
        }

        public IEnumerable<Conference> Get(Ville ville, int indexFirstResult, int numberOfResults)
        {
            return Get(ville, null, indexFirstResult, numberOfResults);
        }

        public IEnumerable<Conference> Get(Ville ville, bool? published, int indexFirstResult, int numberOfResults)
        {
            IEnumerable<Conference> results = (from c in Db.Conference
                                               orderby c.Date_Heure_Debut
                                               orderby c.Date_Heure_Fin
                                               select c);

            if (ville != null)
            {
                results = (from c in results
                           where c.Code_Ville == ville.Code_Ville
                           select c);
            }

            if (published.HasValue)
            {
                results = (from c in results
                           where c.Publiee == published
                           select c);
            }

            results = results.Skip(indexFirstResult);

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
            }

            return results;
        }

        public int GetLastInsertedId()
        {
            return (from c in Db.Conference
                    orderby c.Code_Conference descending
                    select c).First().Code_Conference;
        }

        #endregion

        #region ISearchable methods

        public IEnumerable<Conference> Search(string keywords)
        {
            IEnumerable<Conference> conferences = new List<Conference>();

            if (!string.IsNullOrWhiteSpace(keywords))
            {
                keywords = keywords.ToLower();

                conferences = (from c in Db.Conference
                               where c.Nom.ToLower().Contains(keywords) ||
                                     c.Lieu.ToLower().Contains(keywords) ||
                                     c.Ville.Libelle.ToLower().Contains(keywords)
                               orderby c.Date_Heure_Debut descending
                               select c);
            }

            return conferences;
        }

        #endregion

        #region IManager methods

        public int Add(Conference element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Conference> rulesManager = new ConferenceRulesManager();
                rulesManager.Check(element);

                Db.Conference.AddObject(element);
                Db.SaveChanges();

                return element.Code_Conference;
            }

            return 0;
        }

        public void Edit(Conference element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Conference> rulesManager = new ConferenceRulesManager();
                rulesManager.Check(element);

                Conference c = Get(element.Code_Conference);
                c.Code_Ville = element.Code_Ville;
                c.Nom = element.Nom;
                c.Date_Heure_Debut = element.Date_Heure_Debut;
                c.Date_Heure_Fin = element.Date_Heure_Fin;
                c.Lieu = element.Lieu;
                c.Description = element.Description;
                c.Image = element.Image;
                c.URL = element.URL;
                c.Publiee = element.Publiee;

                Db.SaveChanges();
            }
        }

        public void Delete(int code, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                Conference conference = Get(code);
                Db.Conference.DeleteObject(conference);

                Db.SaveChanges();
            }
        }

        #endregion
    }
}