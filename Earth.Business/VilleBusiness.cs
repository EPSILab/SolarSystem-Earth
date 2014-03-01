using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.DAL;
using EPSILab.SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using CampusDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Campus;
using CampusDTO = EPSILab.SolarSystem.Earth.Common.Campus;

namespace EPSILab.SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for cities
    /// </summary>
    public class CampusBusiness : IReader<CampusDTO>, IManager<CampusDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly CampusDAL _dal = new CampusDAL();

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper<CampusDAO, CampusDTO> _mapper = new CampusMapper();

        #endregion

        #region IReader methods

        /// <summary>
        /// Get a city
        /// </summary>
        /// <param name="code">City code</param>
        /// <returns>Matching city</returns>
        public CampusDTO Get(int code)
        {
            CampusDAO dao = _dal.Get(code);
            CampusDTO dto = _mapper.ToDTO(dao);
            return dto;
        }

        /// <summary>
        /// Get all cities
        /// </summary>
        /// <returns>List of cities</returns>
        public IEnumerable<CampusDTO> Get()
        {
            IEnumerable<CampusDAO> dao = _dal.Get();
            IEnumerable<CampusDTO> dto = dao.Select(v => _mapper.ToDTO(v));
            return dto;
        }

        /// <summary>
        /// Returns last city id
        /// </summary>
        /// <returns>Id the last city inserted</returns>
        public int GetLastInsertedId()
        {
            return _dal.GetLastInsertedId();
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a city
        /// </summary>
        /// <param name="element">City to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New city id</returns>
        public int Add(CampusDTO element, string username, string password)
        {
            CampusDAO dao = _mapper.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a city
        /// </summary>
        /// <param name="element">Edited city</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(CampusDTO element, string username, string password)
        {
            CampusDAO dao = _mapper.ToDAO(element);
            _dal.Edit(dao, username, password);
        }

        /// <summary>
        /// Delete a city
        /// </summary>
        /// <param name="code">City id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            _dal.Delete(code, username, password);
        }

        #endregion
    }
}