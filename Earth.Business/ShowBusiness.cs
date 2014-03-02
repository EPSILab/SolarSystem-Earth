using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.DAL;
using EPSILab.SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using ShowDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Show;
using ShowDTO = EPSILab.SolarSystem.Earth.Common.Show;

namespace EPSILab.SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for shows
    /// </summary>
    public class ShowBusiness : IReader1Filter<ShowDTO, bool?>, ISearchable<ShowDTO>, IManager<ShowDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly ShowDAL _dal = new ShowDAL();

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper<ShowDAO, ShowDTO> _mapper = new ShowMapper();

        #endregion

        #region IReader1Filter methods

        /// <summary>
        /// Get a show
        /// </summary>
        /// <param name="code">Show code</param>
        /// <returns>Matching code</returns>
        public ShowDTO Get(int code)
        {
            ShowDAO dao = _dal.Get(code);
            ShowDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

        /// <summary>
        /// Get all shows
        /// </summary>
        /// <returns>List of shows</returns>
        public IEnumerable<ShowDTO> Get()
        {
            IEnumerable<ShowDAO> dao = _dal.Get();
            IEnumerable<ShowDTO> dto = dao.Select(s => _mapper.ToDTO(s));

            return dto;
        }

        /// <summary>
        /// Get a limited list of shows
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of shows</returns>
        public IEnumerable<ShowDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<ShowDAO> dao = _dal.Get(indexFirstElement, numberOfResults);
            IEnumerable<ShowDTO> dto = dao.Select(s => _mapper.ToDTO(s));

            return dto;
        }

        /// <summary>
        /// Get all/published/not published shows
        /// </summary>
        /// <param name="published">Determines if show must be published, not published or indifferent</param>
        /// <returns>List of show</returns>
        public IEnumerable<ShowDTO> Get(bool? published)
        {
            IEnumerable<ShowDAO> dao = _dal.Get(published);
            IEnumerable<ShowDTO> dto = dao.Select(s => _mapper.ToDTO(s));

            return dto;
        }

        /// <summary>
        /// Get a limited list of all/published/not published shows
        /// </summary>
        /// <param name="published">Determines if show must be published, not published or indifferent</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of show</returns>
        public IEnumerable<ShowDTO> Get(bool? published, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<ShowDAO> dao = _dal.Get(published, indexFirstElement, numberOfResults);
            IEnumerable<ShowDTO> dto = dao.Select(s => _mapper.ToDTO(s));

            return dto;
        }

        /// <summary>
        /// Returns last show id
        /// </summary>
        /// <returns>Id the last show inserted</returns>
        public int GetLastInsertedId()
        {
            return _dal.GetLastInsertedId();
        }

        #endregion

        #region ISearchable methods

        /// <summary>
        /// Returns all news matching to a keyword
        /// </summary>
        /// <param name="keywords">Search keywords separated by a space</param>
        /// <returns>List of matching news</returns>
        public IEnumerable<ShowDTO> Search(string keywords)
        {
            IEnumerable<ShowDAO> dao = _dal.Search(keywords);
            IEnumerable<ShowDTO> dto = dao.Select(s => _mapper.ToDTO(s));

            return dto;
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a show
        /// </summary>
        /// <param name="element">Show to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New show id</returns>
        public int Add(ShowDTO element, string username, string password)
        {
            ShowDAO dao = _mapper.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a show
        /// </summary>
        /// <param name="element">Edited show</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(ShowDTO element, string username, string password)
        {
            ShowDAO dao = _mapper.ToDAO(element);
            _dal.Edit(dao, username, password);
        }

        /// <summary>
        /// Delete a show
        /// </summary>
        /// <param name="code">Show id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            _dal.Delete(code, username, password);
        }

        #endregion
    }
}