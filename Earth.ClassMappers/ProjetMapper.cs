using EPSILab.SolarSystem.Earth.Common.Interfaces;
using ProjetDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Projet;
using ProjetDTO = EPSILab.SolarSystem.Earth.Common.Projet;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Project mapper
    /// </summary>
    public class ProjetMapper : IMapper<ProjetDAO, ProjetDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
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

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public ProjetDAO ToDAO(ProjetDTO element)
        {
            return new ProjetDAO
            {
                Avancement = element.Avancement,
                Code_Projet = element.Code_Projet,
                Code_Ville = element.Ville.Code_Ville,
                Description = element.Description,
                Nom = element.Nom,
                Image = element.Image
            };
        }
    }
}