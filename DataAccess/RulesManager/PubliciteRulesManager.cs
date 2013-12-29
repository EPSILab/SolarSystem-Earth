using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class PubliciteRulesManager : IRulesManager<Publicite>
    {
        public void Check(Publicite element)
        {
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages_FR.PUBLICITE_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages_FR.PUBLICITE_AUCUN_NOM);
            RulesChecker.CheckIsNotNull(element.Presentation, ErrorMessages_FR.PUBLICITE_AUCUNE_PRESENTATION);
        }
    }
}
