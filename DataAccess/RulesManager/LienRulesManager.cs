using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class LienRulesManager : IRulesManager<Lien>
    {
        public void Check(Lien element)
        {
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages.LIEN_AUCUNE_DESCRIPTION);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.LIEN_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.LIEN_AUCUN_NOM);
        }
    }
}
