using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
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