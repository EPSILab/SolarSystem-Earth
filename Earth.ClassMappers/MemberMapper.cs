using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using CampusDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Campus;
using CampusDTO = EPSILab.SolarSystem.Earth.Common.Campus;
using MemberDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Member;
using MemberDTO = EPSILab.SolarSystem.Earth.Common.Member;
using PromotionDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Promotion;
using PromotionDTO = EPSILab.SolarSystem.Earth.Common.Promotion;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Member mapper
    /// </summary>
    class MemberMapper : IMapper<MemberDAO, MemberDTO>
    {
        #region Attributes

        /// <summary>
        /// Mapper for campuses
        /// </summary>
        private readonly IMapper<CampusDAO, CampusDTO> _mapperCampus = new CampusMapper();

        /// <summary>
        /// Mapper for promotions
        /// </summary>
        private readonly IMapper<PromotionDAO, PromotionDTO> _mapperPromotion = new PromotionMapper();

        #endregion

        #region Methods

        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public MemberDTO ToDTO(MemberDAO element)
        {
            return new MemberDTO
            {
                Id = element.Id,
                LastName = element.LastName,
                FirstName = element.FirstName,
                Username = element.Username,
                EPSIEmail = element.EPSIEmail,
                PersonalEmail = element.PersonalEmail,
                PhoneNumber = element.PhoneNumber,
                CityFrom = element.CityFrom,
                Website = element.Website,
                FacebookUrl = element.FacebookUrl,
                TwitterUrl = element.TwitterUrl,
                LinkedInUrl = element.LinkedInUrl,
                ViadeoUrl = element.ViadeoUrl,
                Status = element.Status,
                Presentation = element.Presentation,
                ImageUrl = element.ImageUrl,
                Url = element.Url,
                Campus = _mapperCampus.ToDTO(element.Campus),
                Promotion = _mapperPromotion.ToDTO(element.Promotion),
                Role = (Role)element.Role,
                Active = element.Active
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public MemberDAO ToDAO(MemberDTO element)
        {
            return new MemberDAO
            {
                Id = element.Id,
                IdPromotion = element.Promotion.Id,
                IdCampus = element.Campus.Id,
                Role = (int)element.Role,
                EPSIEmail = element.EPSIEmail,
                PersonalEmail = element.PersonalEmail,
                ImageUrl = element.ImageUrl,
                LastName = element.LastName,
                FirstName = element.FirstName,
                Presentation = element.Presentation,
                Username = element.Username,
                Website = element.Website,
                Status = element.Status,
                PhoneNumber = element.PhoneNumber,
                FacebookUrl = element.FacebookUrl,
                TwitterUrl = element.TwitterUrl,
                LinkedInUrl = element.LinkedInUrl,
                ViadeoUrl = element.ViadeoUrl,
                GitHubUrl = element.GitHubUrl,
                CityFrom = element.CityFrom,
                Url = element.Url,
                Active = element.Active
            };
        }

        #endregion
    }
}