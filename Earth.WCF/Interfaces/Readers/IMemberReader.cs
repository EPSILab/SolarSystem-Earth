using EPSILab.SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface IMemberReader
    {
        [OperationContract]
        Member GetMember(int code);

        [OperationContract]
        IEnumerable<Member> GetMembers();

        [OperationContract]
        IEnumerable<Member> GetMembersByCampus(Campus campus);

        [OperationContract]
        IEnumerable<Member> GetMembersBureau();

        [OperationContract]
        IEnumerable<Member> GetMembersBureauByCampus(Campus campus);

        [OperationContract]
        IEnumerable<Member> GetMembersAlumnis(Campus campus);

        [OperationContract]
        int GetMemberLastInsertedId();

        [OperationContract]
        IEnumerable<Member> SearchMembers(string keywords);
    }
}