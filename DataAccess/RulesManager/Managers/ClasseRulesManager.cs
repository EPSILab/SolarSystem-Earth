using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace SolarSystem.Earth.DataAccess.RulesManager.Managers
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

            RulesChecker.CheckIsShorter(element.Annee_Promo_Sortante, yearEPSIFoundation, ErrorMessages.CLASSE_ANNEE_PROMO_INVALIDE);
            RulesChecker.CheckIsNotNull(element.Libelle, ErrorMessages.CLASSE_AUCUN_LIBELLE);
        }
    }
}