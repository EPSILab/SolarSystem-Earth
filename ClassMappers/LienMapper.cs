using SolarSystem.Earth.Common.Interfaces;
using LienDAO = SolarSystem.Earth.DataAccess.Model.Lien;
using LienDTO = SolarSystem.Earth.Common.Lien;

namespace SolarSystem.Earth.Mappers
{
    public class LienMapper : IMapper<LienDAO, LienDTO>
    {
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