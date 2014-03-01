using EPSILab.SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IMemberManager
    {
        [OperationContract]
        Member GetMember(int code);

        [OperationContract]
        IEnumerable<Member> GetMembersActives();

        [OperationContract]
        IEnumerable<Member> GetMembersBureau(Campus campus);

        [OperationContract]
        IEnumerable<Member> GetMembersNotInBureau(Campus campus);

        [OperationContract]
        IEnumerable<Member> GetMembersAlumnis(Campus campus);

        [OperationContract]
        IEnumerable<Member> GetMembersWaitingForValidation();

        [OperationContract]
        Member Login(string username, string password);

        [OperationContract]
        void ChangePassword(string username, string oldPassword, string newPassword);

        [OperationContract]
        bool ExistsUsername(string username);

        [OperationContract]
        bool ExistsMember(string username, string password);

        [OperationContract]
        int Register(Member membre);

        [OperationContract]
        void RequestLostPassword(string username, string email);

        [OperationContract]
        void SetNewPasswordAfterLost(string username, string newPassword, string key);

        [OperationContract]
        int AddMember(Member element, string username, string password);

        [OperationContract]
        void EditMember(Member element, string username, string password);

        [OperationContract]
        void DeleteMember(int code, string username, string password);
    }
}