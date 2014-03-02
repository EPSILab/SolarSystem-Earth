using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.DAL;
using EPSILab.SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using LinkDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Link;
using LinkDTO = EPSILab.SolarSystem.Earth.Common.Link;

namespace EPSILab.SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for links
    /// </summary>
    public class LinkBusiness : IReader<LinkDTO>, IManager<LinkDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly LinkDAL _dal = new LinkDAL();

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper<LinkDAO, LinkDTO> _mapper = new LinkMapper();

        #endregion

        #region IReader methods

        /// <summary>
        /// Get a link
        /// </summary>
        /// <param name="code">Link code</param>
        /// <returns>Matching link</returns>
        public LinkDTO Get(int code)
        {
            LinkDAO dao = _dal.Get(code);
            LinkDTO dto = _mapper.ToDTO(dao);
            return dto;
        }

        /// <summary>
        /// Returns all links
        /// </summary>
        /// <returns>List of links</returns>
        public IEnumerable<LinkDTO> Get()
        {
            IEnumerable<LinkDAO> dao = _dal.Get();
            IEnumerable<LinkDTO> dto = dao.Select(l => _mapper.ToDTO(l));

            return dto;
        }

        /// <summary>
        /// Return last link id
        /// </summary>
        /// <returns>Last link id</returns>
        public int GetLastInsertedId()
        {
            return _dal.GetLastInsertedId();
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a link
        /// </summary>
        /// <param name="element">Link to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New link id</returns>
        public int Add(LinkDTO element, string username, string password)
        {
            LinkDAO dao = _mapper.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a link
        /// </summary>
        /// <param name="element">Edited link</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(LinkDTO element, string username, string password)
        {
            LinkDAO dao = _mapper.ToDAO(element);
            _dal.Edit(dao, username, password);
        }

        /// <summary>
        /// Delete a link
        /// </summary>
        /// <param name="code">Link id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            _dal.Delete(code, username, password);
        }

        #endregion
    }
}