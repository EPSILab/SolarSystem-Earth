using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : IProjectReader
    {
        public Project GetProject(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Project>>().Get(code);
        }

        public IEnumerable<Project> GetProjects()
        {
            return NinjectKernel.Kernel.Get<IReader<Project>>().Get();
        }

        public IEnumerable<Project> GetProjectsLimited(int indexFirstElement, int numberOfResults)
        {
            return NinjectKernel.Kernel.Get<IReader1Filter<Project, Campus>>().Get(indexFirstElement, numberOfResults);
        }

        public IEnumerable<Project> GetProjectsByCampus(Campus campus)
        {
            return NinjectKernel.Kernel.Get<IReader1Filter<Project, Campus>>().Get(campus);
        }

        public IEnumerable<Project> GetProjectsByCampusLimited(Campus campus, int indexFirstElement, int numberOfResults)
        {
            return NinjectKernel.Kernel.Get<IReader1Filter<Project, Campus>>().Get(campus, indexFirstElement, numberOfResults);
        }

        public int GetProjectLastInsertedId()
        {
            return NinjectKernel.Kernel.Get<IReader1Filter<Project, Campus>>().GetLastInsertedId();
        }
    }
}