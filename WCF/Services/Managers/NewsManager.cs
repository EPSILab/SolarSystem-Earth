using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : INewsManager
    {
        public IEnumerable<News> GetNewsList(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IManager<News> business = new NewsBusiness();
            return business.Get(indexFirstResult, numberOfResults, username, password);
        }

        public News GetNews(int code, string username, string password)
        {
            IManager<News> business = new NewsBusiness();
            return business.Get(code, username, password);
        }

        public int AddNews(News element, string username, string password)
        {
            IManager<News> business = new NewsBusiness();
            return business.Add(element, username, password);
        }

        public void EditNews(News element, string username, string password)
        {
            IManager<News> business = new NewsBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteNews(int code, string username, string password)
        {
            IManager<News> business = new NewsBusiness();
            business.Delete(code, username, password);
        }
    }
}