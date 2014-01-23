using System.Collections.Generic;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.ServiceModel;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers
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