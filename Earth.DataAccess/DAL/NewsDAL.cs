using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract;
using EPSILab.SolarSystem.Earth.DataAccess.Exceptions;
using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;
using log4net;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Access to news table
    /// </summary>
    class NewsDAL : INewsDAL
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

        public NewsDAL(ILog log, IMemberDAL memberDAL)
        {
            _log = log;
            _memberDAL = memberDAL;
        }

        #endregion

        #region IReader2Filters methods

        /// <summary>
        /// Get a news
        /// </summary>
        /// <param name="code">News id</param>
        /// <returns>Matching news</returns>
        public News Get(int code)
        {
            News news = (from n in SunAccess.Instance.News
                         where n.Id == code
                         select n).FirstOrDefault();

            if (news != null)
            {
                _log.Info(string.Format(LogMessages.GetNewsByCode, code));
                return news;
            }

            _log.Error(string.Format("{0} - code '{1}'", LogMessages.NewsNotFound, code));
            throw new ArgumentNullException();
        }

        /// <summary>
        /// Get all news
        /// </summary>
        /// <returns>List of news</returns>
        public IEnumerable<News> Get()
        {
            return Get(0, 0);
        }

        /// <summary>
        /// Get a limited list of news
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>Matching list of news</returns>
        public IEnumerable<News> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(null, null, indexFirstElement, numberOfResults);
        }

        /// <summary>
        /// Get a member's news
        /// </summary>
        /// <param name="author">Author</param>
        /// <returns>Matching news</returns>
        public IEnumerable<News> Get(Member author)
        {
            return Get(author, 0, 0);
        }

        /// <summary>
        /// Get a limited list of a member's news
        /// </summary>
        /// <param name="author">Author</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>Matching list of news</returns>
        public IEnumerable<News> Get(Member author, int indexFirstElement, int numberOfResults)
        {
            return Get(author, null, indexFirstElement, numberOfResults);
        }

        /// <summary>
        /// Get all/published/not published news
        /// </summary>
        /// <param name="published">Determines if news must be published, not published or indifferent</param>
        /// <returns>List of news</returns>
        public IEnumerable<News> Get(bool? published)
        {
            return Get(null, published);
        }

        /// <summary>
        /// Get a limited list of all/published/not published news
        /// </summary>
        /// <param name="published">Determines if news must be published, not published or indifferent</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of news</returns>
        public IEnumerable<News> Get(bool? published, int indexFirstElement, int numberOfResults)
        {
            return Get(null, published, indexFirstElement, numberOfResults);
        }

        /// <summary>
        /// Get a all/published/not published member's news
        /// </summary>
        /// <param name="author">Author</param>
        /// <param name="published">Determines if news must be published, not published or indifferent</param>
        /// <returns>List of news</returns>
        public IEnumerable<News> Get(Member author, bool? published)
        {
            return Get(author, published, 0, 0);
        }

        /// <summary>
        /// Get a limited list of a member's all/published/not published news
        /// </summary>
        /// <param name="author">Author</param>
        /// <param name="published">Determines if news must be published, not published or indifferent</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of news</returns>
        public IEnumerable<News> Get(Member author, bool? published, int indexFirstElement, int numberOfResults)
        {
            StringBuilder logBuilder = new StringBuilder(LogMessages.GetAllNews);

            IEnumerable<News> results = (from n in SunAccess.Instance.News
                                         orderby n.DateTime descending
                                         select n);

            if (author != null)
            {
                results = (from n in results
                           where n.Id == author.Id
                           select n);
                logBuilder.Append(string.Format(" - {0} : {1}", LogMessages.Author, author.Username));
            }

            if (published.HasValue)
            {
                results = (from n in results
                           where n.IsPublished == published
                           select n);
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
        /// Returns last news id
        /// </summary>
        /// <returns>Id the last inserted news</returns>
        public int GetLastInsertedId()
        {
            News news = (from n in SunAccess.Instance.News
                         orderby n.Id descending
                         select n).FirstOrDefault();

            if (news != null)
            {
                _log.Info(string.Format("{0} : {1}", LogMessages.GetLastNewsInsertedID, news.Id));
                return news.Id;
            }

            _log.Error(string.Format("{0} - {1}", LogMessages.GetLastNewsInsertedID, LogMessages.NewsNotFound));
            throw new ArgumentNullException();
        }

        #endregion

        #region ISearchable methods

        /// <summary>
        /// Returns all news matching to a keyword
        /// </summary>
        /// <param name="keywords">Search keywords separated by a space</param>
        /// <returns>List of matching news</returns>
        public IEnumerable<News> Search(string keywords)
        {
            IEnumerable<News> news;

            if (!string.IsNullOrWhiteSpace(keywords))
            {
                keywords = keywords.ToLower();

                news = (from n in SunAccess.Instance.News
                        where n.Title.ToLower().Contains(keywords) ||
                              n.Keywords.ToLower().Contains(keywords)
                        orderby n.DateTime descending
                        select n);

                _log.Info(string.Format(LogMessages.SearchNewsWithKeywords, keywords));
            }
            else
            {
                news = (from n in SunAccess.Instance.News
                        orderby n.DateTime descending
                        select n);

                _log.Info(LogMessages.SearchNews);
            }

            return news;
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a news
        /// </summary>
        /// <param name="element">News to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New news id</returns>
        public int Add(News element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<News> rulesManager = new NewsRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.News.Add(element);
                SunAccess.Instance.SaveChanges();

                _log.Info(string.Format(LogMessages.AddNewsByUser, element.Title, username));

                return element.Id;
            }

            _log.Error(string.Format(LogMessages.AccessDeniedToUser, username));
            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a news
        /// </summary>
        /// <param name="element">Edited news</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(News element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<News> rulesManager = new NewsRulesManager();
                rulesManager.Check(element);

                News n = Get(element.Id);
                n.Id = element.Id;
                n.Title = element.Title;
                n.ShortText = element.ShortText;
                n.Text = element.Text;
                n.DateTime = element.DateTime;
                n.ImageUrl = element.ImageUrl;
                n.Keywords = element.Keywords;
                n.IsPublished = element.IsPublished;

                SunAccess.Instance.SaveChanges();

                _log.Info(string.Format(LogMessages.EditNewsByUser, element.Title, username));
            }
            else
            {
                _log.Error(string.Format(LogMessages.AccessDeniedToUser, username));
                throw new AccessDeniedException(username);
            }
        }

        /// <summary>
        /// Delete a news
        /// </summary>
        /// <param name="code">News id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                News news = Get(code);
                SunAccess.Instance.News.Remove(news);

                SunAccess.Instance.SaveChanges();

                _log.Info(string.Format(LogMessages.DeleteNewsByUser, news.Title, username));
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