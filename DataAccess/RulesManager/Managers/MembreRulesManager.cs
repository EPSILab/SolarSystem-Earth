using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// Member rules checker
    /// </summary>
    class MembreRulesManager : IRulesManager<Membre>
    {
        /// <summary>
        /// Check if a member is valid
        /// </summary>
        /// <param name="element">Member to check</param>
        public void Check(Membre element)
        {
            RulesChecker.CheckIsNotNull(element.Email_EPSI, ErrorMessages.Member_NoMailEPSI);
            RulesChecker.CheckIsNotNull(element.Image, ErrorMessages.Member_NoPicture);
            RulesChecker.CheckIsNotNull(element.Mot_de_passe, ErrorMessages.Member_NoPassword);
            RulesChecker.CheckIsNotNull(element.Nom, ErrorMessages.Link_NoName);
            RulesChecker.CheckIsNotNull(element.Prenom, ErrorMessages.Member_NoFirstName);
            RulesChecker.CheckIsNotNull(element.Pseudo, ErrorMessages.Member_NoUsername);
            RulesChecker.CheckIsNotNull(element.URL, ErrorMessages.Member_NoURL);

            RulesChecker.CheckIsNotNull(element.Code_Ville, ErrorMessages.Member_NoCitySelected);
            RulesChecker.CheckIsNotNull(element.Code_Classe, ErrorMessages.Member_NoPromoSelected);
        }
    }
}