using System.ServiceModel.PeerResolvers;
using SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IMembreManager
    {
        [OperationContract]
        Membre Login(string username, string password);

        [OperationContract]
        bool Exists(string username, string password);

        [OperationContract]
        int Register(Membre membre);

        [OperationContract]
        Membre GetMembre(int code, string username, string password);

        [OperationContract]
        IEnumerable<Membre> GetMembres(int indexFirstResult, int numberOfResults, string username, string password);

        [OperationContract]
        int AddMembre(Membre element, string username, string password);

        [OperationContract]
        void EditMembre(Membre element, string username, string password);

        [OperationContract]
        void DeleteMembre(int code, string username, string password);
    }
}