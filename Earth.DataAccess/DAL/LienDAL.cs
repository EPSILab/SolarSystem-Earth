using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Exceptions;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager.Managers;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Access to links table
    /// </summary>
    public class LienDAL : IReader<Lien>, IManager<Lien>
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly MembreDAL _memberDAL = new MembreDAL();

        #endregion

        #region IReader methods

        /// <summary>
        /// Get a link
        /// </summary>
        /// <param name="code">Link code</param>
        /// <returns>Matching link</returns>
        public Lien Get(int code)
        {
            return (from lien in SunAccess.Instance.Lien
                    where lien.Code_Lien == code
                    select lien).First();
        }

        /// <summary>
        /// Returns all links
        /// </summary>
        /// <returns>List of links</returns>
        public IEnumerable<Lien> Get()
        {
            IEnumerable<Lien> results = (from l in SunAccess.Instance.Lien
                                         orderby l.Ordre
                                         select l);

            return results;
        }

        /// <summary>
        /// Return last link id
        /// </summary>
        /// <returns>Last link id</returns>
        public int GetLastInsertedId()
        {
            return (from l in SunAccess.Instance.Lien
                    orderby l.Code_Lien descending
                    select l).First().Code_Lien;
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
        public int Add(Lien element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Lien> rulesManager = new LienRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Lien.AddObject(element);
                SunAccess.Instance.SaveChanges();

                return element.Code_Lien;
            }
            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a link
        /// </summary>
        /// <param name="element">Edited link</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Lien element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Lien> rulesManager = new LienRulesManager();
                rulesManager.Check(element);

                Lien l = Get(element.Code_Lien);
                l.Nom = element.Nom;
                l.URL = element.URL;
                l.Image = element.Image;
                l.Description = element.Description;
                l.Ordre = element.Ordre;

                SunAccess.Instance.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException(username);
            }
        }

        /// <summary>
        /// Delete a link
        /// </summary>
        /// <param name="code">Link id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                Lien lien = Get(code);
                SunAccess.Instance.Lien.DeleteObject(lien);

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