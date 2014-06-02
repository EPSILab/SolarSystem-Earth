using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : ILinkManager
    {
        public Link GetLink(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Link>>().Get(code);
        }

        public IEnumerable<Link> GetLinks()
        {
            return NinjectKernel.Kernel.Get<IReader<Link>>().Get();
        }

        public int AddLink(Link element, string username, string password)
        {
            return NinjectKernel.Kernel.Get<IManager<Link>>().Add(element, username, password);
        }

        public void EditLink(Link element, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Link>>().Edit(element, username, password);
        }

        public void DeleteLink(int code, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Link>>().Delete(code, username, password);
        }
    }
}