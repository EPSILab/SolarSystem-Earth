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
    /// Access to slide table
    /// </summary>
    class SlideDAL : ISlideDAL
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly IMemberDAL _memberDAL;

        #endregion

        #region Constructor

        public SlideDAL(IMemberDAL memberDAL)
        {
            _memberDAL = memberDAL;
        }

        #endregion

        #region IReader1Filter methods

        /// <summary>
        /// Get a advertising
        /// </summary>
        /// <param name="code">Advertising code</param>
        /// <returns>Matching advertising</returns>
        public Slide Get(int code)
        {
            return (from publicite in SunAccess.Instance.Slide
                    where publicite.Id == code
                    select publicite).First();
        }

        /// <summary>
        /// Get all advertisings
        /// </summary>
        /// <returns>List of advertisings</returns>
        public IEnumerable<Slide> Get()
        {
            return Get(0, 0);
        }

        /// <summary>
        /// Get a limited list of advertisings
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of advertising</returns>
        public IEnumerable<Slide> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(null, 0, 0);
        }

        /// <summary>
        /// Get all/published/not published advertisings
        /// </summary>
        /// <param name="published">Determines if advertising must be published, not published or indifferent</param>
        /// <returns>List of advertising</returns>
        public IEnumerable<Slide> Get(bool? published)
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
        public IEnumerable<Slide> Get(bool? published, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<Slide> results = (from p in SunAccess.Instance.Slide
                                              orderby p.Id descending
                                              select p);

            if (published.HasValue)
                results = (from p in results
                           where p.IsPublished == published
                           select p);

            results = results.Skip(indexFirstElement);

            if (numberOfResults > 0)
                results = results.Take(numberOfResults);

            return results;
        }

        /// <summary>
        /// Returns last advertising id
        /// </summary>
        /// <returns>Id the last advertising inserted</returns>
        public int GetLastInsertedId()
        {
            return (from p in SunAccess.Instance.Slide
                    orderby p.Id descending
                    select p).First().Id;
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
        public int Add(Slide element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Slide> rulesManager = new SlideRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Slide.Add(element);
                SunAccess.Instance.SaveChanges();

                return element.Id;
            }

            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a advertising
        /// </summary>
        /// <param name="element">Edited advertising</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Slide element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                Slide p = Get(element.Id);

                p.Name = element.Name;
                p.Presentation = element.Presentation;
                p.Url = element.Url;
                p.ImageUrl = element.ImageUrl;

                SunAccess.Instance.SaveChanges();
            }
            else
                throw new AccessDeniedException(username);
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
                Slide publicite = Get(code);

                SunAccess.Instance.Slide.Remove(publicite);
                SunAccess.Instance.SaveChanges();
            }
            else
                throw new AccessDeniedException(username);
        }

        #endregion
    }
}