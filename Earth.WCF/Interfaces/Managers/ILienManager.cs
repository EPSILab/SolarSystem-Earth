using EPSILab.SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface ILienManager
    {
        [OperationContract]
        Lien GetLien(int code);

        [OperationContract]
        IEnumerable<Lien> GetLiens();

        [OperationContract]
        int AddLien(Lien element, string username, string password);

        [OperationContract]
        void EditLien(Lien element, string username, string password);

        [OperationContract]
        void DeleteLien(int code, string username, string password);
    }
}