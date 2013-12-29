using SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IPubliciteManager
    {
        [OperationContract]
        Publicite GetPublicite(int code);

        [OperationContract]
        IEnumerable<Publicite> GetPublicites();

        [OperationContract]
        int AddPublicite(Publicite element, string username, string password);

        [OperationContract]
        void EditPublicite(Publicite element, string username, string password);

        [OperationContract]
        void DeletePublicite(int code, string username, string password);
    }
}