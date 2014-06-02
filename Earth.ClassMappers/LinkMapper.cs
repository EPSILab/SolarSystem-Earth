using EPSILab.SolarSystem.Earth.Common.Interfaces;
using LinkDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Link;
using LinkDTO = EPSILab.SolarSystem.Earth.Common.Link;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Link mapper
    /// </summary>
    class LinkMapper : IMapper<LinkDAO, LinkDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public LinkDTO ToDTO(LinkDAO element)
        {
            return new LinkDTO
            {
                Id = element.Id,
                Label = element.Label,
                Url = element.Url,
                ImageUrl = element.ImageUrl,
                Description = element.Description,
                Order = element.Order
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public LinkDAO ToDAO(LinkDTO element)
        {
            return new LinkDAO
            {
                Id = element.Id,
                Description = element.Description,
                ImageUrl = element.ImageUrl,
                Label = element.Label,
                Url = element.Url
            };
        }
    }
}