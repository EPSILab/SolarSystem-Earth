﻿using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;

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
            return business.GetBureauAndMembersActives(campus);
        }

        public IEnumerable<Member> GetMembersBureau()
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetBureau();
        }

        public IEnumerable<Member> GetMembersBureauByCampus(Campus campus)
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetBureau(campus);
        }

        public IEnumerable<Member> GetMembersAlumnis(Campus campus)
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetAlumnis(campus);
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