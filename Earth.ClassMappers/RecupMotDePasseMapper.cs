using SolarSystem.Earth.Common.Interfaces;
using RecupMotDePasseDAO = SolarSystem.Earth.DataAccess.Model.RecupMotDePasse;
using RecupMotDePasseDTO = SolarSystem.Earth.Common.RecupMotDePasse;

namespace SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Lost password request mapper
    /// </summary>
    public class RecupMotDePasseMapper : IMapper<RecupMotDePasseDAO, RecupMotDePasseDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public RecupMotDePasseDTO ToDTO(RecupMotDePasseDAO element)
        {
            return new RecupMotDePasseDTO
            {
                Cle = element.Cle,
                Date = element.Date,
                Id = element.Id,
                Membre = new MembreMapper().ToDTO(element.Membre)
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public RecupMotDePasseDAO ToDAO(RecupMotDePasseDTO element)
        {
            return new RecupMotDePasseDAO
            {
                Cle = element.Cle,
                Date = element.Date,
                Id = element.Id,
                Code_Membre = element.Membre.Code_Membre
            };
        }
    }
}