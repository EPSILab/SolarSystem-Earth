using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.Common.Utils;
using EPSILab.SolarSystem.Earth.DataAccess.Exceptions;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Campus = EPSILab.SolarSystem.Earth.DataAccess.Model.Campus;
using LostPasswordRequest = EPSILab.SolarSystem.Earth.DataAccess.Model.LostPasswordRequest;
using Member = EPSILab.SolarSystem.Earth.DataAccess.Model.Member;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Access to members table
    /// </summary>
    public class MemberDAL : IMemberReader<Member, Campus>, ISearchable<Member>, ILogin<Member, LostPasswordRequest>, IManager<Member>
    {
        #region IMemberReader methods

        /// <summary>
        /// Get a member
        /// </summary>
        /// <param name="code">Member id</param>
        /// <returns>Matching member</returns>
        public Member Get(int code)
        {
            Member membre = (from m in SunAccess.Instance.Member
                             where m.Id == code
                             select m).First();

            return membre;
        }

        /// <summary>
        /// Get all members
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<Member> Get()
        {
            return Get(null, null, null, null);
        }

        /// <summary>
        /// Get all bureau members
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<Member> GetBureau()
        {
            return GetBureau(null);
        }

        /// <summary>
        /// Get bureau members of a city
        /// </summary>
        /// <param name="campus">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<Member> GetBureau(Campus campus)
        {
            return Get(campus, Role.Bureau, true, false);
        }

        /// <summary>
        /// Get actives members of a city
        /// </summary>
        /// <param name="campus">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<Member> GetMembersActives(Campus campus)
        {
            return Get(campus, Role.MemberActive, true, false);
        }

        /// <summary>
        /// Get bureau and actives members
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<Member> GetBureauAndMembersActives()
        {
            return GetBureauAndMembersActives(null);
        }

        /// <summary>
        /// Get bureau and actives members of a city
        /// </summary>
        /// <param name="campus">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<Member> GetBureauAndMembersActives(Campus campus)
        {
            return Get(campus, null, true, false);
        }

        /// <summary>
        /// Get all alumnis
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<Member> GetAlumnis()
        {
            return GetAlumnis(null);
        }

        /// <summary>
        /// Get alumnis of a city
        /// </summary>
        /// <param name="campus">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<Member> GetAlumnis(Campus campus)
        {
            return Get(campus, null, true, true);
        }

        /// <summary>
        /// Get members waiting for an admin validation
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<Member> GetWaitingForValidation()
        {
            return Get(null, Role.Inactive, false, false);
        }

        /// <summary>
        /// A private method called by all others public Get methods
        /// </summary>
        /// <param name="campus">Concerned city</param>
        /// <param name="role">Role of members</param>
        /// <param name="activesOnly">Actives/Not actives/All</param>
        /// <param name="alumnisOnly">Alumnis/Not alumnis/All</param>
        /// <returns></returns>
        private IEnumerable<Member> Get(Campus campus, Role? role, bool? activesOnly, bool? alumnisOnly)
        {
            IEnumerable<Member> results = (from m in SunAccess.Instance.Member
                                           orderby m.LastName, m.FirstName
                                           select m);

            if (campus != null)
                results = (from m in results
                           where m.Id == campus.Id
                           select m);

            if (role != null)
                results = (from m in results
                           where m.Role == (int)role
                           select m);

            if (activesOnly.HasValue)
                results = (from m in results
                           where m.Active == activesOnly.Value
                           select m);

            if (alumnisOnly.HasValue)
                results = (from m in results
                           where !m.Promotion.StillPresent == alumnisOnly.Value
                           select m);

            return results;
        }

        /// <summary>
        /// Returns last member id
        /// </summary>
        /// <returns>Id the last inserted member</returns>
        public int GetLastInsertedId()
        {
            return (from membre in SunAccess.Instance.Member
                    orderby membre.Id descending
                    select membre).First().Id;
        }

        #endregion

        #region ILogin methods

        /// <summary>
        /// Connect a user and returns all members informations 
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Crypted password</param>
        /// <returns></returns>
        public Member Login(string username, string password)
        {
            Member result = (from membre in SunAccess.Instance.Member
                             where membre.Username == username && membre.Password == password
                             select membre).FirstOrDefault();

            if (result != null)
            {
                DateTime dateLimit = DateTime.Now.AddDays(-2);

                // Clean all old lost password requests
                IEnumerable<LostPasswordRequest> requests = (from r in SunAccess.Instance.LostPasswordRequest
                                                             where r.RequestDateTime < dateLimit
                                                             select r);

                foreach (var request in requests)
                    SunAccess.Instance.LostPasswordRequest.Remove(request);

                SunAccess.Instance.SaveChanges();

                return result;
            }

            throw new UserNotExistsException();
        }

        /// <summary>
        /// Change a password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="oldPassword">Old password crypted</param>
        /// <param name="newPassword">New password crypted</param>
        public void ChangePassword(string username, string oldPassword, string newPassword)
        {
            Member result = (from membre in SunAccess.Instance.Member
                             where membre.Username == username && membre.Password == oldPassword
                             select membre).First();

            result.Password = newPassword;

            SunAccess.Instance.SaveChanges();
        }

        /// <summary>
        /// Determines if an user exists in the database
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Crypted password</param>
        /// <returns>A boolean which determines if the user exists</returns>
        public bool Exists(string username, string password)
        {
            bool exists = (from membre in SunAccess.Instance.Member
                           where membre.Username == username && membre.Password == password
                           select membre).Any();

            return exists;
        }

        /// <summary>
        /// Determines if an user exists in the database
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>A boolean which determines if the user exists</returns>
        public bool Exists(string username)
        {
            bool exists = (from membre in SunAccess.Instance.Member
                           where membre.Username == username
                           select membre).Any();

            return exists;
        }

        /// <summary>
        /// Register a new user, but inactive
        /// </summary>
        /// <param name="membre">Member to create</param>
        /// <returns>New member id</returns>
        public int Register(Member membre)
        {
            membre.Role = (int)Role.Inactive;
            membre.Url = string.Format("{0}-{1}", membre.FirstName, membre.LastName);

            IRulesManager<Member> rulesManager = new MemberRulesManager();
            rulesManager.Check(membre);

            SunAccess.Instance.Member.Add(membre);
            SunAccess.Instance.SaveChanges();

            return membre.Id;
        }

        /// <summary>
        /// Create a request to recover password
        /// </summary>
        /// <param name="username">Username for control</param>
        /// <param name="email">Email for control</param>
        /// <returns>Password recover informations</returns>
        public LostPasswordRequest RequestLostPassword(string username, string email)
        {
            Member result = (from membre in SunAccess.Instance.Member
                             where membre.Username == username
                             select membre).FirstOrDefault();

            if (result != null)
            {

                LostPasswordRequest recupMotDePasse = new LostPasswordRequest
                {
                    Id = result.Id,
                    RequestDateTime = DateTime.Now,
                    GeneratedKey = MD5HasherUtil.Hash(string.Format("{0}{1}", result.Username, DateTime.Now))
                };

                SunAccess.Instance.LostPasswordRequest.Add(recupMotDePasse);
                SunAccess.Instance.SaveChanges();

                recupMotDePasse.Member = null;

                return recupMotDePasse;
            }

            throw new UserNotExistsException();
        }

        /// <summary>
        /// Set a new password after a lost password request
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="newPassword">Crypted new password</param>
        /// <param name="key">The generated key for lost password request</param>
        public void SetNewPasswordAfterLost(string username, string newPassword, string key)
        {
            LostPasswordRequest recupMotDePasse = (from r in SunAccess.Instance.LostPasswordRequest
                                                   where r.Member.Username == username && r.GeneratedKey == key
                                                   select r).FirstOrDefault();

            if (recupMotDePasse != null)
            {
                Member membre = (from m in SunAccess.Instance.Member
                                 where m.Id == recupMotDePasse.Id
                                 select m).First();

                if (recupMotDePasse.RequestDateTime.AddDays(2) <= DateTime.Now)
                {
                    membre.Password = newPassword;
                    SunAccess.Instance.LostPasswordRequest.Remove(recupMotDePasse);
                    SunAccess.Instance.SaveChanges();
                }
                else
                {
                    SunAccess.Instance.LostPasswordRequest.Remove(recupMotDePasse);
                    SunAccess.Instance.SaveChanges();

                    throw new LostPasswordTimeElapsedException();
                }
            }
            else
                throw new LostPasswordRequestNotFoundException();
        }

        #endregion

        #region ISearchable methods

        /// <summary>
        /// Get members corresponding to a keywords
        /// </summary>
        /// <param name="keywords">Search keywords separated by a space</param>
        /// <returns></returns>
        public IEnumerable<Member> Search(string keywords)
        {
            IEnumerable<Member> membres = new List<Member>();

            if (!string.IsNullOrWhiteSpace(keywords))
            {
                keywords = keywords.ToLower();

                membres = (from membre in SunAccess.Instance.Member
                           where membre.LastName.ToLower().Contains(keywords)
                                 || membre.FirstName.ToLower().Contains(keywords)
                                 || membre.Campus.Place.ToLower().Contains(keywords)
                           orderby membre.LastName
                           orderby membre.FirstName
                           select membre);
            }

            return membres;
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a member
        /// </summary>
        /// <param name="element">Member to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New conference id</returns>
        public int Add(Member element, string username, string password)
        {
            if (Exists(username, password))
            {
                IRulesManager<Member> rulesManager = new MemberRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Member.Add(element);
                SunAccess.Instance.SaveChanges();

                return element.Id;
            }

            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a member
        /// </summary>
        /// <param name="element">Member conference</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Member element, string username, string password)
        {
            if (Exists(username, password))
            {
                IRulesManager<Member> rulesManager = new MemberRulesManager();
                rulesManager.Check(element);

                Member m = Get(element.Id);

                m.Id = element.Id;
                m.Role = element.Role;
                m.Id = element.Id;
                m.LastName = element.LastName;
                m.FirstName = element.FirstName;
                m.Username = element.Username;
                m.Password = element.Password;
                m.PersonalEmail = element.PersonalEmail;
                m.EPSIEmail = element.EPSIEmail;
                m.PhoneNumber = element.PhoneNumber;
                m.CityFrom = element.CityFrom;
                m.Website = element.Website;
                m.FacebookUrl = element.FacebookUrl;
                m.TwitterUrl = element.TwitterUrl;
                m.ViadeoUrl = element.ViadeoUrl;
                m.LinkedInUrl = element.LinkedInUrl;
                m.GitHubUrl = element.GitHubUrl;
                m.Status = element.Status;
                m.Presentation = element.Presentation;
                m.ImageUrl = element.ImageUrl;
                m.Url = element.Url;

                SunAccess.Instance.SaveChanges();
            }
            else
                throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Delete a member
        /// </summary>
        /// <param name="code">Member id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            if (Exists(username, password))
            {
                Member membre = Get(code);
                SunAccess.Instance.Member.Remove(membre);

                SunAccess.Instance.SaveChanges();
            }
            else
                throw new AccessDeniedException(username);
        }

        #endregion
    }
}