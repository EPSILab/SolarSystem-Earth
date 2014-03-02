using System.Collections.Generic;
using System.ServiceModel;
using EPSILab.SolarSystem.Earth.Common;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface ICampusReader
    {
        [OperationContract]
        Campus GetCampus(int code);

        [OperationContract]
        IEnumerable<Campus> GetCampuses();
    }
}