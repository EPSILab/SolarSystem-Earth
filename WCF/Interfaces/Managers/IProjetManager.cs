using SolarSystem.Earth.Common;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IProjetManager : IProjetReader
    {
        [OperationContract]
        int AddProjet(Projet element, string username, string password);

        [OperationContract]
        void EditProjet(Projet element, string username, string password);

        [OperationContract]
        void DeleteProjet(int code, string username, string password);
    }
}