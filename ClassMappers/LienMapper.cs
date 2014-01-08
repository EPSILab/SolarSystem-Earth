using SolarSystem.Earth.Common.Interfaces;
using LienDAO = SolarSystem.Earth.DataAccess.Model.Lien;
using LienDTO = SolarSystem.Earth.Common.Lien;

namespace SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Link mapper
    /// </summary>
    public class LienMapper : IMapper<LienDAO, LienDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public LienDTO ToDTO(LienDAO element)
        {
            return new LienDTO
            {
                Code_Lien = element.Code_Lien,
                Nom = element.Nom,
                URL = element.URL,
                Image = element.Image,
                Description = element.Description
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public LienDAO ToDAO(LienDTO element)
        {
            return new LienDAO
            {
                Code_Lien = element.Code_Lien,
                Description = element.Description,
                Image = element.Image,
                Nom = element.Nom,
                URL = element.URL
            };
        }
    }
}