using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// Link rules checker
    /// </summary>
    class LienRulesManager : IRulesManager<Lien>
    {
        /// <summary>
        /// Check if a link is valid
        /// </summary>
        /// <param name="element">Link to check</param>
        public void Check(Lien element)
        {
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages.Link_NoDescription);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.Link_NoPicture);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.Link_NoName);
        }
    }
}