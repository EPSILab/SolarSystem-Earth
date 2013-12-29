using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class NewsRulesManager : IRulesManager<News>
    {
        public void Check(News element)
        {
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.NEWS_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Mots_Cles, ErrorMessages.NEWS_AUCUN_MOT_CLE);
            RulesChecker.CheckIsNotNull(element.Texte_Court, ErrorMessages.NEWS_AUCUNE_DESCRIPTION);
            RulesChecker.CheckIsNotNull(element.Texte_Long, ErrorMessages.NEWS_AUCUN_CONTENU);
            RulesChecker.CheckIsNotNull(element.Titre, ErrorMessages.NEWS_AUCUN_TITRE);
            RulesChecker.CheckIsNotNull(element.URL, ErrorMessages.NEWS_AUCUNE_URL);

            RulesChecker.CheckIsNotNull(element.Code_Membre, ErrorMessages.NEWS_AUCUN_MEMBRE);
        }
    }
}
