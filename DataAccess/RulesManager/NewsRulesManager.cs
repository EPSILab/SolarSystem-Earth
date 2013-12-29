using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class NewsRulesManager : IRulesManager<News>
    {
        public void Check(News element)
        {
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages_FR.NEWS_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Mots_Cles, ErrorMessages_FR.NEWS_AUCUN_MOT_CLE);
            RulesChecker.CheckIsNotNull(element.Texte_Court, ErrorMessages_FR.NEWS_AUCUNE_DESCRIPTION);
            RulesChecker.CheckIsNotNull(element.Texte_Long, ErrorMessages_FR.NEWS_AUCUN_CONTENU);
            RulesChecker.CheckIsNotNull(element.Titre, ErrorMessages_FR.NEWS_AUCUN_TITRE);
            RulesChecker.CheckIsNotNull(element.URL, ErrorMessages_FR.NEWS_AUCUNE_URL);

            RulesChecker.CheckIsNotNull(element.Code_Membre, ErrorMessages_FR.NEWS_AUCUN_MEMBRE);
        }
    }
}
