using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Exceptions;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager.Managers;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Access to show table
    /// </summary>
    public class SalonDAL : IReader1Filter<Salon, bool?>, ISearchable<Salon>, IManager<Salon>
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly MembreDAL _memberDAL = new MembreDAL();

        #endregion

        #region IReader1Filter methods

        /// <summary>
        /// Get a show
        /// </summary>
        /// <param name="code">Show code</param>
        /// <returns>Matching code</returns>
        public Salon Get(int code)
        {
            return (from salon in SunAccess.Instance.Salon
                    where salon.Code_Salon == code
                    select salon).First();
        }

        /// <summary>
        /// Get all shows
        /// </summary>
        /// <returns>List of shows</returns>
        public IEnumerable<Salon> Get()
        {
            return Get(0, 0);
        }

        /// <summary>
        /// Get a limited list of shows
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of shows</returns>
        public IEnumerable<Salon> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(null, indexFirstElement, numberOfResults);
        }

        /// <summary>
        /// Get all/published/not published shows
        /// </summary>
        /// <param name="published">Determines if show must be published, not published or indifferent</param>
        /// <returns>List of show</returns>
        public IEnumerable<Salon> Get(bool? published)
        {
            return Get(published, 0, 0);
        }

        /// <summary>
        /// Get a limited list of all/published/not published shows
        /// </summary>
        /// <param name="published">Determines if show must be published, not published or indifferent</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of show</returns>
        public IEnumerable<Salon> Get(bool? published, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<Salon> results = (from s in SunAccess.Instance.Salon
                                          orderby s.Date_Heure_Debut descending, s.Date_Heure_Fin descending
                                          select s);

            if (published.HasValue)
            {
                results = (from s in results
                           where s.Publie == published
                           select s);
            }

            results = results.Skip(indexFirstElement);

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
            }

            return results;
        }

        /// <summary>
        /// Returns last show id
        /// </summary>
        /// <returns>Id the last show inserted</returns>
        public int GetLastInsertedId()
        {
            return (from salon in SunAccess.Instance.Salon
                    orderby salon.Code_Salon descending
                    select salon).First().Code_Salon;
        }

        #endregion

        #region ISearchable methods

        /// <summary>
        /// Returns all news matching to a keyword
        /// </summary>
        /// <param name="keywords">Search keywords separated by a space</param>
        /// <returns>List of matching news</returns>
        public IEnumerable<Salon> Search(string keywords)
        {
            IEnumerable<Salon> salons = new List<Salon>();

            if (!string.IsNullOrWhiteSpace(keywords))
            {
                keywords = keywords.ToLower();

                salons = (from salon in SunAccess.Instance.Salon
                          where salon.Nom.ToLower().Contains(keywords) ||
                                salon.Lieu.ToLower().Contains(keywords)
                          orderby salon.Date_Heure_Debut descending
                          orderby salon.Date_Heure_Fin descending
                          select salon);
            }

            return salons;
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a show
        /// </summary>
        /// <param name="element">Show to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New show id</returns>
        public int Add(Salon element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Salon> rulesManager = new SalonRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Salon.AddObject(element);
                SunAccess.Instance.SaveChanges();

                return element.Code_Salon;
            }

            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a show
        /// </summary>
        /// <param name="element">Edited show</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Salon element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Salon> rulesManager = new SalonRulesManager();
                rulesManager.Check(element);

                Salon s = Get(element.Code_Salon);
                s.Nom = element.Nom;
                s.Date_Heure_Debut = element.Date_Heure_Debut;
                s.Date_Heure_Fin = element.Date_Heure_Fin;
                s.Lieu = element.Lieu;
                s.Image = element.Image;
                s.Description = element.Description;

                SunAccess.Instance.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException(username);
            }
        }

        /// <summary>
        /// Delete a show
        /// </summary>
        /// <param name="code">Show id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                Salon salon = Get(code);
                SunAccess.Instance.Salon.DeleteObject(salon);
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