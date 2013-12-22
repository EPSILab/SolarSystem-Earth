using SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IVilleManager
    {
        [OperationContract]
        Ville GetVille(int code, string username, string password);

        [OperationContract]
        IEnumerable<Ville> GetVilles(int indexFirstResult, int numberOfResults, string username, string password);

        [OperationContract]
        int AddVille(Ville element, string username, string password);

        [OperationContract]
        void EditVille(Ville element, string username, string password);

        [OperationContract]
        void DeleteVille(int code, string username, string password);
    }
}