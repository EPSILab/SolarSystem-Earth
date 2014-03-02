using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// Project rules checker
    /// </summary>
    class ProjectRulesManager : IRulesManager<Project>
    {
        /// /// <summary>
        /// Check if a project is valid
        /// </summary>
        /// <param name="element">News to check</param>
        public void Check(Project element)
        {
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages.Project_NoDescription);
            RulesChecker.CheckIsNotNull(element.ImageUrl, ErrorMessages.Project_NoPicture);
            RulesChecker.CheckIsNotNull(element.Name, ErrorMessages.Project_NoName);
            RulesChecker.CheckIsPercentage(element.Progression, ErrorMessages.Project_IncorrectProgression);

            RulesChecker.CheckIsNotNull(element.Id, ErrorMessages.Project_NoCitySelected);
        }
    }
}