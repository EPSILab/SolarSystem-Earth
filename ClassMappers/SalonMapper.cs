using SolarSystem.Earth.Common.Interfaces;
using SalonDAO = SolarSystem.Earth.DataAccess.Model.Salon;
using SalonDTO = SolarSystem.Earth.Common.Salon;

namespace SolarSystem.Earth.Mappers
{
    public class SalonMapper : IMapper<SalonDAO, SalonDTO>
    {
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