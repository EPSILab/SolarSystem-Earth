using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using VilleDAO = SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = SolarSystem.Earth.Common.Ville;

namespace SolarSystem.Earth.Business
{
    public class VilleBusiness : IReader<VilleDTO>, IManager<VilleDTO>
    {
        #region Attributes

        private readonly VilleDAL _villeDAL = new VilleDAL();
        private readonly IMapper<VilleDAO, VilleDTO> _mapper = new VilleMapper();

        #endregion

        #region IReader methods

        public VilleDTO Get(int code)
        {
            VilleDAO dao = _villeDAL.Get(code);
            VilleDTO dto = _mapper.ToDTO(dao);
            return dto;
        }

        public IEnumerable<VilleDTO> Get()
        {
            IEnumerable<VilleDAO> dao = _villeDAL.Get();
            IEnumerable<VilleDTO> dto = dao.Select(v => _mapper.ToDTO(v));
            return dto;
        }

        #endregion

        #region IManager methods

        public IEnumerable<VilleDTO> Get(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IEnumerable<VilleDAO> dao = _villeDAL.Get(indexFirstResult, numberOfResults, username, password);
            IEnumerable<VilleDTO> dto = dao.Select(v => _mapper.ToDTO(v));
            return dto;
        }

        public VilleDTO Get(int code, string username, string password)
        {
            VilleDAO dao = _villeDAL.Get(code, username, password);
            VilleDTO dto = _mapper.ToDTO(dao);
            return dto;
        }

        public int Add(VilleDTO element, string username, string password)
        {
            VilleDAO dao = _mapper.ToDAO(element);
            return _villeDAL.Add(dao, username, password);
        }

        public void Edit(VilleDTO element, string username, string password)
        {
            VilleDAO dao = _mapper.ToDAO(element);
            _villeDAL.Edit(dao, username, password);
        }

        public void Delete(int code, string username, string password)
        {
            _villeDAL.Delete(code, username, password);
        }

        #endregion
    }
}