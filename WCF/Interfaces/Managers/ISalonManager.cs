using SolarSystem.Earth.Common;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface ISalonManager : ISalonReader
    {
        [OperationContract]
        int AddSalon(Salon element, string username, string password);

        [OperationContract]
        void EditSalon(Salon element, string username, string password);

        [OperationContract]
        void DeleteSalon(int code, string username, string password);
    }
}