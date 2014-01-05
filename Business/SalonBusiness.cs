using System.Collections.Generic;
using System.Linq;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using SalonDAO = SolarSystem.Earth.DataAccess.Model.Salon;
using SalonDTO = SolarSystem.Earth.Common.Salon;

namespace SolarSystem.Earth.Business
{
    public class SalonBusiness : IReader1Filter<SalonDTO, bool?>, ISearchable<SalonDTO>, IManager<SalonDTO>
    {
        #region Attributes

        private readonly SalonDAL _salonDAL = new SalonDAL();
        private readonly IMapper<SalonDAO, SalonDTO> _mapper = new SalonMapper();

        #endregion

        #region IReader1Filter methods

        public SalonDTO Get(int code)
        {
            SalonDAO dao = _salonDAL.Get(code);
            SalonDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

        public IEnumerable<SalonDTO> Get()
        {
            IEnumerable<SalonDAO> dao = _salonDAL.Get();
            IEnumerable<SalonDTO> dto = dao.Select(s => _mapper.ToDTO(s));

            return dto;
        }

        public IEnumerable<SalonDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<SalonDAO> dao = _salonDAL.Get(indexFirstElement, numberOfResults);
            IEnumerable<SalonDTO> dto = dao.Select(s => _mapper.ToDTO(s));

            return dto;
        }

        public IEnumerable<SalonDTO> Get(bool? published)
        {
            IEnumerable<SalonDAO> dao = _salonDAL.Get(published);
            IEnumerable<SalonDTO> dto = dao.Select(s => _mapper.ToDTO(s));

            return dto;
        }

        public IEnumerable<SalonDTO> Get(bool? published, int indexFirstResult, int numberOfResults)
        {
            IEnumerable<SalonDAO> dao = _salonDAL.Get(published, indexFirstResult, numberOfResults);
            IEnumerable<SalonDTO> dto = dao.Select(s => _mapper.ToDTO(s));

            return dto;
        }

        public int GetLastInsertedId()
        {
            return _salonDAL.GetLastInsertedId();
        }

        #endregion

        #region ISearchable methods

        public IEnumerable<SalonDTO> Search(string keyword)
        {
            IEnumerable<SalonDAO> dao = _salonDAL.Search(keyword);
            IEnumerable<SalonDTO> dto = dao.Select(s => _mapper.ToDTO(s));

            return dto;
        }

        #endregion

        #region IManager methods

        public int Add(SalonDTO element, string username, string password)
        {
            SalonDAO dao = _mapper.ToDAO(element);
            return _salonDAL.Add(dao, username, password);
        }

        public void Edit(SalonDTO element, string username, string password)
        {
            SalonDAO dao = _mapper.ToDAO(element);
            _salonDAL.Edit(dao, username, password);
        }

        public void Delete(int code, string username, string password)
        {
            _salonDAL.Delete(code, username, password);
        }

        #endregion
    }
}