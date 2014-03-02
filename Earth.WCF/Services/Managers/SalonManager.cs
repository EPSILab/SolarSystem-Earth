using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : IShowManager
    {
        public Show GetShow(int code)
        {
            IReader<Show> business = new ShowBusiness();
            return business.Get(code);
        }

        public IEnumerable<Show> GetShows(int indexFirstElement, int numberOfResults)
        {
            IReaderLimit<Show> business = new ShowBusiness();
            return business.Get(indexFirstElement, numberOfResults);
        }

        public int AddShow(Show element, string username, string password)
        {
            IManager<Show> business = new ShowBusiness();
            return business.Add(element, username, password);
        }

        public void EditShow(Show element, string username, string password)
        {
            IManager<Show> business = new ShowBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteShow(int code, string username, string password)
        {
            IManager<Show> business = new ShowBusiness();
            business.Delete(code, username, password);
        }
    }
}