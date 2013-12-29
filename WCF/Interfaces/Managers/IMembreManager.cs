using SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IMembreManager
    {
        [OperationContract]
        Membre GetMembre(int code);

        [OperationContract]
        IEnumerable<Membre> GetMembres();

        [OperationContract]
        IEnumerable<Membre> GetMembresByVilleAndRole(Ville ville, Role role);

        [OperationContract]
        Membre Login(string username, string password);

        [OperationContract]
        void ChangePassword(string username, string oldPassword, string newPassword);

        [OperationContract]
        bool ExistsUsername(string username);

        [OperationContract]
        bool ExistsMembre(string username, string password);

        [OperationContract]
        int Register(Membre membre);

        [OperationContract]
        void RequestLostPassword(string username, string email);

        [OperationContract]
        void SetNewPasswordAfterLost(string username, string newPassword, string key);

        [OperationContract]
        int AddMembre(Membre element, string username, string password);

        [OperationContract]
        void EditMembre(Membre element, string username, string password);

        [OperationContract]
        void DeleteMembre(int code, string username, string password);
    }
}