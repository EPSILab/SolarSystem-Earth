using System.Collections.Generic;
using System.ServiceModel;
using EPSILab.SolarSystem.Earth.Common;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface ILienReader
    {
        [OperationContract]
        Lien GetLien(int code);

        [OperationContract]
        IEnumerable<Lien> GetLiens();
    }
}