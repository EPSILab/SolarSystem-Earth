using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// Shows rules checker
    /// </summary>
    class ShowRulesManager : IRulesManager<Show>
    {
        /// /// <summary>
        /// Check if a show is valid
        /// </summary>
        /// <param name="element">Show to check</param>
        public void Check(Show element)
        {
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages.Show_NoDescription);
            RulesChecker.CheckIsNotNull(element.ImageUrl, ErrorMessages.Show_NoPicture);
            RulesChecker.CheckIsNotNull(element.Place, ErrorMessages.Show_NoPlace);
            RulesChecker.CheckIsNotNull(element.Name, ErrorMessages.Show_NoName);
            RulesChecker.CheckIsNotNull(element.Url, ErrorMessages.Show_NoUrl);
        }
    }
}