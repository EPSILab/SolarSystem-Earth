using System.Collections.Generic;
using System.Linq;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using ClasseDAO = SolarSystem.Earth.DataAccess.Model.Classe;
using ClasseDTO = SolarSystem.Earth.Common.Classe;

namespace SolarSystem.Earth.Business
{
    public class ClasseBusiness : IReader<ClasseDTO>, IAvailable<ClasseDTO>, IManager<ClasseDTO>
    {
        #region Attributes

        private readonly ClasseDAL _classeDAL = new ClasseDAL();
        private readonly IMapper<ClasseDAO, ClasseDTO> _mapper = new ClasseMapper();

        #endregion

        #region IReader methods

        public ClasseDTO Get(int code)
        {
            ClasseDAO dao = _classeDAL.Get(code);
            ClasseDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

        public IEnumerable<ClasseDTO> Get()
        {
            IEnumerable<ClasseDAO> dao = _classeDAL.Get();
            IEnumerable<ClasseDTO> dto = dao.Select(c => _mapper.ToDTO(c));

            return dto;
        }

        public int GetLastInsertedId()
        {
            return _classeDAL.GetLastInsertedId();
        }

        #endregion

        #region IAvailable methods

        public IEnumerable<ClasseDTO> GetAvailables()
        {
            IEnumerable<ClasseDAO> dao = _classeDAL.GetAvailables();
            IEnumerable<ClasseDTO> dto = dao.Select(c => _mapper.ToDTO(c));

            return dto;
        }

        #endregion

        #region IManager methods

        public int Add(ClasseDTO element, string username, string password)
        {
            ClasseDAO dao = _mapper.ToDAO(element);
            return _classeDAL.Add(dao, username, password);
        }

        public void Edit(ClasseDTO element, string username, string password)
        {
            ClasseDAO dao = _mapper.ToDAO(element);
            _classeDAL.Edit(dao, username, password);
        }

        public void Delete(int code, string username, string password)
        {
            _classeDAL.Delete(code, username, password);
        }

        #endregion
    }
}