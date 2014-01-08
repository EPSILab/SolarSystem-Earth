using System.Collections.Generic;
using System.ServiceModel;
using SolarSystem.Earth.Common;

namespace SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface IPubliciteReader
    {
        [OperationContract]
        Publicite GetPublicite(int code);

        [OperationContract]
        IEnumerable<Publicite> GetPublicites();
    }
}