using SolarSystem.Earth.Common.Interfaces;
using ProjetDAO = SolarSystem.Earth.DataAccess.Model.Projet;
using ProjetDTO = SolarSystem.Earth.Common.Projet;

namespace SolarSystem.Earth.Mappers
{
    public class ProjetMapper : IMapper<ProjetDAO, ProjetDTO>
    {
        public ProjetDTO ToDTO(ProjetDAO element)
        {
            return new ProjetDTO
            {
                Code_Projet = element.Code_Projet,
                Nom = element.Nom,
                Avancement = element.Avancement,
                Description = element.Description,
                Image = element.Image,
                Ville = new VilleMapper().ToDTO(element.Ville)
            };
        }

        public ProjetDAO ToDAO(ProjetDTO projet)
        {
            return new ProjetDAO
            {
                Avancement = projet.Avancement,
                Code_Projet = projet.Code_Projet,
                Code_Ville = projet.Ville.Code_Ville,
                Description = projet.Description,
                Nom = projet.Nom,
                Image = projet.Image
            };
        }
    }
}
