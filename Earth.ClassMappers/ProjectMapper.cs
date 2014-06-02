using EPSILab.SolarSystem.Earth.Common.Interfaces;
using CampusDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Campus;
using CampusDTO = EPSILab.SolarSystem.Earth.Common.Campus;
using ProjectDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Project;
using ProjectDTO = EPSILab.SolarSystem.Earth.Common.Project;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Project mapper
    /// </summary>
    class ProjectMapper : IMapper<ProjectDAO, ProjectDTO>
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
        public ProjectDTO ToDTO(ProjectDAO element)
        {
            return new ProjectDTO
            {
                Id = element.Id,
                Name = element.Name,
                Progression = element.Progression,
                Description = element.Description,
                ImageUrl = element.ImageUrl,
                Campus = _mapperCampus.ToDTO(element.Campus)
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public ProjectDAO ToDAO(ProjectDTO element)
        {
            return new ProjectDAO
            {
                Progression = element.Progression,
                Id = element.Id,
                IdCampus = element.Campus.Id,
                Description = element.Description,
                Name = element.Name,
                ImageUrl = element.ImageUrl
            };
        }

        #endregion
    }
}