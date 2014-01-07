using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// Project rules checker
    /// </summary>
    class ProjetRulesManager : IRulesManager<Projet>
    {
        /// /// <summary>
        /// Check if a project is valid
        /// </summary>
        /// <param name="element">News to check</param>
        public void Check(Projet element)
        {
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages.PROJET_AUCUNE_DESCRIPTION);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.PROJET_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.PROJET_AUCUN_NOM);
            RulesChecker.CheckIsPercentage(element.Avancement, ErrorMessages.PROJET_AVANCEMENT_INCORRECT);

            RulesChecker.CheckIsNotNull(element.Code_Ville, ErrorMessages.PROJET_AUCUNE_VILLE_SELECTIONNEE);
        }
    }
}