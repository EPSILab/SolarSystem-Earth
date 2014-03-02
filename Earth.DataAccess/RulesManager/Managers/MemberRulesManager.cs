using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers
{
    /// <summary>
    /// Member rules checker
    /// </summary>
    class MemberRulesManager : IRulesManager<Member>
    {
        /// <summary>
        /// Check if a member is valid
        /// </summary>
        /// <param name="element">Member to check</param>
        public void Check(Member element)
        {
            RulesChecker.CheckIsNotNull(element.EPSIEmail, ErrorMessages.Member_NoMailEPSI);
            RulesChecker.CheckIsNotNull(element.ImageUrl, ErrorMessages.Member_NoPicture);
            RulesChecker.CheckIsNotNull(element.Password, ErrorMessages.Member_NoPassword);
            RulesChecker.CheckIsNotNull(element.LastName, ErrorMessages.Link_NoName);
            RulesChecker.CheckIsNotNull(element.FirstName, ErrorMessages.Member_NoFirstName);
            RulesChecker.CheckIsNotNull(element.Username, ErrorMessages.Member_NoUsername);
            RulesChecker.CheckIsNotNull(element.Url, ErrorMessages.Member_NoUrl);

            RulesChecker.CheckIsNotNull(element.Id, ErrorMessages.Member_NoCitySelected);
            RulesChecker.CheckIsNotNull(element.Id, ErrorMessages.Member_NoPromoSelected);
        }
    }
}