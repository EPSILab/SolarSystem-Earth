using SolarSystem.Earth.Common.Interfaces;
using ConferenceDAO = SolarSystem.Earth.DataAccess.Model.Conference;
using ConferenceDTO = SolarSystem.Earth.Common.Conference;

namespace SolarSystem.Earth.Mappers
{
    public class ConferenceMapper : IMapper<ConferenceDAO, ConferenceDTO>
    {
        public ConferenceDTO ToDTO(ConferenceDAO element)
        {
            return new ConferenceDTO
            {
                Code_Conference = element.Code_Conference,
                Nom = element.Nom,
                Date_Heure_Debut = element.Date_Heure_Debut,
                Date_Heure_Fin = element.Date_Heure_Fin,
                Description = element.Description,
                Lieu = element.Lieu,
                Image = element.Image,
                Publiee = element.Publiee,
                URL = element.URL,
                Ville = new VilleMapper().ToDTO(element.Ville)
            };
        }

        public ConferenceDAO ToDAO(ConferenceDTO element)
        {
            return new ConferenceDAO
            {
                Code_Conference = element.Code_Conference,
                Code_Ville = element.Ville.Code_Ville,
                Date_Heure_Debut = element.Date_Heure_Debut,
                Date_Heure_Fin = element.Date_Heure_Fin,
                Description = element.Description,
                Lieu = element.Lieu,
                Nom = element.Nom,
                Image = element.Image,
                Publiee = element.Publiee,
                URL = element.URL
            };
        }
    }
}