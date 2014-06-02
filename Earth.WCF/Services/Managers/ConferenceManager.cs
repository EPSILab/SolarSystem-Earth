using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : IConferenceManager
    {
        public Conference GetConference(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Conference>>().Get(code);
        }

        public IEnumerable<Conference> GetConferences(int indexFirstResult, int numberOfResults)
        {
            return NinjectKernel.Kernel.Get<IReaderLimit<Conference>>().Get(indexFirstResult, numberOfResults);
        }

        public int AddConference(Conference element, string username, string password)
        {
            return NinjectKernel.Kernel.Get<IManager<Conference>>().Add(element, username, password);
        }

        public void EditConference(Conference element, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Conference>>().Edit(element, username, password);
        }

        public void DeleteConference(int code, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Conference>>().Delete(code, username, password);
        }
    }
}