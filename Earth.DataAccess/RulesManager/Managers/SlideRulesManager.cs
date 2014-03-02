using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// Advertising rules checker
    /// </summary>
    class SlideRulesManager : IRulesManager<Slide>
    {
        /// /// <summary>
        /// Check if a advertising is valid
        /// </summary>
        /// <param name="element">Advertising to check</param>
        public void Check(Slide element)
        {
            RulesChecker.CheckIsNotNull(element.ImageUrl, ErrorMessages.Advertising_NoPicture);
            RulesChecker.CheckIsNotNull(element.Name, ErrorMessages.Advertising_NoName);
            RulesChecker.CheckIsNotNull(element.Presentation, ErrorMessages.Advertising_NoPresentation);
        }
    }
}