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
    /// Access to links table
    /// </summary>
    class LinkDAL : ILinkDAL
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

        public LinkDAL(ILog log, IMemberDAL memberDAL)
        {
            _log = log;
            _memberDAL = memberDAL;
        }

        #endregion

        #region IReader methods

        /// <summary>
        /// Get a link
        /// </summary>
        /// <param name="code">Link code</param>
        /// <returns>Matching link</returns>
        public Link Get(int code)
        {
            Link link = (from lien in SunAccess.Instance.Link
                             where lien.Id == code
                             select lien).FirstOrDefault();

            if (link != null)
            {
                _log.Info(string.Format(LogMessages.GetLinkByCode, code));
                return link;
            }

            _log.Error(string.Format("{0} - code '{1}'", LogMessages.LinkNotFound, code));
            throw new ArgumentNullException();
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

            _log.Info(LogMessages.GetAllLinks);

            return results;
        }

        /// <summary>
        /// Return last link id
        /// </summary>
        /// <returns>Last link id</returns>
        public int GetLastInsertedId()
        {
            Link link = (from l in SunAccess.Instance.Link
                    orderby l.Id descending
                    select l).FirstOrDefault();

            if (link != null)
            {
                _log.Info(string.Format("{0} : {1}", LogMessages.GetLastLinkInsertedID, link.Id));
                return link.Id;
            }

            _log.Error(string.Format("{0} - {1}", LogMessages.GetLastLinkInsertedID, LogMessages.LinkNotFound));
            throw new ArgumentNullException();
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

                _log.Info(string.Format(LogMessages.AddLinkByUser, element.Label, username));

                return element.Id;
            }

            _log.Error(string.Format(LogMessages.AccessDeniedToUser, username));
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

                _log.Info(string.Format(LogMessages.EditLinkByUser, element.Label, username));
            }
            else
            {
                _log.Error(string.Format(LogMessages.AccessDeniedToUser, username));
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
                Link link = Get(code);
                SunAccess.Instance.Link.Remove(link);

                SunAccess.Instance.SaveChanges();

                _log.Info(string.Format(LogMessages.DeleteLinkByUser, link.Label, username));
            }
            else
            {
                _log.Error(string.Format(LogMessages.AccessDeniedToUser, username));
                throw new AccessDeniedException(username);
            }
        }

        #endregion
    }
}