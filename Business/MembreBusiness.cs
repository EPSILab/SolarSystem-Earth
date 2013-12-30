using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.Mappers;
using MembreDAO = SolarSystem.Earth.DataAccess.Model.Membre;
using MembreDTO = SolarSystem.Earth.Common.Membre;
using RecupMotDePasseDAO = SolarSystem.Earth.DataAccess.Model.RecupMotDePasse;
using RecupMotDePasseDTO = SolarSystem.Earth.Common.RecupMotDePasse;
using RoleDAO = SolarSystem.Earth.DataAccess.Model.Role;
using RoleDTO = SolarSystem.Earth.Common.Role;
using VilleDAO = SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = SolarSystem.Earth.Common.Ville;

namespace SolarSystem.Earth.Business
{
    public class MembreBusiness : IReader4Filters<MembreDTO, VilleDTO, RoleDTO, bool, bool>, IManager<MembreDTO>, ISearchable<MembreDTO>, ILogin<MembreDTO, RecupMotDePasseDTO>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();
        private readonly VilleDAL _villeDAL = new VilleDAL();
        private readonly RoleDAL _roleDAL = new RoleDAL();
        private readonly IMapper<MembreDAO, MembreDTO> _mapper = new MembreMapper();

        #endregion

        #region IReader2Filters methods

        public MembreDTO Get(int code)
        {
            MembreDAO dao = _membreDAL.Get(code);
            MembreDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

        public IEnumerable<MembreDTO> Get()
        {
            IEnumerable<MembreDAO> dao = _membreDAL.Get();
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapper.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<MembreDAO> dao = _membreDAL.Get(indexFirstElement, numberOfResults);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapper.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> Get(int indexFirstElement, int numberOfResults, SortOrder order)
        {
            IEnumerable<MembreDAO> dao = _membreDAL.Get(indexFirstElement, numberOfResults, order);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapper.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> Get(VilleDTO ville, RoleDTO role, int indexFirstElement, int numberOfResults, SortOrder order)
        {
            VilleDAO villeDao = ville != null ? _villeDAL.Get(ville.Code_Ville) : null;
            RoleDAO roleDao = (role != null) ? _roleDAL.Get(role.Code_Role) : null;

            IEnumerable<MembreDAO> dao = _membreDAL.Get(villeDao, roleDao, indexFirstElement, numberOfResults, order);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapper.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> Get(VilleDTO ville, RoleDTO role, bool actifs, int indexFirstElement, int numberOfResults, SortOrder order)
        {
            VilleDAO villeDao = ville != null ? _villeDAL.Get(ville.Code_Ville) : null;
            RoleDAO roleDao = (role != null) ? _roleDAL.Get(role.Code_Role) : null;

            IEnumerable<MembreDAO> dao = _membreDAL.Get(villeDao, roleDao, actifs, indexFirstElement, numberOfResults, order);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapper.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> Get(VilleDTO ville, RoleDTO role, bool actifs, bool encorePresents, int indexFirstElement, int numberOfResults, SortOrder order)
        {
            VilleDAO villeDao = ville != null ? _villeDAL.Get(ville.Code_Ville) : null;
            RoleDAO roleDao = (role != null) ? _roleDAL.Get(role.Code_Role) : null;

            IEnumerable<MembreDAO> dao = _membreDAL.Get(villeDao, roleDao, actifs, encorePresents, indexFirstElement, numberOfResults, order);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapper.ToDTO(m));

            return dto;
        }

        public int GetLastInsertedId()
        {
            return _membreDAL.GetLastInsertedId();
        }

        #endregion

        #region IManager methods

        public int Add(MembreDTO element, string username, string password)
        {
            MembreDAO dao = _mapper.ToDAO(element);
            return _membreDAL.Add(dao, username, password);
        }

        public void Edit(MembreDTO element, string username, string password)
        {
            MembreDAO dao = _mapper.ToDAO(element);
            _membreDAL.Edit(dao, username, password);
        }

        public void Delete(int code, string username, string password)
        {
            _membreDAL.Delete(code, username, password);
        }

        #endregion

        #region ISearchable methods

        public IEnumerable<MembreDTO> Search(string keywords)
        {
            IEnumerable<MembreDAO> dao = _membreDAL.Search(keywords);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapper.ToDTO(m));

            return dto;
        }

        #endregion

        #region ILogin methods

        public MembreDTO Login(string username, string password)
        {
            MembreDAO dao = _membreDAL.Login(username, password);
            MembreDTO dto = _mapper.ToDTO(dao);
            return dto;
        }

        public void ChangePassword(string username, string oldPassword, string newPassword)
        {
            _membreDAL.ChangePassword(username, oldPassword, newPassword);
        }

        public bool Exists(string username, string password)
        {
            return _membreDAL.Exists(username, password);
        }

        public bool Exists(string username)
        {
            return _membreDAL.Exists(username);
        }

        public int Register(MembreDTO membre)
        {
            MembreDAO dao = _mapper.ToDAO(membre);
            return _membreDAL.Register(dao);
        }

        public RecupMotDePasseDTO RequestLostPassword(string username, string email)
        {
            IMapper<RecupMotDePasseDAO, RecupMotDePasseDTO> mapper = new RecupMotDePasseMapper();
            RecupMotDePasseDAO dao = _membreDAL.RequestLostPassword(username, email);
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

        public void SetNewPasswordAfterLost(string username, string newPassword, string key)
        {
            _membreDAL.SetNewPasswordAfterLost(username, newPassword, key);
        }

        #endregion
    }
}