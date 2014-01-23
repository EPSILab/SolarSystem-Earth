﻿using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.DAL;
using EPSILab.SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using ConferenceDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Conference;
using ConferenceDTO = EPSILab.SolarSystem.Earth.Common.Conference;
using VilleDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = EPSILab.SolarSystem.Earth.Common.Ville;

namespace EPSILab.SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for conference
    /// </summary>
    public class ConferenceBusiness : IReader2Filters<ConferenceDTO, VilleDTO, bool?>, ISearchable<ConferenceDTO>, IManager<ConferenceDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly ConferenceDAL _dal = new ConferenceDAL();

        /// <summary>
        /// Conference mapper
        /// </summary>
        private readonly IMapper<ConferenceDAO, ConferenceDTO> _mapperConference = new ConferenceMapper();

        /// <summary>
        /// City mapper
        /// </summary>
        private readonly IMapper<VilleDAO, VilleDTO> _mapperCity = new VilleMapper();

        #endregion

        #region IReader2Filters methods

        /// <summary>
        /// Get a conference
        /// </summary>
        /// <param name="code">Conference id</param>
        /// <returns>Matching conferences</returns>
        public ConferenceDTO Get(int code)
        {
            ConferenceDAO dao = _dal.Get(code);
            ConferenceDTO dto = _mapperConference.ToDTO(dao);

            return dto;
        }

        /// <summary>
        /// Get all the conferences
        /// </summary>
        /// <returns>List of conferences</returns>
        public IEnumerable<ConferenceDTO> Get()
        {
            IEnumerable<ConferenceDAO> dao = _dal.Get();
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        /// <summary>
        /// Get a limited list of conferences
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<ConferenceDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<ConferenceDAO> dao = _dal.Get(indexFirstElement, numberOfResults);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        /// <summary>
        /// Get all the conferences published or not
        /// </summary>
        /// <param name="published">Published conferences or not</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<ConferenceDTO> Get(bool? published)
        {
            IEnumerable<ConferenceDAO> dao = _dal.Get(published);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        /// <summary>
        /// Get a limited list of conferences published or not
        /// </summary>
        /// <param name="published">Published conferences or not</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<ConferenceDTO> Get(bool? published, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<ConferenceDAO> dao = _dal.Get(published, indexFirstElement, numberOfResults);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        /// <summary>
        /// Get all conferences of a city
        /// </summary>
        /// <param name="ville">City concerned</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<ConferenceDTO> Get(VilleDTO ville)
        {
            VilleDAO villeDao = _mapperCity.ToDAO(ville);

            IEnumerable<ConferenceDAO> dao = _dal.Get(villeDao);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        /// <summary>
        /// Get a limited list of conferences of a city
        /// </summary>
        /// <param name="ville">City concerned</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<ConferenceDTO> Get(VilleDTO ville, int indexFirstElement, int numberOfResults)
        {
            VilleDAO villeDao = _mapperCity.ToDAO(ville);

            IEnumerable<ConferenceDAO> dao = _dal.Get(villeDao, indexFirstElement, numberOfResults);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        /// <summary>
        /// Get all conferences of a city published or not
        /// </summary>
        /// <param name="ville">City concerned</param>
        /// <param name="published">Published conferences or not</param>
        /// <returns>Matching list of conferences</returns>
        public IEnumerable<ConferenceDTO> Get(VilleDTO ville, bool? published)
        {
            VilleDAO villeDao = _mapperCity.ToDAO(ville);

            IEnumerable<ConferenceDAO> dao = _dal.Get(villeDao, published);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        /// <summary>
        /// Get all/published/not published conferences. The results can be limited
        /// </summary>
        /// <param name="ville">City concerned</param>
        /// <param name="published">Published conferences or not</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of conferences</returns>
        public IEnumerable<ConferenceDTO> Get(VilleDTO ville, bool? published, int indexFirstElement, int numberOfResults)
        {
            VilleDAO villeDao = _mapperCity.ToDAO(ville);

            IEnumerable<ConferenceDAO> dao = _dal.Get(villeDao, published, indexFirstElement, numberOfResults);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        /// <summary>
        /// Returns last conference id
        /// </summary>
        /// <returns>Id the last inserted conference</returns>
        public int GetLastInsertedId()
        {
            return _dal.GetLastInsertedId();
        }

        #endregion

        #region ISearchable methods

        /// <summary>
        /// Returns all conferences matching to a keyword
        /// </summary>
        /// <param name="keywords">Search keywords separated by a space</param>
        /// <returns>List of matching conferences</returns>
        public IEnumerable<ConferenceDTO> Search(string keywords)
        {
            IEnumerable<ConferenceDAO> dao = _dal.Search(keywords);
            return dao.Select(c => _mapperConference.ToDTO(c));
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a conference
        /// </summary>
        /// <param name="element">Conference to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New conference id</returns>
        public int Add(ConferenceDTO element, string username, string password)
        {
            ConferenceDAO dao = _mapperConference.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a conference
        /// </summary>
        /// <param name="element">Edited conference</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(ConferenceDTO element, string username, string password)
        {
            ConferenceDAO dao = _mapperConference.ToDAO(element);
            _dal.Edit(dao, username, password);
        }

        /// <summary>
        /// Delete a conference
        /// </summary>
        /// <param name="code">Conference id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            _dal.Delete(code, username, password);
        }

        #endregion
    }
}