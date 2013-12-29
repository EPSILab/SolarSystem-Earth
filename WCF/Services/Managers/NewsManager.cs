using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : INewsManager
    {
        public News GetNews(int code)
        {
            IReader<News> business = new NewsBusiness();
            return business.Get(code);
        }

        public IEnumerable<News> GetListNews()
        {
            IReader<News> business = new NewsBusiness();
            return business.Get();
        }

        public IEnumerable<News> GetListNewsLimited(int indexFirstElement, int numberOfResults)
        {
            IReaderLimit<News> business = new NewsBusiness();
            return business.Get(indexFirstElement, numberOfResults);
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