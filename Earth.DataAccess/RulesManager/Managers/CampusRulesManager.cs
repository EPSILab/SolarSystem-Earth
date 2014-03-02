using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// City rules checker
    /// </summary>
    class CampusRulesManager : IRulesManager<Campus>
    {
        /// /// <summary>
        /// Check if a city is valid
        /// </summary>
        /// <param name="element">City to check</param>
        public void Check(Campus element)
        {
            RulesChecker.CheckIsNotNull(element.Place, ErrorMessages.City_NoName);
        }
    }
}