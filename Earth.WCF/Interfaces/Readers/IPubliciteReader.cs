using System.Collections.Generic;
using System.ServiceModel;
using EPSILab.SolarSystem.Earth.Common;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
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