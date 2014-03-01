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
    /// Access to links table
    /// </summary>
    public class LinkDAL : IReader<Link>, IManager<Link>
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly MemberDAL _memberDAL = new MemberDAL();

        #endregion

        #region IReader methods

        /// <summary>
        /// Get a link
        /// </summary>
        /// <param name="code">Link code</param>
        /// <returns>Matching link</returns>
        public Link Get(int code)
        {
            return (from lien in SunAccess.Instance.Link
                    where lien.Id == code
                    select lien).First();
        }

        /// <summary>
        /// Returns all links
        /// </summary>
        /// <returns>List of links</returns>
        public IEnumerable<Link> Get()
        {
            IEnumerable<Link> results = (from l in SunAccess.Instance.Link
                                         orderby l.Order
                                         select l);

            return results;
        }

        /// <summary>
        /// Return last link id
        /// </summary>
        /// <returns>Last link id</returns>
        public int GetLastInsertedId()
        {
            return (from l in SunAccess.Instance.Link
                    orderby l.Id descending
                    select l).First().Id;
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
        public int Add(Link element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Link> rulesManager = new LinkRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Link.Add(element);
                SunAccess.Instance.SaveChanges();

                return element.Id;
            }

            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a link
        /// </summary>
        /// <param name="element">Edited link</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Link element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Link> rulesManager = new LinkRulesManager();
                rulesManager.Check(element);

                Link l = Get(element.Id);
                l.Label = element.Label;
                l.Url = element.Url;
                l.ImageUrl = element.ImageUrl;
                l.Description = element.Description;
                l.Order = element.Order;

                SunAccess.Instance.SaveChanges();
            }
            else
                throw new AccessDeniedException(username);
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
                Link lien = Get(code);
                SunAccess.Instance.Link.Remove(lien);

                SunAccess.Instance.SaveChanges();
            }
            else
                throw new AccessDeniedException(username);
        }

        #endregion
    }
}