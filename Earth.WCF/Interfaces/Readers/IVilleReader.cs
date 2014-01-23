using System.Collections.Generic;
using System.ServiceModel;
using EPSILab.SolarSystem.Earth.Common;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
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