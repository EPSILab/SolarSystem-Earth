using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SolarSystem.Earth.WCF
{
    public partial class ReadersService : INewsReader
    {
        public News GetNews(int code)
        {
            IReader<News> business = new NewsBusiness();
            return business.Get(code);
        }

        public IEnumerable<News> GetListNews()
        {
            IReader2Filters<News, Membre, bool?> business = new NewsBusiness();
            return business.Get(true);
        }

        public IEnumerable<News> GetListNewsLimited(int indexFirstElement, int numberOfResults)
        {
            IReader2Filters<News, Membre, bool?> business = new NewsBusiness();
            return business.Get(true, indexFirstElement, numberOfResults);
        }

        public int GetNewsLastInsertedId()
        {
            IReaderLimit<News> business = new NewsBusiness();
            return business.GetLastInsertedId();
        }

        public IEnumerable<News> SearchNews(string keywords)
        {
            ISearchable<News> business = new NewsBusiness();
            return business.Search(keywords);
        }
    }
}