using SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IPubliciteManager
    {
        [OperationContract]
        IEnumerable<Publicite> GetPublicites(int indexFirstResult, int numberOfResults, string username, string password);

        [OperationContract]
        Publicite GetPublicite(int code, string username, string password);

        [OperationContract]
        int AddPublicite(Publicite element, string username, string password);

        [OperationContract]
        void EditPublicite(Publicite element, string username, string password);

        [OperationContract]
        void DeletePublicite(int code, string username, string password);
    }
}