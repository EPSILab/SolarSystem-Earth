using System.Collections.Generic;
using System.ServiceModel;
using EPSILab.SolarSystem.Earth.Common;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface ILinkReader
    {
        [OperationContract]
        Link GetLink(int code);

        [OperationContract]
        IEnumerable<Link> GetLinks();
    }
}