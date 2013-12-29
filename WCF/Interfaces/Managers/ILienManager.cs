using SolarSystem.Earth.Common;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface ILienManager : ILienReader
    {
        [OperationContract]
        int AddLien(Lien element, string username, string password);

        [OperationContract]
        void EditLien(Lien element, string username, string password);

        [OperationContract]
        void DeleteLien(int code, string username, string password);
    }
}