using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : IShowReader
    {
        public Show GetShow(int code)
        {
            IReader<Show> business = new ShowBusiness();
            return business.Get(code);
        }

        public IEnumerable<Show> GetShows()
        {
            IReader<Show> business = new ShowBusiness();
            return business.Get();
        }

        public IEnumerable<Show> GetShowsLimited(int indexFirstElement, int numberOfResults)
        {
            IReaderLimit<Show> business = new ShowBusiness();
            return business.Get(indexFirstElement, numberOfResults);
        }

        public int GetShowLastInsertedId()
        {
            IReaderLimit<Show> business = new ShowBusiness();
            return business.GetLastInsertedId();
        }

        public IEnumerable<Show> SearchShows(string keywords)
        {
            ISearchable<Show> business = new ShowBusiness();
            return business.Search(keywords);
        }
    }
}