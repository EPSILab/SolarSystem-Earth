using EPSILab.SolarSystem.Earth.Common.Interfaces;
using RoleDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Role;
using RoleDTO = EPSILab.SolarSystem.Earth.Common.Role;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Role mapper
    /// </summary>
    public class RoleMapper : IMapper<RoleDAO, RoleDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public RoleDTO ToDTO(RoleDAO element)
        {
            return new RoleDTO
            {
                Code_Role = element.Code_Role,
                Libelle = element.Libelle
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
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