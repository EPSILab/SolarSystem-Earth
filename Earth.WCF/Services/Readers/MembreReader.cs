using System.Collections.Generic;
using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : IMemberReader
    {
        public Member GetMember(int code)
        {
            IReader<Member> business = new MemberBusiness();
            return business.Get(code);
        }

        public IEnumerable<Member> GetMembers()
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetBureauAndMembersActives();
        }

        public IEnumerable<Member> GetMembersByCampus(Campus campus)
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetBureauAndMembersActives(Campus);
        }

        public IEnumerable<Member> GetMembersBureau()
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetBureau();
        }

        public IEnumerable<Member> GetMembersBureauByCampus(Campus campus)
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetBureau(Campus);
        }

        public IEnumerable<Member> GetMembersAlumnis(Campus campus)
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetAlumnis(Campus);
        }

        public int GetMemberLastInsertedId()
        {
            IReader<Member> business = new MemberBusiness();
            return business.GetLastInsertedId();
        }

        public IEnumerable<Member> SearchMembers(string keywords)
        {
            ISearchable<Member> business = new MemberBusiness();
            return business.Search(keywords);
        }
    }
}