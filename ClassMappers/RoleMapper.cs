using SolarSystem.Earth.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using RoleDAO = SolarSystem.Earth.DataAccess.Model.Role;
using RoleDTO = SolarSystem.Earth.Common.Role;

namespace SolarSystem.Earth.Mappers
{
    public class RoleMapper : IMapper<RoleDAO, RoleDTO>
    {
        public RoleDTO ToDTO(RoleDAO element)
        {
            return new RoleDTO
            {
                Code_Role = element.Code_Role,
                Libelle = element.Libelle
            };
        }

        public IEnumerable<RoleDTO> ToDTO(IEnumerable<RoleDAO> elements)
        {
            return elements.Select(ToDTO);
        }

        public RoleDAO ToDAO(RoleDTO element)
        {
            return new RoleDAO
                {
                    Code_Role = element.Code_Role,
                    Libelle = element.Libelle
                };
        }
    }
}