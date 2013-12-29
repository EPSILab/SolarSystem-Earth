using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class ClasseRulesManager : IRulesManager<Classe>
    {
        public void Check(Classe element)
        {
            const int AnneeCreationEPSI = 1961;

            RulesChecker.CheckIsShorter(element.Annee_Promo_Sortante, AnneeCreationEPSI, ErrorMessages.CLASSE_ANNEE_PROMO_INVALIDE);
            RulesChecker.CheckIsNotNull(element.Libelle, ErrorMessages.CLASSE_AUCUN_LIBELLE);
        }
    }
}