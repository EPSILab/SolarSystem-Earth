using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.DAL;
using EPSILab.SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using ProjetDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Projet;
using ProjetDTO = EPSILab.SolarSystem.Earth.Common.Projet;
using VilleDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = EPSILab.SolarSystem.Earth.Common.Ville;

namespace EPSILab.SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for projects
    /// </summary>
    public class ProjetBusiness : IReader1Filter<ProjetDTO, VilleDTO>, IManager<ProjetDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly ProjetDAL _dal = new ProjetDAL();

        /// <summary>
        /// Project mapper
        /// </summary>
        private readonly IMapper<ProjetDAO, ProjetDTO> _mapperProject = new ProjetMapper();

        /// <summary>
        /// City mapper
        /// </summary>
        private readonly IMapper<VilleDAO, VilleDTO> _mapperCity = new VilleMapper();

        #endregion

        #region IReader1Filter methods

        /// <summary>
        /// Get a project
        /// </summary>
        /// <param name="code">Project id</param>
        /// <returns>Matching project</returns>
        public ProjetDTO Get(int code)
        {
            ProjetDAO dao = _dal.Get(code);
            ProjetDTO dto = _mapperProject.ToDTO(dao);

            return dto;
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <returns>List of projects</returns>
        public IEnumerable<ProjetDTO> Get()
        {
            IEnumerable<ProjetDAO> dao = _dal.Get();
            IEnumerable<ProjetDTO> dto = dao.Select(p => _mapperProject.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Get a limited list of projects
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of projects</returns>
        public IEnumerable<ProjetDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<ProjetDAO> dao = _dal.Get(indexFirstElement, numberOfResults);
            IEnumerable<ProjetDTO> dto = dao.Select(p => _mapperProject.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Get projects of a city
        /// </summary>
        /// <param name="ville">Concerned city</param>
        /// <returns>List of projects</returns>
        public IEnumerable<ProjetDTO> Get(VilleDTO ville)
        {
            VilleDAO villeDao = _mapperCity.ToDAO(ville);

            IEnumerable<ProjetDAO> dao = _dal.Get(villeDao);
            IEnumerable<ProjetDTO> dto = dao.Select(p => _mapperProject.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Get a limited list of projects of a city
        /// </summary>
        /// <param name="ville">City</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of projects</returns>
        public IEnumerable<ProjetDTO> Get(VilleDTO ville, int indexFirstElement, int numberOfResults)
        {
            VilleDAO villeDao = _mapperCity.ToDAO(ville);

            IEnumerable<ProjetDAO> dao = _dal.Get(villeDao, indexFirstElement, numberOfResults);
            IEnumerable<ProjetDTO> dto = dao.Select(p => _mapperProject.ToDTO(p));

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
        public int Add(ProjetDTO element, string username, string password)
        {
            ProjetDAO dao = _mapperProject.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a project
        /// </summary>
        /// <param name="element">Edited project</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(ProjetDTO element, string username, string password)
        {
            ProjetDAO dao = _mapperProject.ToDAO(element);
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