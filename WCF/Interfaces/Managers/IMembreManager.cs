using SolarSystem.Earth.Common;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IMembreManager : IMembreReader
    {
        [OperationContract]
        Membre Login(string username, string password);

        [OperationContract]
        bool Exists(string username, string password);

        [OperationContract]
        int Register(Membre membre);

        [OperationContract]
        int AddMembre(Membre element, string username, string password);

        [OperationContract]
        void EditMembre(Membre element, string username, string password);

        [OperationContract]
        void DeleteMembre(int code, string username, string password);
    }
}