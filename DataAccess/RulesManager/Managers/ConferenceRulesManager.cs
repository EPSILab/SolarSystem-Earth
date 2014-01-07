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
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages.CONFERENCE_AUCUNE_DESCRIPTION);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.CONFERENCE_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Lieu, ErrorMessages.CONFERENCE_AUCUN_LIEU);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.CONFERENCE_AUCUN_NOM);
            RulesChecker.CheckIsNotNull(element.URL, ErrorMessages.CONFERENCE_AUCUNE_URL);
            RulesChecker.CheckIsNotNull(element.Code_Ville, ErrorMessages.CONFERENCE_AUCUNE_VILLE_SELECTIONNEE);
        }
    }
}