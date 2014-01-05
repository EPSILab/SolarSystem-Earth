using System;
using System.Collections.Generic;
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
using VilleDAO = SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = SolarSystem.Earth.Common.Ville;

namespace SolarSystem.Earth.Business
{
    public class MembreBusiness : IMembreReader<MembreDTO, VilleDTO>, IManager<MembreDTO>, ISearchable<MembreDTO>, ILogin<MembreDTO, RecupMotDePasseDTO>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        private readonly IMapper<MembreDAO, MembreDTO> _mapperMembre = new MembreMapper();
        private readonly IMapper<VilleDAO, VilleDTO> _mapperVille = new VilleMapper();

        #endregion

        #region IMembreReader methods

        public MembreDTO Get(int code)
        {
            MembreDAO dao = _membreDAL.Get(code);
            MembreDTO dto = _mapperMembre.ToDTO(dao);

            return dto;
        }

        public IEnumerable<MembreDTO> Get()
        {
            IEnumerable<MembreDAO> dao = _membreDAL.Get();
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMembre.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> GetBureauAndMembresActives()
        {
            IEnumerable<MembreDAO> dao = _membreDAL.GetBureauAndMembresActives();
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMembre.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> GetBureauAndMembresActives(VilleDTO ville)
        {
            VilleDAO villeDao = _mapperVille.ToDAO(ville);

            IEnumerable<MembreDAO> dao = _membreDAL.GetBureauAndMembresActives(villeDao);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMembre.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> GetBureau()
        {
            IEnumerable<MembreDAO> dao = _membreDAL.GetBureau();
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMembre.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> GetBureau(VilleDTO ville)
        {
            VilleDAO villeDao = _mapperVille.ToDAO(ville);

            IEnumerable<MembreDAO> dao = _membreDAL.GetBureau(villeDao);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMembre.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> GetMembresActives(VilleDTO ville)
        {
            VilleDAO villeDao = _mapperVille.ToDAO(ville);

            IEnumerable<MembreDAO> dao = _membreDAL.GetMembresActives(villeDao);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMembre.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> GetAlumnis()
        {
            IEnumerable<MembreDAO> dao = _membreDAL.GetAlumnis();
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMembre.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> GetAlumnis(VilleDTO ville)
        {
            VilleDAO villeDao = _mapperVille.ToDAO(ville);

            IEnumerable<MembreDAO> dao = _membreDAL.GetAlumnis(villeDao);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMembre.ToDTO(m));

            return dto;
        }

        public IEnumerable<MembreDTO> GetWaitingForValidation()
        {
            IEnumerable<MembreDAO> dao = _membreDAL.GetWaitingForValidation();
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMembre.ToDTO(m));

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
            MembreDAO dao = _mapperMembre.ToDAO(element);
            return _membreDAL.Add(dao, username, password);
        }

        public void Edit(MembreDTO element, string username, string password)
        {
            MembreDAO dao = _mapperMembre.ToDAO(element);
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
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapperMembre.ToDTO(m));

            return dto;
        }

        #endregion

        #region ILogin methods

        public MembreDTO Login(string username, string password)
        {
            MembreDAO dao = _membreDAL.Login(username, password);
            MembreDTO dto = _mapperMembre.ToDTO(dao);
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
            MembreDAO dao = _mapperMembre.ToDAO(membre);
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