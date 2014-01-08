using System.Collections.Generic;
using System.Linq;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Exceptions;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager.Managers;
using SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces;

namespace SolarSystem.Earth.DataAccess.DAL
{
    /// <summary>
    /// Access to advertising table
    /// </summary>
    public class PubliciteDAL : IReader1Filter<Publicite, bool?>, IManager<Publicite>
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly MembreDAL _memberDAL = new MembreDAL();

        #endregion

        #region IReader1Filter methods

        /// <summary>
        /// Get a advertising
        /// </summary>
        /// <param name="code">Advertising code</param>
        /// <returns>Matching advertising</returns>
        public Publicite Get(int code)
        {
            return (from publicite in SunAccess.Instance.Publicite
                    where publicite.Code_Publicite == code
                    select publicite).First();
        }

        /// <summary>
        /// Get all advertisings
        /// </summary>
        /// <returns>List of advertisings</returns>
        public IEnumerable<Publicite> Get()
        {
            return Get(0, 0);
        }

        /// <summary>
        /// Get a limited list of advertisings
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of advertising</returns>
        public IEnumerable<Publicite> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(null, 0, 0);
        }

        /// <summary>
        /// Get all/published/not published advertisings
        /// </summary>
        /// <param name="published">Determines if advertising must be published, not published or indifferent</param>
        /// <returns>List of advertising</returns>
        public IEnumerable<Publicite> Get(bool? published)
        {
            return Get(published, 0, 0);
        }

        /// <summary>
        /// Get a limited list of all/published/not published advertisings
        /// </summary>
        /// <param name="published">Determines if advertising must be published, not published or indifferent</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of advertising</returns>
        public IEnumerable<Publicite> Get(bool? published, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<Publicite> results = (from p in SunAccess.Instance.Publicite
                                              orderby p.Code_Publicite descending
                                              select p);

            if (published.HasValue)
            {
                results = (from p in results
                           where p.Publiee == published
                           select p);
            }

            results = results.Skip(indexFirstElement);

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
            }

            return results;
        }

        /// <summary>
        /// Returns last advertising id
        /// </summary>
        /// <returns>Id the last advertising inserted</returns>
        public int GetLastInsertedId()
        {
            return (from p in SunAccess.Instance.Publicite
                    orderby p.Code_Publicite descending
                    select p).First().Code_Publicite;
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
        public int Add(Publicite element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Publicite> rulesManager = new PubliciteRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Publicite.AddObject(element);
                SunAccess.Instance.SaveChanges();

                return element.Code_Publicite;
            }

            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a advertising
        /// </summary>
        /// <param name="element">Edited advertising</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Publicite element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                Publicite p = Get(element.Code_Publicite);

                p.Nom = element.Nom;
                p.Presentation = element.Presentation;
                p.URL = element.URL;
                p.Image = element.Image;

                SunAccess.Instance.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException(username);
            }
        }

        /// <summary>
        /// Delete a advertising
        /// </summary>
        /// <param name="code">Advertising id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                Publicite publicite = Get(code);

                SunAccess.Instance.Publicite.DeleteObject(publicite);
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