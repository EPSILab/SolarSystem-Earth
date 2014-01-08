using System.Collections.Generic;
using System.Linq;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Exceptions;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager.Managers;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Access to news table
    /// </summary>
    public class NewsDAL : IReader2Filters<News, Membre, bool?>, ISearchable<News>, IManager<News>
    {
        #region Attributes

        private readonly MembreDAL _memberDAL = new MembreDAL();

        #endregion

        #region IReader2Filters methods

        /// <summary>
        /// Get a news
        /// </summary>
        /// <param name="code">News id</param>
        /// <returns>Matching news</returns>
        public News Get(int code)
        {
            return (from news in SunAccess.Instance.News
                    where news.Code_News == code
                    select news).First();
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
        public IEnumerable<News> Get(Membre author)
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
        public IEnumerable<News> Get(Membre author, int indexFirstElement, int numberOfResults)
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
        public IEnumerable<News> Get(Membre author, bool? published)
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
        public IEnumerable<News> Get(Membre author, bool? published, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<News> results = (from n in SunAccess.Instance.News
                                         orderby n.Date_Heure descending 
                                         select n);

            if (author != null)
            {
                results = (from n in results
                           where n.Code_Membre == author.Code_Membre
                           select n);
            }

            if (published.HasValue)
            {
                results = (from n in results
                           where n.Publiee == published
                           select n);
            }

            results = results.Skip(indexFirstElement);

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
            }

            return results;
        }

        /// <summary>
        /// Returns last news id
        /// </summary>
        /// <returns>Id the last inserted news</returns>
        public int GetLastInsertedId()
        {
            return (from news in SunAccess.Instance.News
                    orderby news.Code_News descending
                    select news).First().Code_News;
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
            IEnumerable<News> news = new List<News>();

            if (!string.IsNullOrWhiteSpace(keywords))
            {
                keywords = keywords.ToLower();

                news = (from n in SunAccess.Instance.News
                        where n.Titre.ToLower().Contains(keywords) ||
                              n.Mots_Cles.ToLower().Contains(keywords)
                        orderby n.Date_Heure descending
                        select n);
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

                SunAccess.Instance.News.AddObject(element);
                SunAccess.Instance.SaveChanges();

                return element.Code_News;
            }

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

                News n = Get(element.Code_News);
                n.Code_Membre = element.Code_Membre;
                n.Titre = element.Titre;
                n.Texte_Court = element.Texte_Court;
                n.Texte_Long = element.Texte_Long;
                n.Date_Heure = element.Date_Heure;
                n.Image = element.Image;
                n.Mots_Cles = element.Mots_Cles;

                SunAccess.Instance.SaveChanges();
            }
            else
            {
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
                SunAccess.Instance.News.DeleteObject(news);

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