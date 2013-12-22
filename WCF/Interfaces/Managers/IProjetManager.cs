using SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IProjetManager
    {
        [OperationContract]
        IEnumerable<Projet> GetProjets(int indexFirstResult, int numberOfResults, string username, string password);

        [OperationContract]
        Projet GetProjet(int code, string username, string password);

        [OperationContract]
        int AddProjet(Projet element, string username, string password);

        [OperationContract]
        void EditProjet(Projet element, string username, string password);

        [OperationContract]
        void DeleteProjet(int code, string username, string password);
    }
}