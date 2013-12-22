using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using ClasseDAO = SolarSystem.Earth.DataAccess.Model.Classe;
using ClasseDTO = SolarSystem.Earth.Common.Classe;

namespace SolarSystem.Earth.Business
{
    public class ClasseBusiness : IManager<ClasseDTO>
    {
        #region Attributes

        private readonly ClasseDAL _classeDAL = new ClasseDAL();
        private readonly IMapper<ClasseDAO, ClasseDTO> _mapper = new ClasseMapper();

        #endregion

        #region IManager methods

        public ClasseDTO Get(int code, string username, string password)
        {
            ClasseDAO dao = _classeDAL.Get(code, username, password);
            ClasseDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

        public IEnumerable<ClasseDTO> Get(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IEnumerable<ClasseDAO> dao = _classeDAL.Get(indexFirstResult, numberOfResults, username, password);
            IEnumerable<ClasseDTO> dto = dao.Select(c => _mapper.ToDTO(c));

            return dto;
        }

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