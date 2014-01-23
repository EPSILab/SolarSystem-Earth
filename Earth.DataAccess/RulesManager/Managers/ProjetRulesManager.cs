using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers
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
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages.Project_NoDescription);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.Project_NoPicture);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.Project_NoName);
            RulesChecker.CheckIsPercentage(element.Avancement, ErrorMessages.Project_IncorrectProgression);

            RulesChecker.CheckIsNotNull(element.Code_Ville, ErrorMessages.Project_NoCitySelected);
        }
    }
}