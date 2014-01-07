using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace SolarSystem.Earth.DataAccess.RulesManager.Managers
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
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.Conference_NoPicture);
            RulesChecker.CheckIsNotNull(element.Lieu, ErrorMessages.Conference_NoPlace);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.Conference_NoName);
            RulesChecker.CheckIsNotNull(element.URL, ErrorMessages.Conference_NoURL);
            RulesChecker.CheckIsNotNull(element.Code_Ville, ErrorMessages.Conference_NoCity);
        }
    }
}