using EPSILab.SolarSystem.Earth.Common.Interfaces;
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
    public class VilleDAL : IReader<Ville>, IManager<Ville>
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly MembreDAL _memberDAL = new MembreDAL();

        #endregion

        #region IReader methods

        /// <summary>
        /// Get a city
        /// </summary>
        /// <param name="code">City code</param>
        /// <returns>Matching city</returns>
        public Ville Get(int code)
        {
            return (from ville in SunAccess.Instance.Ville
                    where ville.Code_Ville == code
                    select ville).First();
        }

        /// <summary>
        /// Get all cities
        /// </summary>
        /// <returns>List of cities</returns>
        public IEnumerable<Ville> Get()
        {
            return SunAccess.Instance.Ville;
        }

        /// <summary>
        /// Returns last city id
        /// </summary>
        /// <returns>Id the last city inserted</returns>
        public int GetLastInsertedId()
        {
            return (from ville in SunAccess.Instance.Ville
                    orderby ville.Code_Ville descending
                    select ville).First().Code_Ville;
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
        public int Add(Ville element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                SunAccess.Instance.Ville.AddObject(element);
                SunAccess.Instance.SaveChanges();

                return element.Code_Ville;
            }

            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a city
        /// </summary>
        /// <param name="element">Edited city</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Ville element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Ville> rulesManager = new VilleRulesManager();
                rulesManager.Check(element);

                Ville v = Get(element.Code_Ville);
                v.Libelle = element.Libelle;

                SunAccess.Instance.SaveChanges();
            }
            else
            {
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
                Ville v = Get(code);
                SunAccess.Instance.Ville.DeleteObject(v);

                SunAccess.Instance.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException(username);
            }
        }

        #endregion
    }
}