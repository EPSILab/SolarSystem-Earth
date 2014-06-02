using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : ICampusManager
    {
        public Campus GetCampus(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Campus>>().Get(code);
        }

        public IEnumerable<Campus> GetCampuses()
        {
            return NinjectKernel.Kernel.Get<IReader<Campus>>().Get();
        }

        public int AddCampus(Campus element, string username, string password)
        {
            return NinjectKernel.Kernel.Get<IManager<Campus>>().Add(element, username, password);
        }

        public void EditCampus(Campus element, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Campus>>().Edit(element, username, password);
        }

        public void DeleteCampus(int code, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Campus>>().Delete(code, username, password);
        }
    }
}