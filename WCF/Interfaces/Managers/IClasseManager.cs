using SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IClasseManager
    {
        [OperationContract]
        Classe GetClasse(int code, string username, string password);

        [OperationContract]
        IEnumerable<Classe> GetClasses(int indexFirstResult, int numberOfResults, string username, string password);

        [OperationContract]
        int AddClasse(Classe element, string username, string password);

        [OperationContract]
        void EditClasse(Classe element, string username, string password);

        [OperationContract]
        void DeleteClasse(int code, string username, string password);
    }
}