using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// City rules checker
    /// </summary>
    class VilleRulesManager : IRulesManager<Ville>
    {
        /// /// <summary>
        /// Check if a city is valid
        /// </summary>
        /// <param name="element">City to check</param>
        public void Check(Ville element)
        {
            RulesChecker.CheckIsNotNull(element.Libelle, ErrorMessages.City_NoName);
        }
    }
}