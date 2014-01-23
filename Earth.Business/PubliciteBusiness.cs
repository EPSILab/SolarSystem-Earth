﻿using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.DAL;
using EPSILab.SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using PubliciteDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Publicite;
using PubliciteDTO = EPSILab.SolarSystem.Earth.Common.Publicite;

namespace EPSILab.SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for advertisings
    /// </summary>
    public class PubliciteBusiness : IReader1Filter<PubliciteDTO, bool?>, IManager<PubliciteDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly PubliciteDAL _dal = new PubliciteDAL();

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper<PubliciteDAO, PubliciteDTO> _mapper = new PubliciteMapper();

        #endregion

        #region IReader1Filter methods

        /// <summary>
        /// Get a advertising
        /// </summary>
        /// <param name="code">Advertising code</param>
        /// <returns>Matching advertising</returns>
        public PubliciteDTO Get(int code)
        {
            PubliciteDAO dao = _dal.Get(code);
            PubliciteDTO dto = _mapper.ToDTO(dao);
            return dto;
        }

        /// <summary>
        /// Get all advertisings
        /// </summary>
        /// <returns>List of advertisings</returns>
        public IEnumerable<PubliciteDTO> Get()
        {
            IEnumerable<PubliciteDAO> dao = _dal.Get();
            IEnumerable<PubliciteDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Get a limited list of advertisings
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of advertising</returns>
        public IEnumerable<PubliciteDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<PubliciteDAO> dao = _dal.Get(indexFirstElement, numberOfResults);
            IEnumerable<PubliciteDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Get all/published/not published advertisings
        /// </summary>
        /// <param name="published">Determines if advertising must be published, not published or indifferent</param>
        /// <returns>List of advertising</returns>
        public IEnumerable<PubliciteDTO> Get(bool? published)
        {
            IEnumerable<PubliciteDAO> dao = _dal.Get(published);
            IEnumerable<PubliciteDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        /// <summary>
        /// Get a limited list of all/published/not published advertisings
        /// </summary>
        /// <param name="published">Determines if advertising must be published, not published or indifferent</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of advertising</returns>
        public IEnumerable<PubliciteDTO> Get(bool? published, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<PubliciteDAO> dao = _dal.Get(published, indexFirstElement, numberOfResults);
            IEnumerable<PubliciteDTO> dto = dao.Select(p => _mapper.ToDTO(p));

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
        public int Add(PubliciteDTO element, string username, string password)
        {
            PubliciteDAO dao = _mapper.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a advertising
        /// </summary>
        /// <param name="element">Edited advertising</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(PubliciteDTO element, string username, string password)
        {
            PubliciteDAO dao = _mapper.ToDAO(element);
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