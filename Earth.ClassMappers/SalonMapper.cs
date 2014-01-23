using EPSILab.SolarSystem.Earth.Common.Interfaces;
using SalonDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Salon;
using SalonDTO = EPSILab.SolarSystem.Earth.Common.Salon;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Show mapper
    /// </summary>
    public class SalonMapper : IMapper<SalonDAO, SalonDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public SalonDTO ToDTO(SalonDAO element)
        {
            return new SalonDTO
            {
                Code_Salon = element.Code_Salon,
                Nom = element.Nom,
                Lieu = element.Lieu,
                Date_Heure_Debut = element.Date_Heure_Debut,
                Date_Heure_Fin = element.Date_Heure_Fin,
                Description = element.Description,
                Image = element.Image,
                Publie = element.Publie,
                URL = element.URL
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public SalonDAO ToDAO(SalonDTO element)
        {
            return new SalonDAO
            {
                Code_Salon = element.Code_Salon,
                Date_Heure_Debut = element.Date_Heure_Debut,
                Date_Heure_Fin = element.Date_Heure_Fin,
                Description = element.Description,
                Image = element.Image,
                Lieu = element.Lieu,
                Nom = element.Nom,
                Publie = element.Publie,
                URL = element.URL
            };
        }
    }
}