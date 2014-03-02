using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// Conference rules checker
    /// </summary>
    class ConferenceRulesManager : IRulesManager<Conference>
    {
        /// <summary>
        /// Check if a conference is valid
        /// </summary>
        /// <param name="element">Conference to check</param>
        public void Check(Conference element)
        {
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages.Conference_NoDescription);
            RulesChecker.CheckIsNotNull(element.ImageUrl, ErrorMessages.Conference_NoPicture);
            RulesChecker.CheckIsNotNull(element.Place, ErrorMessages.Conference_NoPlace);
            RulesChecker.CheckIsNotNull(element.Name, ErrorMessages.Conference_NoName);
            RulesChecker.CheckIsNotNull(element.Url, ErrorMessages.Conference_NoUrl);
            RulesChecker.CheckIsNotNull(element.Id, ErrorMessages.Conference_NoCity);
        }
    }
}