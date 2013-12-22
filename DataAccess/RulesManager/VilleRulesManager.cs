using SolarSystem.Earth.DataAccess.ErrorMessages;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class VilleRulesManager : IRulesManager<Ville>
    {
        public void Check(Ville element)
        {
            RulesChecker.CheckIsNotNull(element.Libelle, ErrorMessages_FR.VILLE_AUCUN_LIBELLE);
        }
    }
}