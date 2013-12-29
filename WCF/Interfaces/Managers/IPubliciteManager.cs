using SolarSystem.Earth.Common;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IPubliciteManager : IPubliciteReader
    {
        [OperationContract]
        int AddPublicite(Publicite element, string username, string password);

        [OperationContract]
        void EditPublicite(Publicite element, string username, string password);

        [OperationContract]
        void DeletePublicite(int code, string username, string password);
    }
}