using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using RoleDAO = SolarSystem.Earth.DataAccess.Model.Role;
using RoleDTO = SolarSystem.Earth.Common.Role;

namespace SolarSystem.Earth.Business
{
    public class RoleBusiness : IReader<RoleDTO>
    {
        #region Attributes

        private readonly RoleDAL _roleDAL = new RoleDAL();
        private readonly IMapper<RoleDAO, RoleDTO> _mapper = new RoleMapper();

        #endregion

        #region IReader methods

        public RoleDTO Get(int code)
        {
            RoleDAO dao = _roleDAL.Get(code);
            RoleDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

        public IEnumerable<RoleDTO> Get()
        {
            IEnumerable<RoleDAO> dao = _roleDAL.Get();
            IEnumerable<RoleDTO> dto = dao.Select(r => _mapper.ToDTO(r));

            return dto;
        }

        #endregion
    }
}