using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : IShowManager
    {
        public Show GetShow(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Show>>().Get(code);
        }

        public IEnumerable<Show> GetShows(int indexFirstElement, int numberOfResults)
        {
            return NinjectKernel.Kernel.Get<IReaderLimit<Show>>().Get(indexFirstElement, numberOfResults);
        }

        public int AddShow(Show element, string username, string password)
        {
            return NinjectKernel.Kernel.Get<IManager<Show>>().Add(element, username, password);
        }

        public void EditShow(Show element, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Show>>().Edit(element, username, password);
        }

        public void DeleteShow(int code, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Show>>().Delete(code, username, password);
        }
    }
}