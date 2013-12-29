using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.Resources;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class ConferenceRulesManager : IRulesManager<Conference>
    {
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