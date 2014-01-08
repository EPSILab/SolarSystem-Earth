using System.Collections.Generic;
using System.ServiceModel;
using SolarSystem.Earth.Common;

namespace SolarSystem.Earth.WCF.Interfaces.Readers
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