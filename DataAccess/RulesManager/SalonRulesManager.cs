using SolarSystem.Earth.DataAccess.ErrorMessages;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class SalonRulesManager : IRulesManager<Salon>
    {
        public void Check(Salon element)
        {
            RulesChecker.CheckIsNotNull(element.Description, ErrorMessages_FR.SALON_AUCUNE_DESCRIPTION);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages_FR.SALON_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Lieu, ErrorMessages_FR.SALON_AUCUN_LIEU);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages_FR.SALON_AUCUN_NOM);
            RulesChecker.CheckIsNotNull(element.URL, ErrorMessages_FR.SALON_AUCUNE_URL);
        }
    }
}
