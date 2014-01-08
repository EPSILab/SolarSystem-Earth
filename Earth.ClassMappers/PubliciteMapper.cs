using SolarSystem.Earth.Common.Interfaces;
using PubliciteDAO = SolarSystem.Earth.DataAccess.Model.Publicite;
using PubliciteDTO = SolarSystem.Earth.Common.Publicite;

namespace SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Advertising mapper
    /// </summary>
    public class PubliciteMapper : IMapper<PubliciteDAO, PubliciteDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public PubliciteDTO ToDTO(PubliciteDAO element)
        {
            return new PubliciteDTO
            {
                Code_Publicite = element.Code_Publicite,
                Nom = element.Nom,
                Image = element.Image,
                Presentation = element.Presentation,
                URL = element.URL,
                Publiee = element.Publiee
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public PubliciteDAO ToDAO(PubliciteDTO element)
        {
            return new PubliciteDAO
            {
                Code_Publicite = element.Code_Publicite,
                Image = element.Image,
                Nom = element.Nom,
                Presentation = element.Presentation,
                URL = element.URL,
                Publiee = element.Publiee
            };
        }
    }
}