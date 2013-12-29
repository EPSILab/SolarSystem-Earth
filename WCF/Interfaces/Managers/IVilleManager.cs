using SolarSystem.Earth.Common;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IVilleManager : IVilleReader
    {
        [OperationContract]
        int AddVille(Ville element, string username, string password);

        [OperationContract]
        void EditVille(Ville element, string username, string password);

        [OperationContract]
        void DeleteVille(int code, string username, string password);
    }
}