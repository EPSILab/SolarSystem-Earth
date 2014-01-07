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
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.PUBLICITE_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.PUBLICITE_AUCUN_NOM);
            RulesChecker.CheckIsNotNull(element.Presentation, ErrorMessages.PUBLICITE_AUCUNE_PRESENTATION);
        }
    }
}