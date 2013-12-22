using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;
using SolarSystem.Earth.Common;

namespace SolarSystem.Earth.WCF.Interfaces.Readers
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
        IEnumerable<Salon> GetSalonsSorted(int indexFirstElement, int numberOfResults, SortOrder order);

        [OperationContract]
        int GetSalonLastInsertedId();

        [OperationContract]
        IEnumerable<Salon> SearchSalons(string keywords);
    }
}
