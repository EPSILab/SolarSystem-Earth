using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using LienDAO = SolarSystem.Earth.DataAccess.Model.Lien;
using LienDTO = SolarSystem.Earth.Common.Lien;

namespace SolarSystem.Earth.Business
{
    public class LienBusiness : IReader<LienDTO>, IManager<LienDTO>
    {
        #region Attributes

        private readonly LienDAL _lienDAL = new LienDAL();
        private readonly IMapper<LienDAO, LienDTO> _mapper = new LienMapper();

        #endregion

        #region IReader methods

        public LienDTO Get(int code)
        {
            LienDAO dao = _lienDAL.Get(code);
            LienDTO dto = _mapper.ToDTO(dao);
            return dto;
        }

        public IEnumerable<LienDTO> Get()
        {
            IEnumerable<LienDAO> dao = _lienDAL.Get();
            IEnumerable<LienDTO> dto = dao.Select(l => _mapper.ToDTO(l));

            return dto;
        }

        #endregion

        #region IManager methods

        public IEnumerable<LienDTO> Get(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IEnumerable<LienDAO> dao = _lienDAL.Get(indexFirstResult, numberOfResults, username, password);
            IEnumerable<LienDTO> dto = dao.Select(l => _mapper.ToDTO(l));

            return dto;
        }

        public LienDTO Get(int code, string username, string password)
        {
            LienDAO dao = _lienDAL.Get(code, username, password);
            LienDTO dto = _mapper.ToDTO(dao);
            return dto;
        }

        public int Add(LienDTO element, string username, string password)
        {
            LienDAO dao = _mapper.ToDAO(element);
            return _lienDAL.Add(dao, username, password);
        }

        public void Edit(LienDTO element, string username, string password)
        {
            LienDAO dao = _mapper.ToDAO(element);
            _lienDAL.Edit(dao, username, password);
        }

        public void Delete(int code, string username, string password)
        {
            _lienDAL.Delete(code, username, password);
        }

        #endregion
    }
}