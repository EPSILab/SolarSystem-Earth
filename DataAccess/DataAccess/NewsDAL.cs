using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Exceptions;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class NewsDAL : DALBase, IReaderSort<News>, ISearchable<News>, IManager<News>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        #endregion

        #region IReaderSort methods

        public News Get(int code)
        {
            return (from news in Db.News
                    where news.Code_News == code
                    select news).First();
        }

        public IEnumerable<News> Get()
        {
            return Get(0, 0);
        }

        public IEnumerable<News> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(indexFirstElement, numberOfResults, SortOrder.Descending);
        }

        public IEnumerable<News> Get(int indexFirstElement, int numberOfResults, SortOrder order)
        {
            IEnumerable<News> results = (from n in Db.News
                                         where n.Publiee
                                         orderby n.Date_Heure
                                         select n);

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
            return (from news in Db.News
                    orderby news.Code_News descending
                    select news).First().Code_News;
        }

        #endregion

        #region ISearchable methods

        public IEnumerable<News> Search(string keywords)
        {
            IEnumerable<News> news = new List<News>();

            if (!string.IsNullOrWhiteSpace(keywords))
            {
                keywords = keywords.ToLower();

                news = (from n in Db.News
                        where n.Titre.ToLower().Contains(keywords) ||
                              n.Mots_Cles.ToLower().Contains(keywords)
                        orderby n.Date_Heure descending
                        select n);
            }

            return news;
        }

        #endregion

        #region IManager methods

        public int Add(News element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<News> rulesManager = new NewsRulesManager();
                rulesManager.Check(element);

                Db.News.AddObject(element);
                Db.SaveChanges();

                return element.Code_News;
            }
            throw new AccessDeniedException();
        }

        public void Edit(News element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
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

                Db.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException();
            }
        }

        public void Delete(int code, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                News news = Get(code);
                Db.News.DeleteObject(news);

                Db.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException();
            }
        }

        #endregion
    }
}