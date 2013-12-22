using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using MembreDAO = SolarSystem.Earth.DataAccess.Model.Membre;
using MembreDTO = SolarSystem.Earth.Common.Membre;
using RoleDAO = SolarSystem.Earth.DataAccess.Model.Role;
using RoleDTO = SolarSystem.Earth.Common.Role;
using VilleDAO = SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = SolarSystem.Earth.Common.Ville;

namespace SolarSystem.Earth.Business
{
    public class MembreBusiness : IReaderTwoFilters<MembreDTO, VilleDTO, RoleDTO>, IManager<MembreDTO>, ISearchable<MembreDTO>, ILogin
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();
        private readonly VilleDAL _villeDAL = new VilleDAL();
        private readonly  RoleDAL _roleDAL = new RoleDAL();
        private readonly IMapper<MembreDAO, MembreDTO> _mapper = new MembreMapper();

        #endregion

        #region IReaderTwoFilters methods

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
            VilleDAO villeDao = null;

            if (ville != null)
            {
                villeDao = _villeDAL.Get(ville.Code_Ville);
            }

            RoleDAO roleDao = null;

            if (role != null)
            {
                roleDao = _roleDAL.Get(role.Code_Role);
            }

            IEnumerable<MembreDAO> dao = _membreDAL.Get(villeDao, roleDao, indexFirstElement, numberOfResults, order);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapper.ToDTO(m));

            return dto;
        }

        public int GetLastInsertedId()
        {
            return _membreDAL.GetLastInsertedId();
        }

        #endregion

        #region IManager methods

        public IEnumerable<MembreDTO> Get(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IEnumerable<MembreDAO> dao = _membreDAL.Get(indexFirstResult, numberOfResults, username, password);
            IEnumerable<MembreDTO> dto = dao.Select(m => _mapper.ToDTO(m));

            return dto;
        }

        public MembreDTO Get(int code, string username, string password)
        {
            MembreDAO dao = _membreDAL.Get(code, username, password);
            MembreDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

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

        public int Login(string username, string password)
        {
            return _membreDAL.Login(username, password);
        }

        public bool Exists(string username, string password)
        {
            return _membreDAL.Exists(username, password);
        }

        #endregion
    }
}