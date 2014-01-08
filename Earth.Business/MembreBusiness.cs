using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DAL;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using MembreDAO = SolarSystem.Earth.DataAccess.Model.Membre;
using MembreDTO = SolarSystem.Earth.Common.Membre;
using RecupMotDePasseDAO = SolarSystem.Earth.DataAccess.Model.RecupMotDePasse;
using RecupMotDePasseDTO = SolarSystem.Earth.Common.RecupMotDePasse;
using VilleDAO = SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = SolarSystem.Earth.Common.Ville;

namespace SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for members
    /// </summary>
    public class MembreBusiness : IMembreReader<MembreDTO, VilleDTO>, IManager<MembreDTO>, ISearchable<MembreDTO>, ILogin<MembreDTO, RecupMotDePasseDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly MembreDAL _dal = new MembreDAL();

        /// <summary>
        /// Member mapper
        /// </summary>
        private readonly IMapper<MembreDAO, MembreDTO> _mapperMember = new MembreMapper();

        /// <summary>
        /// City mapper
        /// </summary>
        private readonly IMapper<VilleDAO, VilleDTO> _mapperCity = new VilleMapper();

        #endregion

        #region IMembreReader methods

        /// <summary>
        /// Get a member
        /// </summary>
        /// <param name="code">Member id</param>
        /// <returns>Matching member</returns>
        public MembreDTO Get(int code)
        {
            MembreDAO dao = _dal.Get(code);
            MembreDTO dto = _mapperMember.ToDTO(dao);

            return dto;
        }

        /// <summary>
        /// Get all members
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<MembreDTO> Get()
        {
            IEnumerable<MembreDAO> dao = _dal.Get();
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get all bureau members
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<MembreDTO> GetBureau()
        {
            IEnumerable<MembreDAO> dao = _dal.GetBureau();
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get bureau members of a city
        /// </summary>
        /// <param name="ville">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<MembreDTO> GetBureau(VilleDTO ville)
        {
            VilleDAO villeDao = _mapperCity.ToDAO(ville);

            IEnumerable<MembreDAO> dao = _dal.GetBureau(villeDao);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get actives members of a city
        /// </summary>
        /// <param name="ville">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<MembreDTO> GetMembresActives(VilleDTO ville)
        {
            VilleDAO villeDao = _mapperCity.ToDAO(ville);

            IEnumerable<MembreDAO> dao = _dal.GetMembresActives(villeDao);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get bureau and actives members
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<MembreDTO> GetBureauAndMembresActives()
        {
            IEnumerable<MembreDAO> dao = _dal.GetBureauAndMembresActives();
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get bureau and actives members of a city
        /// </summary>
        /// <param name="ville">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<MembreDTO> GetBureauAndMembresActives(VilleDTO ville)
        {
            VilleDAO villeDao = _mapperCity.ToDAO(ville);

            IEnumerable<MembreDAO> dao = _dal.GetBureauAndMembresActives(villeDao);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get all alumnis
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<MembreDTO> GetAlumnis()
        {
            IEnumerable<MembreDAO> dao = _dal.GetAlumnis();
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get alumnis of a city
        /// </summary>
        /// <param name="ville">Concerned city</param>
        /// <returns>List of members</returns>
        public IEnumerable<MembreDTO> GetAlumnis(VilleDTO ville)
        {
            VilleDAO villeDao = _mapperCity.ToDAO(ville);

            IEnumerable<MembreDAO> dao = _dal.GetAlumnis(villeDao);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

            return dto;
        }

        /// <summary>
        /// Get members waiting for an admin validation
        /// </summary>
        /// <returns>List of members</returns>
        public IEnumerable<MembreDTO> GetWaitingForValidation()
        {
            IEnumerable<MembreDAO> dao = _dal.GetWaitingForValidation();
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

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
        public MembreDTO Login(string username, string password)
        {
            MembreDAO dao = _dal.Login(username, password);
            MembreDTO dto = _mapperMember.ToDTO(dao);
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
        /// <param name="membre">Member to create</param>
        /// <returns>New member id</returns>
        public int Register(MembreDTO membre)
        {
            MembreDAO dao = _mapperMember.ToDAO(membre);
            return _dal.Register(dao);
        }

        /// <summary>
        /// Create a request to recover password
        /// </summary>
        /// <param name="username">Username for control</param>
        /// <param name="email">Email for control</param>
        /// <returns>Password recover informations</returns>
        public RecupMotDePasseDTO RequestLostPassword(string username, string email)
        {
            IMapper<RecupMotDePasseDAO, RecupMotDePasseDTO> mapper = new RecupMotDePasseMapper();
            RecupMotDePasseDAO dao = _dal.RequestLostPassword(username, email);
            RecupMotDePasseDTO dto = mapper.ToDTO(dao);

            using (MailMessage mail = new MailMessage())
            {
                MailAddress mailReciever = new MailAddress(dto.Membre.Email_EPSI);
                mail.To.Add(mailReciever);

                mail.Subject = PasswordBackupRessources.Subject;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                string url = string.Format(PasswordBackupRessources.Url, dao.Membre.Pseudo, dao.Cle);
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
        public IEnumerable<MembreDTO> Search(string keywords)
        {
            IEnumerable<MembreDAO> dao = _dal.Search(keywords);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMember.ToDTO(m));

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
        public int Add(MembreDTO element, string username, string password)
        {
            MembreDAO dao = _mapperMember.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a member
        /// </summary>
        /// <param name="element">Member conference</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(MembreDTO element, string username, string password)
        {
            MembreDAO dao = _mapperMember.ToDAO(element);
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