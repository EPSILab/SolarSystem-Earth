using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// Promo rules checker
    /// </summary>
    class ClasseRulesManager : IRulesManager<Classe>
    {
        /// <summary>
        /// Check if a promo is valid
        /// </summary>
        /// <param name="element">Promo to check</param>
        public void Check(Classe element)
        {
            const int yearEPSIFoundation = 1961;

            RulesChecker.CheckIsShorter(element.Annee_Promo_Sortante, yearEPSIFoundation, ErrorMessages.Promo_InvalidYear);
            RulesChecker.CheckIsNotNull(element.Libelle, ErrorMessages.Promo_NoName);
        }
    }
}