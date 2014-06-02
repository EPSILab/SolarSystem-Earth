using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : IProjectManager
    {
        public Project GetProject(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Project>>().Get(code);
        }

        public IEnumerable<Project> GetProjects(int indexFirstElement, int numberOfResults)
        {
            return NinjectKernel.Kernel.Get<IReaderLimit<Project>>().Get(indexFirstElement, numberOfResults);
        }

        public int AddProject(Project element, string username, string password)
        {
            return NinjectKernel.Kernel.Get<IManager<Project>>().Add(element, username, password);
        }

        public void EditProject(Project element, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Project>>().Edit(element, username, password);
        }

        public void DeleteProject(int code, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Project>>().Delete(code, username, password);
        }
    }
}