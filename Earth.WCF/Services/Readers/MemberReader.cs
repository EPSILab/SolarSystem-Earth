using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : IMemberReader
    {
        public Member GetMember(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Member>>().Get(code);
        }

        public IEnumerable<Member> GetMembers()
        {
            return NinjectKernel.Kernel.Get<IMemberReader<Member, Campus>>().GetBureauAndMembersActives();
        }

        public IEnumerable<Member> GetMembersByCampus(Campus campus)
        {
            return NinjectKernel.Kernel.Get<IMemberReader<Member, Campus>>().GetBureauAndMembersActives(campus);
        }

        public IEnumerable<Member> GetMembersBureau()
        {
            return NinjectKernel.Kernel.Get<IMemberReader<Member, Campus>>().GetBureau();
        }

        public IEnumerable<Member> GetMembersBureauByCampus(Campus campus)
        {
            return NinjectKernel.Kernel.Get<IMemberReader<Member, Campus>>().GetBureau(campus);
        }

        public IEnumerable<Member> GetMembersAlumnis(Campus campus)
        {
            return NinjectKernel.Kernel.Get<IMemberReader<Member, Campus>>().GetAlumnis(campus);
        }

        public int GetMemberLastInsertedId()
        {
            return NinjectKernel.Kernel.Get<IReader<Member>>().GetLastInsertedId();
        }

        public IEnumerable<Member> SearchMembers(string keywords)
        {
            return NinjectKernel.Kernel.Get<ISearchable<Member>>().Search(keywords);
        }
    }
}