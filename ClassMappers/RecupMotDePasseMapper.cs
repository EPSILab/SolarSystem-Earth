using SolarSystem.Earth.Common.Interfaces;
using RecupMotDePasseDAO = SolarSystem.Earth.DataAccess.Model.RecupMotDePasse;
using RecupMotDePasseDTO = SolarSystem.Earth.Common.RecupMotDePasse;

namespace SolarSystem.Earth.Mappers
{
    public class RecupMotDePasseMapper : IMapper<RecupMotDePasseDAO, RecupMotDePasseDTO>
    {
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