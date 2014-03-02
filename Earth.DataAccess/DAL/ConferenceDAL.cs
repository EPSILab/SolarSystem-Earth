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
    public class ConferenceDAL : IReader2Filters<Conference, Campus, bool?>, ISearchable<Conference>, IManager<Conference>
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly MemberDAL _memberDAL = new MemberDAL();

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
                    where c.Id == code
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
        /// <param name="campus">City concerned</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<Conference> Get(Campus campus)
        {
            return Get(campus, 0, 0);
        }

        /// <summary>
        /// Get a limited list of conferences of a city
        /// </summary>
        /// <param name="campus">City concerned</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<Conference> Get(Campus campus, int indexFirstElement, int numberOfResults)
        {
            return Get(campus, null, indexFirstElement, numberOfResults);
        }

        /// <summary>
        /// Get all conferences of a city published or not
        /// </summary>
        /// <param name="campus">City concerned</param>
        /// <param name="published">Published conferences or not</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<Conference> Get(Campus campus, bool? published)
        {
            return Get(campus, published, 0, 0);
        }

        /// <summary>
        /// Get all/published/not published conferences. The results can be limited
        /// </summary>
        /// <param name="campus">City concerned</param>
        /// <param name="published">Published conferences or not</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of conferences</returns>
        public IEnumerable<Conference> Get(Campus campus, bool? published, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<Conference> results = (from c in SunAccess.Instance.Conference
                                               orderby c.Start_DateTime descending
                                               orderby c.End_DateTime descending
                                               select c);

            if (campus != null)
                results = (from c in results
                           where c.Id == campus.Id
                           select c);

            if (published.HasValue)
                results = (from c in results
                           where c.IsPublished == published
                           select c);

            results = results.Skip(indexFirstElement);

            if (numberOfResults > 0)
                results = results.Take(numberOfResults);

            return results;
        }

        /// <summary>
        /// Returns last conference id
        /// </summary>
        /// <returns>Id the last inserted conference</returns>
        public int GetLastInsertedId()
        {
            return (from c in SunAccess.Instance.Conference
                    orderby c.Id descending
                    select c).First().Id;
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
                               where c.Name.ToLower().Contains(keywords) ||
                                     c.Place.ToLower().Contains(keywords) ||
                                     c.Campus.Place.ToLower().Contains(keywords)
                               orderby c.Start_DateTime descending
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

                SunAccess.Instance.Conference.Add(element);
                SunAccess.Instance.SaveChanges();

                return element.Id;
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

                Conference c = Get(element.Id);
                c.Id = element.Id;
                c.Name = element.Name;
                c.Start_DateTime = element.Start_DateTime;
                c.End_DateTime = element.End_DateTime;
                c.Place = element.Place;
                c.Description = element.Description;
                c.ImageUrl = element.ImageUrl;
                c.Url = element.Url;
                c.IsPublished = element.IsPublished;

                SunAccess.Instance.SaveChanges();
            }
            else
                throw new AccessDeniedException(username);
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
                SunAccess.Instance.Conference.Remove(conference);

                SunAccess.Instance.SaveChanges();
            }
            else
                throw new AccessDeniedException(username);
        }

        #endregion
    }
}