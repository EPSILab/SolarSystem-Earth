using SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface ILienManager
    {
        [OperationContract]
        Lien GetLien(int code, string username, string password);

        [OperationContract]
        IEnumerable<Lien> GetLiens(int indexFirstResult, int numberOfResults, string username, string password);

        [OperationContract]
        int AddLien(Lien element, string username, string password);

        [OperationContract]
        void EditLien(Lien element, string username, string password);

        [OperationContract]
        void DeleteLien(int code, string username, string password);
    }
}