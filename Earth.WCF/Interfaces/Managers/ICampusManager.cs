using EPSILab.SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface ICampusManager
    {
        [OperationContract]
        Campus GetCampus(int code);

        [OperationContract]
        IEnumerable<Campus> GetCampuses();

        [OperationContract]
        int AddCampus(Campus element, string username, string password);

        [OperationContract]
        void EditCampus(Campus element, string username, string password);

        [OperationContract]
        void DeleteCampus(int code, string username, string password);
    }
}