using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : IProjectManager
    {
        public Project GetProject(int code)
        {
            IReader<Project> business = new ProjectBusiness();
            return business.Get(code);
        }

        public IEnumerable<Project> GetProjects(int indexFirstElement, int numberOfResults)
        {
            IReaderLimit<Project> business = new ProjectBusiness();
            return business.Get(indexFirstElement, numberOfResults);
        }

        public int AddProject(Project element, string username, string password)
        {
            IManager<Project> business = new ProjectBusiness();
            return business.Add(element, username, password);
        }

        public void EditProject(Project element, string username, string password)
        {
            IManager<Project> business = new ProjectBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteProject(int code, string username, string password)
        {
            IManager<Project> business = new ProjectBusiness();
            business.Delete(code, username, password);
        }
    }
}