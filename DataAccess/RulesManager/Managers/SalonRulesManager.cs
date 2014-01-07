using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// Shows rules checker
    /// </summary>
    class SalonRulesManager : IRulesManager<Salon>
    {
        /// /// <summary>
        /// Check if a show is valid
        /// </summary>
        /// <param name="element">Show to check</param>
        public void Check(Salon element)
        {
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages.SALON_AUCUNE_DESCRIPTION);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.SALON_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Lieu, ErrorMessages.SALON_AUCUN_LIEU);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.SALON_AUCUN_NOM);
            RulesChecker.CheckIsNotNull(element.URL, ErrorMessages.SALON_AUCUNE_URL);
        }
    }
}