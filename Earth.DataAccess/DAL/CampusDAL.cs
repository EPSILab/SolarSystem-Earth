﻿using EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract;
using EPSILab.SolarSystem.Earth.DataAccess.Exceptions;
using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        #endregion

        #region Constructor

        public CampusDAL(IMemberDAL memberDAL)
        {
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
            return (from campus in SunAccess.Instance.Campus
                    where campus.Id == code
                    select campus).First();
        }

        /// <summary>
        /// Get all cities
        /// </summary>
        /// <returns>List of cities</returns>
        public IEnumerable<Campus> Get()
        {
            return SunAccess.Instance.Campus;
        }

        /// <summary>
        /// Returns last city id
        /// </summary>
        /// <returns>Id the last city inserted</returns>
        public int GetLastInsertedId()
        {
            return (from campus in SunAccess.Instance.Campus
                    orderby campus.Id descending
                    select campus).First().Id;
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

                return element.Id;
            }

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
            }
            else
                throw new AccessDeniedException(username);
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
                Campus v = Get(code);
                SunAccess.Instance.Campus.Remove(v);

                SunAccess.Instance.SaveChanges();
            }
            else
                throw new AccessDeniedException(username);
        }

        #endregion
    }
}