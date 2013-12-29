using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class VilleRulesManager : IRulesManager<Ville>
    {
        public void Check(Ville element)
        {
            RulesChecker.CheckIsNotNull(element.Libelle, ErrorMessages.VILLE_AUCUN_LIBELLE);
        }
    }
}