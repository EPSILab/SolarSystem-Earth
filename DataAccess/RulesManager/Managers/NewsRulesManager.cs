using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// News rules checker
    /// </summary>
    class NewsRulesManager : IRulesManager<News>
    {
        /// /// <summary>
        /// Check if a news is valid
        /// </summary>
        /// <param name="element">News to check</param>
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
