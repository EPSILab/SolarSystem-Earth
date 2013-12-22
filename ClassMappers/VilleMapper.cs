using SolarSystem.Earth.Common.Interfaces;
using VilleDAO = SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = SolarSystem.Earth.Common.Ville;

namespace SolarSystem.Earth.Mappers
{
    public class VilleMapper : IMapper<VilleDAO, VilleDTO>
    {
        public VilleDTO ToDTO(VilleDAO element)
        {
            return new VilleDTO
            {
                Code_Ville = element.Code_Ville,
                Libelle = element.Libelle,
                Email = element.Email
            };
        }

        public VilleDAO ToDAO(VilleDTO element)
        {
            return new VilleDAO
            {
                Code_Ville = element.Code_Ville,
                Email = element.Email,
                Libelle = element.Libelle
            };
        }
    }
}