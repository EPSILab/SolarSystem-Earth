using EPSILab.SolarSystem.Earth.Common.Interfaces;
using ShowDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Show;
using ShowDTO = EPSILab.SolarSystem.Earth.Common.Show;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Show mapper
    /// </summary>
    public class ShowMapper : IMapper<ShowDAO, ShowDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public ShowDTO ToDTO(ShowDAO element)
        {
            return new ShowDTO
            {
                Id = element.Id,
                Name = element.Name,
                Place = element.Place,
                Start_DateTime = element.Start_DateTime,
                End_DateTime = element.End_DateTime,
                Description = element.Description,
                ImageUrl = element.ImageUrl,
                IsPublished = element.IsPublished,
                Url = element.Url
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public ShowDAO ToDAO(ShowDTO element)
        {
            return new ShowDAO
            {
                Id = element.Id,
                Start_DateTime = element.Start_DateTime,
                End_DateTime = element.End_DateTime,
                Description = element.Description,
                ImageUrl = element.ImageUrl,
                Place = element.Place,
                Name = element.Name,
                IsPublished = element.IsPublished,
                Url = element.Url
            };
        }
    }
}