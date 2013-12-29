using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class ProjetRulesManager : IRulesManager<Projet>
    {
        public void Check(Projet element)
        {
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages_FR.PROJET_AUCUNE_DESCRIPTION);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages_FR.PROJET_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages_FR.PROJET_AUCUN_NOM);
            RulesChecker.CheckIsPercentage(element.Avancement, ErrorMessages_FR.PROJET_AVANCEMENT_INCORRECT);

            RulesChecker.CheckIsNotNull(element.Code_Ville, ErrorMessages_FR.PROJET_AUCUNE_VILLE_SELECTIONNEE);
        }
    }
}
