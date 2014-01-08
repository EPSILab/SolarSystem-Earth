using SolarSystem.Earth.Common.Interfaces;
using VilleDAO = SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = SolarSystem.Earth.Common.Ville;

namespace SolarSystem.Earth.Mappers
{
    /// <summary>
    /// City mapper
    /// </summary>
    public class VilleMapper : IMapper<VilleDAO, VilleDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public VilleDTO ToDTO(VilleDAO element)
        {
            return new VilleDTO
            {
                Code_Ville = element.Code_Ville,
                Libelle = element.Libelle,
                Email = element.Email
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
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