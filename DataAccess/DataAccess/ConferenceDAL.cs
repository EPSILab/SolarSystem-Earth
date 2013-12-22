using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class ConferenceDAL : DALBase, IReaderOneFilter<Conference, Ville>, ISearchable<Conference>, IManager<Conference>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        #endregion

        #region IReaderOneFilter methods

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
            return Get(indexFirstElement, numberOfResults, SortOrder.Descending);
        }

        public IEnumerable<Conference> Get(int indexFirstElement, int numberOfResults, SortOrder order)
        {
            return Get(null, indexFirstElement, numberOfResults, order);
        }

        public IEnumerable<Conference> Get(Ville filter, int indexFirstElement, int numberOfResults, SortOrder order)
        {
            IEnumerable<Conference> results = (from c in Db.Conference
                                               where c.Publiee
                                               orderby c.Date_Heure_Debut
                                               orderby c.Date_Heure_Fin
                                               select c);

            if (filter != null)
            {
                results = (from c in results
                           where c.Code_Ville == filter.Code_Ville
                           select c);
            }

            if (order == SortOrder.Descending)
            {
                results = results.Reverse();
            }

            results = results.Skip(indexFirstElement);

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

        public IEnumerable<Conference> Get(int indexFirstResult, int numberOfResults, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IEnumerable<Conference> results = (from n in Db.Conference
                                                   orderby n.Date_Heure_Debut descending
                                                   orderby n.Date_Heure_Fin descending
                                                   select n);

                results = results.Skip(indexFirstResult);

                if (numberOfResults > 0)
                {
                    results = results.Take(numberOfResults);
                }

                return results;
            }

            return null;
        }

        public Conference Get(int code, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                return Get(code);
            }

            return null;
        }

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