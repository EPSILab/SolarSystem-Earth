using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// Link rules checker
    /// </summary>
    class LinkRulesManager : IRulesManager<Link>
    {
        /// <summary>
        /// Check if a link is valid
        /// </summary>
        /// <param name="element">Link to check</param>
        public void Check(Link element)
        {
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages.Link_NoDescription);
            RulesChecker.CheckIsNotNull(element.ImageUrl, ErrorMessages.Link_NoPicture);
            RulesChecker.CheckIsNotNull(element.Label, ErrorMessages.Link_NoName);
        }
    }
}