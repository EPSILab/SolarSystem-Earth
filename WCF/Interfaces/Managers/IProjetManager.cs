using System.Collections.Generic;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IProjetManager
    {
        [OperationContract]
        Projet GetProjet(int code);

        [OperationContract]
        IEnumerable<Projet> GetProjets(int indexFirstElement, int numberOfResults);

        [OperationContract]
        int AddProjet(Projet element, string username, string password);

        [OperationContract]
        void EditProjet(Projet element, string username, string password);

        [OperationContract]
        void DeleteProjet(int code, string username, string password);
    }
}