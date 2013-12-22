using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IConferenceManager
    {
        public Conference GetConference(int code, string username, string password)
        {
            IManager<Conference> business = new ConferenceBusiness();
            return business.Get(code, username, password);
        }

        public IEnumerable<Conference> GetConferences(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IManager<Conference> business = new ConferenceBusiness();
            return business.Get(indexFirstResult, numberOfResults, username, password);
        }

        public int AddConference(Conference element, string username, string password)
        {
            IManager<Conference> business = new ConferenceBusiness();
            return business.Add(element, username, password);
        }

        public void EditConference(Conference element, string username, string password)
        {
            IManager<Conference> business = new ConferenceBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteConference(int code, string username, string password)
        {
            IManager<Conference> business = new ConferenceBusiness();
            business.Delete(code, username, password);
        }
    }
}