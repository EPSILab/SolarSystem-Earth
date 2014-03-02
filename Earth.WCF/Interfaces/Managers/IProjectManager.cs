using EPSILab.SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IProjectManager
    {
        [OperationContract]
        Project GetProject(int code);

        [OperationContract]
        IEnumerable<Project> GetProjects(int indexFirstElement, int numberOfResults);

        [OperationContract]
        int AddProject(Project element, string username, string password);

        [OperationContract]
        void EditProject(Project element, string username, string password);

        [OperationContract]
        void DeleteProject(int code, string username, string password);
    }
}