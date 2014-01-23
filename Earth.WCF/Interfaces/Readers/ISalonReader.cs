using System.Collections.Generic;
using System.ServiceModel;
using EPSILab.SolarSystem.Earth.Common;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface ISalonReader
    {
        [OperationContract]
        Salon GetSalon(int code);

        [OperationContract]
        IEnumerable<Salon> GetSalons();

        [OperationContract]
        IEnumerable<Salon> GetSalonsLimited(int indexFirstElement, int numberOfResults);

        [OperationContract]
        int GetSalonLastInsertedId();

        [OperationContract]
        IEnumerable<Salon> SearchSalons(string keywords);
    }
}