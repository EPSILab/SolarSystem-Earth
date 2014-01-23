using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.Exceptions;
using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Access to conferences table
    /// </summary>
    public class ConferenceDAL : IReader2Filters<Conference, Ville, bool?>, ISearchable<Conference>, IManager<Conference>
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly MembreDAL _memberDAL = new MembreDAL();

        #endregion

        #region IReader2Filters methods

        /// <summary>
        /// Get a conference
        /// </summary>
        /// <param name="code">Conference id</param>
        /// <returns>Matching conferences</returns>
        public Conference Get(int code)
        {
            return (from c in SunAccess.Instance.Conference
                    where c.Code_Conference == code
                    select c).First();
        }

        /// <summary>
        /// Get all the conferences
        /// </summary>
        /// <returns>List of conferences</returns>
        public IEnumerable<Conference> Get()
        {
            return Get(0, 0);
        }

        /// <summary>
        /// Get a limited list of conferences
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<Conference> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(null, null, indexFirstElement, numberOfResults);
        }

        /// <summary>
        /// Get all the conferences published or not
        /// </summary>
        /// <param name="published">Published conferences or not</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<Conference> Get(bool? published)
        {
            return Get(published, 0, 0);
        }

        /// <summary>
        /// Get a limited list of conferences published or not
        /// </summary>
        /// <param name="published">Published conferences or not</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<Conference> Get(bool? published, int indexFirstElement, int numberOfResults)
        {
            return Get(null, published, indexFirstElement, numberOfResults);
        }

        /// <summary>
        /// Get all conferences of a city
        /// </summary>
        /// <param name="ville">City concerned</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<Conference> Get(Ville ville)
        {
            return Get(ville, 0, 0);
        }

        /// <summary>
        /// Get a limited list of conferences of a city
        /// </summary>
        /// <param name="ville">City concerned</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<Conference> Get(Ville ville, int indexFirstElement, int numberOfResults)
        {
            return Get(ville, null, indexFirstElement, numberOfResults);
        }

        /// <summary>
        /// Get all conferences of a city published or not
        /// </summary>
        /// <param name="ville">City concerned</param>
        /// <param name="published">Published conferences or not</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<Conference> Get(Ville ville, bool? published)
        {
            return Get(ville, published, 0, 0);
        }

        /// <summary>
        /// Get all/published/not published conferences. The results can be limited
        /// </summary>
        /// <param name="ville">City concerned</param>
        /// <param name="published">Published conferences or not</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of conferences</returns>
        public IEnumerable<Conference> Get(Ville ville, bool? published, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<Conference> results = (from c in SunAccess.Instance.Conference
                                               orderby c.Date_Heure_Debut descending
                                               orderby c.Date_Heure_Fin descending 
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

            results = results.Skip(indexFirstElement);

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
            }

            return results;
        }

        /// <summary>
        /// Returns last conference id
        /// </summary>
        /// <returns>Id the last inserted conference</returns>
        public int GetLastInsertedId()
        {
            return (from c in SunAccess.Instance.Conference
                    orderby c.Code_Conference descending
                    select c).First().Code_Conference;
        }

        #endregion

        #region ISearchable methods

        /// <summary>
        /// Returns all conferences matching to a keyword
        /// </summary>
        /// <param name="keywords">Search keywords separated by a space</param>
        /// <returns>List of matching conferences</returns>
        public IEnumerable<Conference> Search(string keywords)
        {
            IEnumerable<Conference> conferences = new List<Conference>();

            if (!string.IsNullOrWhiteSpace(keywords))
            {
                keywords = keywords.ToLower();

                conferences = (from c in SunAccess.Instance.Conference
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

        /// <summary>
        /// Create a conference
        /// </summary>
        /// <param name="element">Conference to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New conference id</returns>
        public int Add(Conference element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Conference> rulesManager = new ConferenceRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Conference.AddObject(element);
                SunAccess.Instance.SaveChanges();

                return element.Code_Conference;
            }

            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a conference
        /// </summary>
        /// <param name="element">Edited conference</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Conference element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
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

                SunAccess.Instance.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException(username);
            }
        }

        /// <summary>
        /// Delete a conference
        /// </summary>
        /// <param name="code">Conference id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                Conference conference = Get(code);
                SunAccess.Instance.Conference.DeleteObject(conference);

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