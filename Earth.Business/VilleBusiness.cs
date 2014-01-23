using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.DAL;
using EPSILab.SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using VilleDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = EPSILab.SolarSystem.Earth.Common.Ville;

namespace EPSILab.SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for cities
    /// </summary>
    public class VilleBusiness : IReader<VilleDTO>, IManager<VilleDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly VilleDAL _dal = new VilleDAL();

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper<VilleDAO, VilleDTO> _mapper = new VilleMapper();

        #endregion

        #region IReader methods

        /// <summary>
        /// Get a city
        /// </summary>
        /// <param name="code">City code</param>
        /// <returns>Matching city</returns>
        public VilleDTO Get(int code)
        {
            VilleDAO dao = _dal.Get(code);
            VilleDTO dto = _mapper.ToDTO(dao);
            return dto;
        }

        /// <summary>
        /// Get all cities
        /// </summary>
        /// <returns>List of cities</returns>
        public IEnumerable<VilleDTO> Get()
        {
            IEnumerable<VilleDAO> dao = _dal.Get();
            IEnumerable<VilleDTO> dto = dao.Select(v => _mapper.ToDTO(v));
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
        public int Add(VilleDTO element, string username, string password)
        {
            VilleDAO dao = _mapper.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a city
        /// </summary>
        /// <param name="element">Edited city</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(VilleDTO element, string username, string password)
        {
            VilleDAO dao = _mapper.ToDAO(element);
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