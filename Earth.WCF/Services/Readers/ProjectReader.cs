using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : IProjectReader
    {
        public Project GetProject(int code)
        {
            IReader<Project> business = new ProjectBusiness();
            return business.Get(code);
        }

        public IEnumerable<Project> GetProjects()
        {
            IReader<Project> business = new ProjectBusiness();
            return business.Get();
        }

        public IEnumerable<Project> GetProjectsLimited(int indexFirstElement, int numberOfResults)
        {
            IReaderLimit<Project> business = new ProjectBusiness();
            return business.Get(indexFirstElement, numberOfResults);
        }

        public IEnumerable<Project> GetProjectsByCampus(Campus campus)
        {
            IReader1Filter<Project, Campus> business = new ProjectBusiness();
            return business.Get(campus);
        }

        public IEnumerable<Project> GetProjectsByCampusLimited(Campus campus, int indexFirstElement, int numberOfResults)
        {
            IReader1Filter<Project, Campus> business = new ProjectBusiness();
            return business.Get(campus, indexFirstElement, numberOfResults);
        }

        public int GetProjectLastInsertedId()
        {
            IReaderLimit<Project> business = new ProjectBusiness();
            return business.GetLastInsertedId();
        }
    }
}