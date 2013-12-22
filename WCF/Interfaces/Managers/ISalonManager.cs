using SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface ISalonManager
    {
        [OperationContract]
        Salon GetSalon(int code, string username, string password);

        [OperationContract]
        IEnumerable<Salon> GetSalons(int indexFirstResult, int numberOfResults, string username, string password);

        [OperationContract]
        int AddSalon(Salon element, string username, string password);

        [OperationContract]
        void EditSalon(Salon element, string username, string password);

        [OperationContract]
        void DeleteSalon(int code, string username, string password);
    }
}