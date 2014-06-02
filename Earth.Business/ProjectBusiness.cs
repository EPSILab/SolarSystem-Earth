using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract;
using System.Collections.Generic;
using System.Linq;
using ProjectDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Project;
using ProjectDTO = EPSILab.SolarSystem.Earth.Common.Project;
using CampusDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Campus;
using CampusDTO = EPSILab.SolarSystem.Earth.Common.Campus;

namespace EPSILab.SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for projects
    /// </summary>
    class ProjectBusiness : IReader1Filter<ProjectDTO, CampusDTO>, IManager<ProjectDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly IProjectDAL _dal;

        /// <summary>
        /// Project mapper
        /// </summary>
        private readonly IMapper<ProjectDAO, ProjectDTO> _mapperProject;

        /// <summary>
        /// City mapper
        /// </summary>
        private readonly IMapper<CampusDAO, CampusDTO> _mapperCity;

        #endregion

        #region Constructor

        public ProjectBusiness(IProjectDAL dal, IMapper<ProjectDAO, ProjectDTO> mapperProject, IMapper<CampusDAO, CampusDTO> mapperCity)
        {
            _dal = dal;
            _mapperProject = mapperProject;
            _mapperCity = mapperCity;
        }

        #endregion

        #region IReader1Filter methods

        /// <summary>
        /// Get a project
        /// </summary>
        /// <param name="code">Project id</param>
        /// <returns>Matching project</returns>
        public ProjectDTO Get(int code)
        {
            ProjectDAO dao = _dal.Get(code);
            ProjectDTO dto = _mapperProject.ToDTO(dao);

            return dto;
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <returns>List of projects</returns>
        public IEnumerable<ProjectDTO> Get()
        {
            IEnumerable<ProjectDAO> dao = _dal.Get();
            IEnumerable<ProjectDTO> dto = dao.Select(p => _mapperProject.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Get a limited list of projects
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of projects</returns>
        public IEnumerable<ProjectDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<ProjectDAO> dao = _dal.Get(indexFirstElement, numberOfResults);
            IEnumerable<ProjectDTO> dto = dao.Select(p => _mapperProject.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Get projects of a city
        /// </summary>
        /// <param name="Campus">Concerned city</param>
        /// <returns>List of projects</returns>
        public IEnumerable<ProjectDTO> Get(CampusDTO Campus)
        {
            CampusDAO CampusDao = _mapperCity.ToDAO(Campus);

            IEnumerable<ProjectDAO> dao = _dal.Get(CampusDao);
            IEnumerable<ProjectDTO> dto = dao.Select(p => _mapperProject.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Get a limited list of projects of a city
        /// </summary>
        /// <param name="Campus">City</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of projects</returns>
        public IEnumerable<ProjectDTO> Get(CampusDTO Campus, int indexFirstElement, int numberOfResults)
        {
            CampusDAO CampusDao = _mapperCity.ToDAO(Campus);

            IEnumerable<ProjectDAO> dao = _dal.Get(CampusDao, indexFirstElement, numberOfResults);
            IEnumerable<ProjectDTO> dto = dao.Select(p => _mapperProject.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Returns last project id
        /// </summary>
        /// <returns>Id the last inserted project</returns>
        public int GetLastInsertedId()
        {
            return _dal.GetLastInsertedId();
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a project
        /// </summary>
        /// <param name="element">Project to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New project id</returns>
        public int Add(ProjectDTO element, string username, string password)
        {
            ProjectDAO dao = _mapperProject.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a project
        /// </summary>
        /// <param name="element">Edited project</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(ProjectDTO element, string username, string password)
        {
            ProjectDAO dao = _mapperProject.ToDAO(element);
            _dal.Edit(dao, username, password);
        }

        /// <summary>
        /// Delete a project
        /// </summary>
        /// <param name="code">Project id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            _dal.Delete(code, username, password);
        }

        #endregion
    }
}