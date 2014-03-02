using EPSILab.SolarSystem.Earth.Common.Interfaces;
using PromotionDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Promotion;
using PromotionDTO = EPSILab.SolarSystem.Earth.Common.Promotion;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Promo mapper
    /// </summary>
    public class PromotionMapper : IMapper<PromotionDAO, PromotionDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public PromotionDTO ToDTO(PromotionDAO element)
        {
            return new PromotionDTO
            {
                Id = element.Id,
                Name = element.Name,
                GraduationYear = element.GraduationYear,
                StillPresent = element.StillPresent
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public PromotionDAO ToDAO(PromotionDTO element)
        {
            return new PromotionDAO
            {
                Id = element.Id,
                Name = element.Name,
                GraduationYear = element.GraduationYear,
                StillPresent = element.StillPresent
            };
        }
    }
}