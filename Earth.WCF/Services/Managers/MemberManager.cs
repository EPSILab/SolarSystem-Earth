using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : IMemberManager
    {
        public Member GetMember(int code)
        {
            IReader<Member> business = new MemberBusiness();
            return business.Get(code);
        }

        public IEnumerable<Member> GetMembersActives()
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetBureauAndMembersActives();
        }

        public IEnumerable<Member> GetMembersBureau(Campus campus)
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetBureau(campus);
        }

        public IEnumerable<Member> GetMembersNotInBureau(Campus campus)
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetMembersActives(campus);
        }

        public IEnumerable<Member> GetMembersAlumnis(Campus campus)
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetAlumnis(campus);
        }

        public IEnumerable<Member> GetMembersWaitingForValidation()
        {
            IMemberReader<Member, Campus> business = new MemberBusiness();
            return business.GetWaitingForValidation();
        }

        public Member Login(string username, string password)
        {
            ILogin<Member, LostPasswordRequest> business = new MemberBusiness();
            return business.Login(username, password);
        }

        public void ChangePassword(string username, string oldPassword, string newPassword)
        {
            ILogin<Member, LostPasswordRequest> business = new MemberBusiness();
            business.ChangePassword(username, oldPassword, newPassword);
        }

        public bool ExistsMember(string username, string password)
        {
            ILogin<Member, LostPasswordRequest> business = new MemberBusiness();
            return business.Exists(username, password);
        }

        public bool ExistsUsername(string username)
        {
            ILogin<Member, LostPasswordRequest> business = new MemberBusiness();
            return business.Exists(username);
        }

        public int Register(Member member, string newPassword)
        {
            ILogin<Member, LostPasswordRequest> business = new MemberBusiness();
            return business.Register(member, newPassword);
        }

        public void RequestLostPassword(string username, string email)
        {
            ILogin<Member, LostPasswordRequest> business = new MemberBusiness();
            business.RequestLostPassword(username, email);
        }

        public void SetNewPasswordAfterLost(string username, string newPassword, string key)
        {
            ILogin<Member, LostPasswordRequest> business = new MemberBusiness();
            business.SetNewPasswordAfterLost(username, newPassword, key);
        }

        public int AddMember(Member element, string username, string password)
        {
            IManager<Member> business = new MemberBusiness();
            return business.Add(element, username, password);
        }

        public void EditMember(Member element, string username, string password)
        {
            IManager<Member> business = new MemberBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteMember(int code, string username, string password)
        {
            IManager<Member> business = new MemberBusiness();
            business.Delete(code, username, password);
        }
    }
}