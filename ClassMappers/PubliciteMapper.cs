using SolarSystem.Earth.Common.Interfaces;
using PubliciteDAO = SolarSystem.Earth.DataAccess.Model.Publicite;
using PubliciteDTO = SolarSystem.Earth.Common.Publicite;

namespace SolarSystem.Earth.Mappers
{
    public class PubliciteMapper : IMapper<PubliciteDAO, PubliciteDTO>
    {
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
