using System.Collections.Generic;
using System.ServiceModel;
using SolarSystem.Earth.Common;

namespace SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface IVilleReader
    {
        [OperationContract]
        Ville GetVille(int code);

        [OperationContract]
        IEnumerable<Ville> GetVilles();
    }
}
