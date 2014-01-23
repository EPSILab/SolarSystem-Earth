using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers
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
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.News_NoPicture);
            RulesChecker.CheckIsNotNull(element.Mots_Cles, ErrorMessages.News_NoKeywords);
            RulesChecker.CheckIsNotNull(element.Texte_Court, ErrorMessages.News_NoDescription);
            RulesChecker.CheckIsNotNull(element.Texte_Long, ErrorMessages.News_NoContent);
            RulesChecker.CheckIsNotNull(element.Titre, ErrorMessages.News_NoTitle);
            RulesChecker.CheckIsNotNull(element.URL, ErrorMessages.News_NoURL);

            RulesChecker.CheckIsNotNull(element.Code_Membre, ErrorMessages.News_NoAuthor);
        }
    }
}