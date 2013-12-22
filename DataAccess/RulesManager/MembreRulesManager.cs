using SolarSystem.Earth.DataAccess.ErrorMessages;
using SolarSystem.Earth.DataAccess.Model;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    class MembreRulesManager : IRulesManager<Membre>
    {
        public void Check(Membre element)
        {
            RulesChecker.CheckIsNotNull(element.Email_EPSI, ErrorMessages_FR.MEMBRE_PAS_DE_MAIL_EPSI);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages_FR.MEMBRE_AUCUNE_IMAGE);
            RulesChecker.CheckIsNotNull(element.Mot_de_passe, ErrorMessages_FR.MEMBRE_AUCUN_MOT_DE_PASSE);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages_FR.LIEN_AUCUN_NOM);
            RulesChecker.CheckIsNotNull(element.Prenom, ErrorMessages_FR.MEMBRE_AUCUN_PRENOM);
            RulesChecker.CheckIsNotNull(element.Pseudo, ErrorMessages_FR.MEMBRE_AUCUN_PSEUDO);
            RulesChecker.CheckIsNotNull(element.Statut, ErrorMessages_FR.MEMBRE_AUCUN_STATUT);
            RulesChecker.CheckIsNotNull(element.URL, ErrorMessages_FR.MEMBRE_AUCUN_URL);

            RulesChecker.CheckIsNotNull(element.Code_Ville, ErrorMessages_FR.MEMBRE_AUCUNE_VILLE_SELECTIONNEE);
            RulesChecker.CheckIsNotNull(element.Code_Role, ErrorMessages_FR.MEMBRE_AUCUN_ROLE_SELECTIONNEE);
            RulesChecker.CheckIsNotNull(element.Code_Classe, ErrorMessages_FR.MEMBRE_AUCUNE_PROMO_SELECTIONNEE);
        }
    }
}
