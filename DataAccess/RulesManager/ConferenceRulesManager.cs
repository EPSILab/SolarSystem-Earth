using SolarSystem.Earth.DataAccess.ErrorMessages;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class ConferenceRulesManager : IRulesManager<Conference>
    {
        public void Check(Conference element)
        {
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages_FR.CONFERENCE_AUCUNE_DESCRIPTION);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages_FR.CONFERENCE_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Lieu, ErrorMessages_FR.CONFERENCE_AUCUN_LIEU);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages_FR.CONFERENCE_AUCUN_NOM);
            RulesChecker.CheckIsNotNull(element.URL, ErrorMessages_FR.CONFERENCE_AUCUNE_URL);
            RulesChecker.CheckIsNotNull(element.Code_Ville, ErrorMessages_FR.CONFERENCE_AUCUNE_VILLE_SELECTIONNEE);
        }
    }
}