using EPSILab.SolarSystem.Earth.Common.Interfaces;
using CampusDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Campus;
using CampusDTO = EPSILab.SolarSystem.Earth.Common.Campus;
using ConferenceDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Conference;
using ConferenceDTO = EPSILab.SolarSystem.Earth.Common.Conference;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Conference mapper
    /// </summary>
    class ConferenceMapper : IMapper<ConferenceDAO, ConferenceDTO>
    {
        #region Attributes

        /// <summary>
        /// Mapper for campuses
        /// </summary>
        private readonly IMapper<CampusDAO, CampusDTO> _mapperCampus = new CampusMapper();

        #endregion

        #region Methods

        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public ConferenceDTO ToDTO(ConferenceDAO element)
        {
            return new ConferenceDTO
            {
                Id = element.Id,
                Name = element.Name,
                Start_DateTime = element.Start_DateTime,
                End_DateTime = element.End_DateTime,
                Description = element.Description,
                Place = element.Place,
                ImageUrl = element.ImageUrl,
                IsPublished = element.IsPublished,
                Url = element.Url,
                Campus = _mapperCampus.ToDTO(element.Campus)
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public ConferenceDAO ToDAO(ConferenceDTO element)
        {
            return new ConferenceDAO
            {
                Id = element.Id,
                IdCampus = element.Campus.Id,
                Start_DateTime = element.Start_DateTime,
                End_DateTime = element.End_DateTime,
                Description = element.Description,
                Place = element.Place,
                Name = element.Name,
                ImageUrl = element.ImageUrl,
                IsPublished = element.IsPublished,
                Url = element.Url
            };
        }

        #endregion
    }
}