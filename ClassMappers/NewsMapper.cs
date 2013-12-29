using SolarSystem.Earth.Common.Interfaces;
using NewsDAO = SolarSystem.Earth.DataAccess.Model.News;
using NewsDTO = SolarSystem.Earth.Common.News;

namespace SolarSystem.Earth.Mappers
{
    public class NewsMapper : IMapper<NewsDAO, NewsDTO>
    {
        public NewsDTO ToDTO(NewsDAO element)
        {
            return new NewsDTO
            {
                Code_News = element.Code_News,
                Titre = element.Titre,
                Texte_Court = element.Texte_Court,
                Texte_Long = element.Texte_Long,
                Date_Heure = element.Date_Heure,
                Image = element.Image,
                Mots_Cles = element.Mots_Cles,
                Publiee = element.Publiee,
                URL = element.URL,
                Membre = new MembreMapper().ToDTO(element.Membre)
            };
        }

        public NewsDAO ToDAO(NewsDTO element)
        {
            return new NewsDAO
            {
                Code_Membre = element.Membre.Code_Membre,
                Code_News = element.Code_News,
                Date_Heure = element.Date_Heure,
                Image = element.Image,
                Mots_Cles = element.Mots_Cles,
                Texte_Court = element.Texte_Court,
                Texte_Long = element.Texte_Long,
                Titre = element.Titre,
                Publiee = element.Publiee,
                URL = element.URL
            };
        }
    }
}
