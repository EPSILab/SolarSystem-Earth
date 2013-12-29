using SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IClasseManager
    {
        [OperationContract]
        Classe GetClasse(int code);

        [OperationContract]
        IEnumerable<Classe> GetClasses();

        [OperationContract]
        int AddClasse(Classe element, string username, string password);

        [OperationContract]
        void EditClasse(Classe element, string username, string password);

        [OperationContract]
        void DeleteClasse(int code, string username, string password);
    }
}