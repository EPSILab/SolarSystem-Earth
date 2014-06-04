using System;
using System.Text;
using EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract;
using EPSILab.SolarSystem.Earth.DataAccess.Exceptions;
using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;
using System.Collections.Generic;
using System.Linq;
using log4net;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Access to show table
    /// </summary>
    class ShowDAL : IShowDAL
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly IMemberDAL _memberDAL;

        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILog _log;

        #endregion

        #region Constructor

        public ShowDAL(ILog log, IMemberDAL memberDAL)
        {
            _log = log;
            _memberDAL = memberDAL;
        }

        #endregion

        #region IReader1Filter methods

        /// <summary>
        /// Get a show
        /// </summary>
        /// <param name="code">Show code</param>
        /// <returns>Matching code</returns>
        public Show Get(int code)
        {
            Show show = (from salon in SunAccess.Instance.Show
                         where salon.Id == code
                         select salon).FirstOrDefault();

            if (show != null)
            {
                _log.Info(string.Format(LogMessages.GetShowByCode, code));
                return show;
            }

            _log.Error(string.Format("{0} - code '{1}'", LogMessages.ShowNotFound, code));
            throw new ArgumentNullException();
        }

        /// <summary>
        /// Get all shows
        /// </summary>
        /// <returns>List of shows</returns>
        public IEnumerable<Show> Get()
        {
            return Get(0, 0);
        }

        /// <summary>
        /// Get a limited list of shows
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of shows</returns>
        public IEnumerable<Show> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(null, indexFirstElement, numberOfResults);
        }

        /// <summary>
        /// Get all/published/not published shows
        /// </summary>
        /// <param name="published">Determines if show must be published, not published or indifferent</param>
        /// <returns>List of show</returns>
        public IEnumerable<Show> Get(bool? published)
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
        public IEnumerable<Show> Get(bool? published, int indexFirstElement, int numberOfResults)
        {
            StringBuilder logBuilder = new StringBuilder(LogMessages.GetAllShows);

            IEnumerable<Show> results = (from s in SunAccess.Instance.Show
                                         orderby s.Start_DateTime descending, s.End_DateTime descending
                                         select s);

            if (published.HasValue)
            {
                results = (from s in results
                           where s.IsPublished == published
                           select s);
                logBuilder.Append(string.Format(" - {0} : {1}", LogMessages.Published, published));
            }

            results = results.Skip(indexFirstElement);
            logBuilder.Append(string.Format(" - {0} : {1}", LogMessages.IndexFirstElement, indexFirstElement));

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
                logBuilder.Append(string.Format(" - {0} : {1}", LogMessages.NumberOfResults, numberOfResults));
            }

            _log.Info(logBuilder.ToString());

            return results;
        }

        /// <summary>
        /// Returns last show id
        /// </summary>
        /// <returns>Id the last show inserted</returns>
        public int GetLastInsertedId()
        {
            Show show = (from s in SunAccess.Instance.Show
                         orderby s.Id descending
                         select s).FirstOrDefault();

            if (show != null)
            {
                _log.Info(string.Format("{0} : {1}", LogMessages.GetLastShowInsertedID, show.Id));
                return show.Id;
            }

            _log.Error(string.Format("{0} - {1}", LogMessages.GetLastShowInsertedID, LogMessages.ShowNotFound));
            throw new ArgumentNullException();
        }

        #endregion

        #region ISearchable methods

        /// <summary>
        /// Returns all news matching to a keyword
        /// </summary>
        /// <param name="keywords">Search keywords separated by a space</param>
        /// <returns>List of matching news</returns>
        public IEnumerable<Show> Search(string keywords)
        {
            IEnumerable<Show> salons;

            if (!string.IsNullOrWhiteSpace(keywords))
            {
                keywords = keywords.ToLower();

                salons = (from salon in SunAccess.Instance.Show
                          where salon.Name.ToLower().Contains(keywords) ||
                                salon.Place.ToLower().Contains(keywords)
                          orderby salon.Start_DateTime descending
                          orderby salon.End_DateTime descending
                          select salon);

                _log.Info(string.Format(LogMessages.SearchShowsWithKeywords, keywords));
            }
            else
            {
                salons = (from salon in SunAccess.Instance.Show
                          orderby salon.Start_DateTime descending
                          orderby salon.End_DateTime descending
                          select salon);

                _log.Info(LogMessages.SearchShows);
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
        public int Add(Show element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Show> rulesManager = new ShowRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Show.Add(element);
                SunAccess.Instance.SaveChanges();

                _log.Info(string.Format(LogMessages.AddShowByUser, element.Name, username));

                return element.Id;
            }

            _log.Error(string.Format(LogMessages.AccessDeniedToUser, username));
            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a show
        /// </summary>
        /// <param name="element">Edited show</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Show element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Show> rulesManager = new ShowRulesManager();
                rulesManager.Check(element);

                Show s = Get(element.Id);
                s.Name = element.Name;
                s.Start_DateTime = element.Start_DateTime;
                s.End_DateTime = element.End_DateTime;
                s.Place = element.Place;
                s.ImageUrl = element.ImageUrl;
                s.Description = element.Description;
                s.IsPublished = element.IsPublished;

                SunAccess.Instance.SaveChanges();

                _log.Info(string.Format(LogMessages.EditShowByUser, element.Name, username));
            }
            else
            {
                _log.Error(string.Format(LogMessages.AccessDeniedToUser, username));
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
                Show salon = Get(code);
                SunAccess.Instance.Show.Remove(salon);
                SunAccess.Instance.SaveChanges();

                _log.Info(string.Format(LogMessages.DeleteShowByUser, salon.Name, username));
            }
            else
            {
                _log.Error(string.Format(LogMessages.AccessDeniedToUser, username));
                throw new AccessDeniedException(username);
            }
        }

        #endregion
    }
}