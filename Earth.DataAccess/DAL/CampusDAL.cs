using System;
using EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract;
using EPSILab.SolarSystem.Earth.DataAccess.Exceptions;
using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;
using System.Collections.Generic;
using System.Linq;
using log4net;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Access to city table
    /// </summary>
    class CampusDAL : ICampusDAL
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly IMemberDAL _memberDAL;

        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILog _log;

        #endregion

        #region Constructor

        public CampusDAL(ILog log, IMemberDAL memberDAL)
        {
            _log = log;
            _memberDAL = memberDAL;
        }

        #endregion

        #region IReader methods

        /// <summary>
        /// Get a city
        /// </summary>
        /// <param name="code">City code</param>
        /// <returns>Matching city</returns>
        public Campus Get(int code)
        {
            Campus campus = (from c in SunAccess.Instance.Campus
                             where c.Id == code
                             select c).FirstOrDefault();

            if (campus != null)
            {
                _log.Info(string.Format("{0} {1}", LogMessages.GetCampusByCode, code));
                return campus;
            }

            _log.Error(string.Format("{0} by code {1}", LogMessages.CampusNotFound, code));
            throw new ArgumentNullException();
        }

        /// <summary>
        /// Get all cities
        /// </summary>
        /// <returns>List of cities</returns>
        public IEnumerable<Campus> Get()
        {
            _log.Info(LogMessages.GetAllCampus);

            return SunAccess.Instance.Campus;
        }

        /// <summary>
        /// Returns last city id
        /// </summary>
        /// <returns>Id the last city inserted</returns>
        public int GetLastInsertedId()
        {
            Campus campus = (from c in SunAccess.Instance.Campus
                             orderby c.Id descending
                             select c).FirstOrDefault();

            if (campus != null)
            {
                _log.Info(string.Format("{0} : {1}", LogMessages.GetLastCityInsertedID));
                return campus.Id;
            }

            _log.Error(string.Format("{0} - {1}", LogMessages.GetLastCityInsertedID, LogMessages.CampusNotFound));
            throw new ArgumentNullException();
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
        public int Add(Campus element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                SunAccess.Instance.Campus.Add(element);
                SunAccess.Instance.SaveChanges();

                _log.Info(string.Format("'{0}' {1} '{2}'", element.Place, LogMessages.AddCampusByUser, username));

                return element.Id;
            }

            _log.Error(string.Format("{0} '{1}'", LogMessages.AccessDeniedToUser, username));
            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a city
        /// </summary>
        /// <param name="element">Edited city</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Campus element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Campus> rulesManager = new CampusRulesManager();
                rulesManager.Check(element);

                Campus v = Get(element.Id);
                v.Place = element.Place;

                SunAccess.Instance.SaveChanges();

                _log.Info(string.Format("'{0}' {1} '{2}'", element.Place, LogMessages.EditCampusByUser, username));
            }
            else
            {
                _log.Error(string.Format("{0} '{1}'", LogMessages.AccessDeniedToUser, username));
                throw new AccessDeniedException(username);
            }
        }

        /// <summary>
        /// Delete a city
        /// </summary>
        /// <param name="code">City id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                Campus campus = Get(code);
                SunAccess.Instance.Campus.Remove(campus);

                SunAccess.Instance.SaveChanges();

                _log.Info(string.Format("'{0}' {1} '{2}'", campus.Place, LogMessages.DeleteCampusByUser, username));
            }
            else
            {
                _log.Error(string.Format("{0} '{1}'", LogMessages.AccessDeniedToUser, username));
                throw new AccessDeniedException(username);
            }
        }

        #endregion
    }
}