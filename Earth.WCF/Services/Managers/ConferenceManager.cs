using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IConferenceManager
    {
        public Conference GetConference(int code)
        {
            IReader<Conference> business = new ConferenceBusiness();
            return business.Get(code);
        }

        public IEnumerable<Conference> GetConferences(int indexFirstResult, int numberOfResults)
        {
            IReaderLimit<Conference> business = new ConferenceBusiness();
            return business.Get(indexFirstResult, numberOfResults);
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