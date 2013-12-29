using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class PubliciteRulesManager : IRulesManager<Publicite>
    {
        public void Check(Publicite element)
        {
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.PUBLICITE_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.PUBLICITE_AUCUN_NOM);
            RulesChecker.CheckIsNotNull(element.Presentation, ErrorMessages.PUBLICITE_AUCUNE_PRESENTATION);
        }
    }
}
