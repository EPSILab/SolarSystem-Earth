using EPSILab.SolarSystem.Earth.Business.Ressources;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.DAL;
using EPSILab.SolarSystem.Earth.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using MemberDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Member;
using MemberDTO = EPSILab.SolarSystem.Earth.Common.Member;
using LostPasswordRequestDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.LostPasswordRequest;
using LostPasswordRequestDTO = EPSILab.SolarSystem.Earth.Common.LostPasswordRequest;
using CampusDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Campus;
using CampusDTO = EPSILab.SolarSystem.Earth.Common.Campus;

namespace EPSILab.SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for members
    /// </summary>
    class MemberBusiness : IMemberReader<MemberDTO, CampusDTO>, IManager<MemberDTO>, ISearchable<MemberDTO>, ILogin<MemberDTO, LostPasswordRequestDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly MemberDAL _dal = new MemberDAL();

        /// <summary>
        /// Member mapper
        /// </summary>
        private readonly IMapper<MemberDAO, MemberDTO> _mapperMember = new MemberMapper();

        /// <summary>
        /// City mapper
        /// </summary>
        private readonly IMapper<CampusDAO, CampusDTO> _mapperCity = new CampusMapper();

        #endregion

        #region IMemberReader methods

        /// <summary>
        /// Get a member
        /// </summary>
        /// <param name="code">Member id</param>
        /// <returns>Matching member</returns>
        public MemberDTO Get(int code)
        {
            MemberDAO dao = _dal.Get(code);
            MemberDTO dto = _mapperMember.ToDTO(dao);

            return dto;
        }

        /// <summary>
        /// Get all members
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<MemberDTO> Get()
        {
            IEnumerable<MemberDAO> dao = _dal.Get();
            IEnumerable<MemberDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get all bureau members
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<MemberDTO> GetBureau()
        {
            IEnumerable<MemberDAO> dao = _dal.GetBureau();
            IEnumerable<MemberDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get bureau members of a city
        /// </summary>
        /// <param name="Campus">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<MemberDTO> GetBureau(CampusDTO Campus)
        {
            CampusDAO CampusDao = _mapperCity.ToDAO(Campus);

            IEnumerable<MemberDAO> dao = _dal.GetBureau(CampusDao);
            IEnumerable<MemberDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get actives members of a city
        /// </summary>
        /// <param name="Campus">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<MemberDTO> GetMembersActives(CampusDTO Campus)
        {
            CampusDAO CampusDao = _mapperCity.ToDAO(Campus);

            IEnumerable<MemberDAO> dao = _dal.GetMembersActives(CampusDao);
            IEnumerable<MemberDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get bureau and actives members
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<MemberDTO> GetBureauAndMembersActives()
        {
            IEnumerable<MemberDAO> dao = _dal.GetBureauAndMembersActives();
            IEnumerable<MemberDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get bureau and actives members of a city
        /// </summary>
        /// <param name="Campus">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<MemberDTO> GetBureauAndMembersActives(CampusDTO Campus)
        {
            CampusDAO CampusDao = _mapperCity.ToDAO(Campus);

            IEnumerable<MemberDAO> dao = _dal.GetBureauAndMembersActives(CampusDao);
            IEnumerable<MemberDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get all alumnis
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<MemberDTO> GetAlumnis()
        {
            IEnumerable<MemberDAO> dao = _dal.GetAlumnis();
            IEnumerable<MemberDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get alumnis of a city
        /// </summary>
        /// <param name="Campus">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<MemberDTO> GetAlumnis(CampusDTO Campus)
        {
            CampusDAO CampusDao = _mapperCity.ToDAO(Campus);

            IEnumerable<MemberDAO> dao = _dal.GetAlumnis(CampusDao);
            IEnumerable<MemberDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get members waiting for an admin validation
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<MemberDTO> GetWaitingForValidation()
        {
            IEnumerable<MemberDAO> dao = _dal.GetWaitingForValidation();
            IEnumerable<MemberDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Returns last member id
        /// </summary>
        /// <returns>Id the last inserted member</returns>
        public int GetLastInsertedId()
        {
            return _dal.GetLastInsertedId();
        }

        #endregion

        #region ILogin methods

        /// <summary>
        /// Connect a user and returns all members informations 
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Crypted password</param>
        /// <returns></returns>
        public MemberDTO Login(string username, string password)
        {
            MemberDAO dao = _dal.Login(username, password);
            MemberDTO dto = _mapperMember.ToDTO(dao);
            return dto;
        }

        /// <summary>
        /// Change a password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="oldPassword">Old password crypted</param>
        /// <param name="newPassword">New password crypted</param>
        public void ChangePassword(string username, string oldPassword, string newPassword)
        {
            _dal.ChangePassword(username, oldPassword, newPassword);
        }

        /// <summary>
        /// Determines if an user exists in the database
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Crypted password</param>
        /// <returns>A boolean which determines if the user exists</returns>
        public bool Exists(string username, string password)
        {
            return _dal.Exists(username, password);
        }

        /// <summary>
        /// Determines if an user exists in the database
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>A boolean which determines if the user exists</returns>
        public bool Exists(string username)
        {
            return _dal.Exists(username);
        }

        /// <summary>
        /// Register a new user, but inactive
        /// </summary>
        /// <param name="member">Member to create</param>
        /// <param name="newPassword">The member password</param>
        /// <returns>New member id</returns>
        public int Register(MemberDTO member, string newPassword)
        {
            MemberDAO dao = _mapperMember.ToDAO(member);
            return _dal.Register(dao, newPassword);
        }

        /// <summary>
        /// Create a request to recover password
        /// </summary>
        /// <param name="username">Username for control</param>
        /// <param name="email">Email for control</param>
        /// <returns>Password recover informations</returns>
        public LostPasswordRequestDTO RequestLostPassword(string username, string email)
        {
            IMapper<LostPasswordRequestDAO, LostPasswordRequestDTO> mapper = new LostPasswordRequestMapper();
            LostPasswordRequestDAO dao = _dal.RequestLostPassword(username, email);
            LostPasswordRequestDTO dto = mapper.ToDTO(dao);

            using (MailMessage mail = new MailMessage())
            {
                MailAddress mailReciever = new MailAddress(dto.Member.EPSIEmail);
                mail.To.Add(mailReciever);

                mail.Subject = PasswordBackupRessources.Subject;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                string url = string.Format(PasswordBackupRessources.Url, dao.Member.Username, dao.GeneratedKey);
                string message = string.Format(PasswordBackupRessources.Message, Environment.NewLine, url);
                mail.Body = message;

                SmtpClient smtp = new SmtpClient
                {
                    Credentials = new NetworkCredential(PasswordBackupRessources.Email, PasswordBackupRessources.Password),
                    Host = PasswordBackupRessources.Host,
                    Port = int.Parse(PasswordBackupRessources.Port),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true
                };

                smtp.Send(mail);
                smtp.Dispose();
            }

            return dto;
        }

        /// <summary>
        /// Set a new password after a lost password request
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="newPassword">Crypted new password</param>
        /// <param name="key">The generated key for lost password request</param>
        public void SetNewPasswordAfterLost(string username, string newPassword, string key)
        {
            _dal.SetNewPasswordAfterLost(username, newPassword, key);
        }

        #endregion

        #region ISearchable methods

        /// <summary>
        /// Get members corresponding to a keywords
        /// </summary>
        /// <param name="keywords">Search keywords separated by a space</param>
        /// <returns></returns>
        public IEnumerable<MemberDTO> Search(string keywords)
        {
            IEnumerable<MemberDAO> dao = _dal.Search(keywords);
            IEnumerable<MemberDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
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
        public int Add(MemberDTO element, string username, string password)
        {
            MemberDAO dao = _mapperMember.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a member
        /// </summary>
        /// <param name="element">Member conference</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(MemberDTO element, string username, string password)
        {
            MemberDAO dao = _mapperMember.ToDAO(element);
            _dal.Edit(dao, username, password);
        }

        /// <summary>
        /// Delete a member
        /// </summary>
        /// <param name="code">Member id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            _dal.Delete(code, username, password);
        }

        #endregion
    }
}