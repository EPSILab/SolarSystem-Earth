using System.Collections.Generic;
using System.ServiceModel;
using EPSILab.SolarSystem.Earth.Common;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface IProjectReader
    {
        [OperationContract]
        Project GetProject(int code);

        [OperationContract]
        IEnumerable<Project> GetProjects();

        [OperationContract]
        IEnumerable<Project> GetProjectsLimited(int indexFirstElement, int numberOfResults);

        [OperationContract]
        IEnumerable<Project> GetProjectsByCampus(Campus campus);

        [OperationContract]
        IEnumerable<Project> GetProjectsByCampusLimited(Campus campus, int indexFirstElement, int numberOfResults);

        [OperationContract]
        int GetProjectLastInsertedId();
    }
}