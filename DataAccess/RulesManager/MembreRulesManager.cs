using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class MembreRulesManager : IRulesManager<Membre>
    {
        public void Check(Membre element)
        {
            RulesChecker.CheckIsNotNull(element.Email_EPSI, ErrorMessages.MEMBRE_PAS_DE_MAIL_EPSI);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.MEMBRE_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Mot_de_passe, ErrorMessages.MEMBRE_AUCUN_MOT_DE_PASSE);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.LIEN_AUCUN_NOM);
            RulesChecker.CheckIsNotNull(element.Prenom, ErrorMessages.MEMBRE_AUCUN_PRENOM);
            RulesChecker.CheckIsNotNull(element.Pseudo, ErrorMessages.MEMBRE_AUCUN_PSEUDO);
            RulesChecker.CheckIsNotNull(element.Statut, ErrorMessages.MEMBRE_AUCUN_STATUT);
            RulesChecker.CheckIsNotNull(element.URL, ErrorMessages.MEMBRE_AUCUN_URL);

            RulesChecker.CheckIsNotNull(element.Code_Ville, ErrorMessages.MEMBRE_AUCUNE_VILLE_SELECTIONNEE);
            RulesChecker.CheckIsNotNull(element.Code_Role, ErrorMessages.MEMBRE_AUCUN_ROLE_SELECTIONNEE);
            RulesChecker.CheckIsNotNull(element.Code_Classe, ErrorMessages.MEMBRE_AUCUNE_PROMO_SELECTIONNEE);
        }
    }
}
