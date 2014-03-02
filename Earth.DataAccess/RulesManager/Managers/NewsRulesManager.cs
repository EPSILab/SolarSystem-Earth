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
            RulesChecker.CheckIsNotNull(element.ImageUrl, ErrorMessages.News_NoPicture);
            RulesChecker.CheckIsNotNull(element.Keywords, ErrorMessages.News_NoKeywords);
            RulesChecker.CheckIsNotNull(element.ShortText, ErrorMessages.News_NoDescription);
            RulesChecker.CheckIsNotNull(element.Text, ErrorMessages.News_NoContent);
            RulesChecker.CheckIsNotNull(element.Title, ErrorMessages.News_NoTitle);
            RulesChecker.CheckIsNotNull(element.Url, ErrorMessages.News_NoUrl);

            RulesChecker.CheckIsNotNull(element.Id, ErrorMessages.News_NoAuthor);
        }
    }
}