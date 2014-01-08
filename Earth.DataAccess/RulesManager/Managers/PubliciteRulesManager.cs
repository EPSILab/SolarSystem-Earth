using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// Advertising rules checker
    /// </summary>
    class PubliciteRulesManager : IRulesManager<Publicite>
    {
        /// /// <summary>
        /// Check if a advertising is valid
        /// </summary>
        /// <param name="element">Advertising to check</param>
        public void Check(Publicite element)
        {
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.Advertising_NoPicture);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.Advertising_NoName);
            RulesChecker.CheckIsNotNull(element.Presentation, ErrorMessages.Advertising_NoPresentation);
        }
    }
}