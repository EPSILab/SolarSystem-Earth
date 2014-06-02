using EPSILab.SolarSystem.Earth.Common.Interfaces;
using SlideDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Slide;
using SlideDTO = EPSILab.SolarSystem.Earth.Common.Slide;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Advertising mapper
    /// </summary>
    class SlideMapper : IMapper<SlideDAO, SlideDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public SlideDTO ToDTO(SlideDAO element)
        {
            return new SlideDTO
            {
                Id = element.Id,
                Name = element.Name,
                ImageUrl = element.ImageUrl,
                Presentation = element.Presentation,
                Url = element.Url,
                IsPublished = element.IsPublished
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public SlideDAO ToDAO(SlideDTO element)
        {
            return new SlideDAO
            {
                Id = element.Id,
                ImageUrl = element.ImageUrl,
                Name = element.Name,
                Presentation = element.Presentation,
                Url = element.Url,
                IsPublished = element.IsPublished
            };
        }
    }
}