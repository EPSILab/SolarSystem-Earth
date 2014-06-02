using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : IMemberManager
    {
        public Member GetMember(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Member>>().Get(code);
        }

        public IEnumerable<Member> GetMembersActives()
        {
            return NinjectKernel.Kernel.Get<IMemberReader<Member, Campus>>().GetBureauAndMembersActives();
        }

        public IEnumerable<Member> GetMembersBureau(Campus campus)
        {
            return NinjectKernel.Kernel.Get<IMemberReader<Member, Campus>>().GetBureau(campus);
        }

        public IEnumerable<Member> GetMembersNotInBureau(Campus campus)
        {
            return NinjectKernel.Kernel.Get<IMemberReader<Member, Campus>>().GetMembersActives(campus);
        }

        public IEnumerable<Member> GetMembersAlumnis(Campus campus)
        {
            return NinjectKernel.Kernel.Get<IMemberReader<Member, Campus>>().GetAlumnis(campus);
        }

        public IEnumerable<Member> GetMembersWaitingForValidation()
        {
            return NinjectKernel.Kernel.Get<IMemberReader<Member, Campus>>().GetWaitingForValidation();
        }

        public Member Login(string username, string password)
        {
            return NinjectKernel.Kernel.Get<ILogin<Member, LostPasswordRequest>>().Login(username, password);
        }

        public void ChangePassword(string username, string oldPassword, string newPassword)
        {
            NinjectKernel.Kernel.Get<ILogin<Member, LostPasswordRequest>>().ChangePassword(username, oldPassword, newPassword);
        }

        public bool ExistsMember(string username, string password)
        {
            return NinjectKernel.Kernel.Get<ILogin<Member, LostPasswordRequest>>().Exists(username, password);
        }

        public bool ExistsUsername(string username)
        {
            return NinjectKernel.Kernel.Get<ILogin<Member, LostPasswordRequest>>().Exists(username);
        }

        public int Register(Member member, string newPassword)
        {
            return NinjectKernel.Kernel.Get<ILogin<Member, LostPasswordRequest>>().Register(member, newPassword);
        }

        public void RequestLostPassword(string username, string email)
        {
            NinjectKernel.Kernel.Get<ILogin<Member, LostPasswordRequest>>().RequestLostPassword(username, email);
        }

        public void SetNewPasswordAfterLost(string username, string newPassword, string key)
        {
            NinjectKernel.Kernel.Get<ILogin<Member, LostPasswordRequest>>().SetNewPasswordAfterLost(username, newPassword, key);
        }

        public int AddMember(Member element, string username, string password)
        {
            return NinjectKernel.Kernel.Get<IManager<Member>>().Add(element, username, password);
        }

        public void EditMember(Member element, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Member>>().Edit(element, username, password);
        }

        public void DeleteMember(int code, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Member>>().Delete(code, username, password);
        }
    }
}