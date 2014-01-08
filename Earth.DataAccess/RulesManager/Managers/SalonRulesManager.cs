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
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages.Show_NoDescription);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.Show_NoPicture);
            RulesChecker.CheckIsNotNull(element.Lieu, ErrorMessages.Show_NoPlace);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.Show_NoName);
            RulesChecker.CheckIsNotNull(element.URL, ErrorMessages.Show_NoURL);
        }
    }
}