using EPSILab.SolarSystem.Earth.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract;
using SlideDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Slide;
using SlideDTO = EPSILab.SolarSystem.Earth.Common.Slide;

namespace EPSILab.SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for advertisings
    /// </summary>
    class SlideBusiness : IReader1Filter<SlideDTO, bool?>, IManager<SlideDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly ISlideDAL _dal;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper<SlideDAO, SlideDTO> _mapper;

        #endregion

        #region Constructor

        public SlideBusiness(ISlideDAL dal, IMapper<SlideDAO, SlideDTO> mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        #endregion

        #region IReader1Filter methods

        /// <summary>
        /// Get a advertising
        /// </summary>
        /// <param name="code">Advertising code</param>
        /// <returns>Matching advertising</returns>
        public SlideDTO Get(int code)
        {
            SlideDAO dao = _dal.Get(code);
            SlideDTO dto = _mapper.ToDTO(dao);
            return dto;
        }

        /// <summary>
        /// Get all advertisings
        /// </summary>
        /// <returns>List of advertisings</returns>
        public IEnumerable<SlideDTO> Get()
        {
            IEnumerable<SlideDAO> dao = _dal.Get();
            IEnumerable<SlideDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Get a limited list of advertisings
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of advertising</returns>
        public IEnumerable<SlideDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<SlideDAO> dao = _dal.Get(indexFirstElement, numberOfResults);
            IEnumerable<SlideDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Get all/published/not published advertisings
        /// </summary>
        /// <param name="published">Determines if advertising must be published, not published or indifferent</param>
        /// <returns>List of advertising</returns>
        public IEnumerable<SlideDTO> Get(bool? published)
        {
            IEnumerable<SlideDAO> dao = _dal.Get(published);
            IEnumerable<SlideDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Get a limited list of all/published/not published advertisings
        /// </summary>
        /// <param name="published">Determines if advertising must be published, not published or indifferent</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of advertising</returns>
        public IEnumerable<SlideDTO> Get(bool? published, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<SlideDAO> dao = _dal.Get(published, indexFirstElement, numberOfResults);
            IEnumerable<SlideDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Returns last advertising id
        /// </summary>
        /// <returns>Id the last advertising advertising</returns>
        public int GetLastInsertedId()
        {
            return _dal.GetLastInsertedId();
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a advertising
        /// </summary>
        /// <param name="element">Advertising to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New advertising id</returns>
        public int Add(SlideDTO element, string username, string password)
        {
            SlideDAO dao = _mapper.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a advertising
        /// </summary>
        /// <param name="element">Edited advertising</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(SlideDTO element, string username, string password)
        {
            SlideDAO dao = _mapper.ToDAO(element);
            _dal.Edit(dao, username, password);
        }

        /// <summary>
        /// Delete a advertising
        /// </summary>
        /// <param name="code">Advertising id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            _dal.Delete(code, username, password);
        }

        #endregion
    }
}