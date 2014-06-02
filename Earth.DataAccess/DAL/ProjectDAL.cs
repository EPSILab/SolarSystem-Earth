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
    /// Access to project table
    /// </summary>
    class ProjectDAL : IProjectDAL
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly IMemberDAL _memberDAL;

        #endregion

        #region Constructor

        public ProjectDAL(IMemberDAL memberDAL)
        {
            _memberDAL = memberDAL;
        }

        #endregion

        #region IReader1Filter methods

        /// <summary>
        /// Get a project
        /// </summary>
        /// <param name="code">Project id</param>
        /// <returns>Matching project</returns>
        public Project Get(int code)
        {
            return (from projet in SunAccess.Instance.Project
                    where projet.Id == code
                    select projet).First();
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <returns>List of projects</returns>
        public IEnumerable<Project> Get()
        {
            return Get(0, 0);
        }

        /// <summary>
        /// Get a limited list of projects
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of projects</returns>
        public IEnumerable<Project> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(null, indexFirstElement, numberOfResults);
        }

        /// <summary>
        /// Get projects of a city
        /// </summary>
        /// <param name="campus">Concerned city</param>
        /// <returns>List of projects</returns>
        public IEnumerable<Project> Get(Campus campus)
        {
            return Get(campus, 0, 0);
        }

        /// <summary>
        /// Get a limited list of projects of a city
        /// </summary>
        /// <param name="campus">City</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of projects</returns>
        public IEnumerable<Project> Get(Campus campus, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<Project> results = (from p in SunAccess.Instance.Project
                                           orderby p.Id descending
                                           select p);

            if (campus != null)
                results = (from p in results
                           where p.Id == campus.Id
                           select p);

            results = results.Skip(indexFirstElement);

            if (numberOfResults > 0)
                results = results.Take(numberOfResults);

            return results;
        }

        /// <summary>
        /// Returns last project id
        /// </summary>
        /// <returns>Id the last inserted project</returns>
        public int GetLastInsertedId()
        {
            return (from p in SunAccess.Instance.Project
                    orderby p.Id descending
                    select p).First().Id;
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a project
        /// </summary>
        /// <param name="element">Project to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New project id</returns>
        public int Add(Project element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Project> rulesManager = new ProjectRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Project.Add(element);
                SunAccess.Instance.SaveChanges();

                return element.Id;
            }

            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a project
        /// </summary>
        /// <param name="element">Edited project</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Project element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Project> rulesManager = new ProjectRulesManager();
                rulesManager.Check(element);

                Project p = Get(element.Id);

                p.Id = element.Id;
                p.Name = element.Name;
                p.Description = element.Description;
                p.Progression = element.Progression;
                p.ImageUrl = element.ImageUrl;

                SunAccess.Instance.SaveChanges();
            }
            else
                throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Delete a project
        /// </summary>
        /// <param name="code">Project id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                Project projet = Get(code);

                SunAccess.Instance.Project.Remove(projet);
                SunAccess.Instance.SaveChanges();
            }
            else
                throw new AccessDeniedException(username);
        }

        #endregion
    }
}