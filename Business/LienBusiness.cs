using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DAL;
using SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using LienDAO = SolarSystem.Earth.DataAccess.Model.Lien;
using LienDTO = SolarSystem.Earth.Common.Lien;

namespace SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for links
    /// </summary>
    public class LienBusiness : IReader<LienDTO>, IManager<LienDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly LienDAL _dal = new LienDAL();

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper<LienDAO, LienDTO> _mapper = new LienMapper();

        #endregion

        #region IReader methods

        /// <summary>
        /// Get a link
        /// </summary>
        /// <param name="code">Link code</param>
        /// <returns>Matching link</returns>
        public LienDTO Get(int code)
        {
            LienDAO dao = _dal.Get(code);
            LienDTO dto = _mapper.ToDTO(dao);
            return dto;
        }

        /// <summary>
        /// Returns all links
        /// </summary>
        /// <returns>List of links</returns>
        public IEnumerable<LienDTO> Get()
        {
            IEnumerable<LienDAO> dao = _dal.Get();
            IEnumerable<LienDTO> dto = dao.Select(l => _mapper.ToDTO(l));

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
        public int Add(LienDTO element, string username, string password)
        {
            LienDAO dao = _mapper.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a link
        /// </summary>
        /// <param name="element">Edited link</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(LienDTO element, string username, string password)
        {
            LienDAO dao = _mapper.ToDAO(element);
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