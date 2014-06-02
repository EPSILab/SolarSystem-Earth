using EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract;
using EPSILab.SolarSystem.Earth.DataAccess.Exceptions;
using EPSILab.SolarSystem.Earth.DataAccess.Model;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers;
using EPSILab.SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Access to promos table
    /// </summary>
    class PromotionDAL : IPromotionDAL
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly IMemberDAL _memberDAL;

        #endregion

        #region Constructor

        public PromotionDAL(IMemberDAL memberDAL)
        {
            _memberDAL = memberDAL;
        }

        #endregion

        #region IReader methods

        /// <summary>
        /// Get one promo
        /// </summary>
        /// <param name="code">Promo id</param>
        /// <returns>Matching promo</returns>
        public Promotion Get(int code)
        {
            return (from p in SunAccess.Instance.Promotion
                    where p.Id == code
                    select p).First();
        }

        /// <summary>
        /// Returns all promos
        /// </summary>
        /// <returns>List of promos</returns>
        public IEnumerable<Promotion> Get()
        {
            return (from p in SunAccess.Instance.Promotion
                    orderby p.Id descending
                    select p);
        }

        /// <summary>
        /// Returns last promo id
        /// </summary>
        /// <returns>Id the last inserted promo</returns>
        public int GetLastInsertedId()
        {
            return (from c in SunAccess.Instance.Promotion
                    orderby c.Id descending
                    select c).First().Id;
        }

        #endregion

        #region IAvailable methods

        /// <summary>
        /// Get all availables promos for new members
        /// </summary>
        /// <returns>List of promos</returns>
        public IEnumerable<Promotion> GetAvailables()
        {
            IEnumerable<Promotion> results = (from c in SunAccess.Instance.Promotion
                                              where c.StillPresent
                                              orderby c.GraduationYear descending
                                              select c);

            return results;
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a promo
        /// </summary>
        /// <param name="element">Promo to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New promo id</returns>
        public int Add(Promotion element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Promotion> rulesManager = new PromotionRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Promotion.Add(element);
                SunAccess.Instance.SaveChanges();

                return element.Id;
            }

            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a promo
        /// </summary>
        /// <param name="element">Edited promo</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Promotion element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Promotion> rulesManager = new PromotionRulesManager();
                rulesManager.Check(element);

                Promotion p = Get(element.Id);
                p.Name = element.Name;
                p.GraduationYear = element.GraduationYear;
                p.StillPresent = element.StillPresent;

                SunAccess.Instance.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException(username);
            }
        }

        /// <summary>
        /// Delete a promo
        /// </summary>
        /// <param name="code">Promo id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                Promotion p = Get(code);

                if (p != null)
                {
                    SunAccess.Instance.Promotion.Remove(p);
                    SunAccess.Instance.SaveChanges();
                }
            }
            else
            {
                throw new AccessDeniedException(username);
            }
        }

        #endregion
    }
}