using System;
using System.Text;
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
    /// Access to project table
    /// </summary>
    class ProjectDAL : IProjectDAL
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

        public ProjectDAL(ILog log, IMemberDAL memberDAL)
        {
            _log = log;
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
            Project project = (from projet in SunAccess.Instance.Project
                               where projet.Id == code
                               select projet).FirstOrDefault();

            if (project != null)
            {
                _log.Info(string.Format(LogMessages.GetProjectByCode, code));
                return project;
            }

            _log.Error(string.Format("{0} - code '{1}'", LogMessages.ProjectNotFound, code));
            throw new ArgumentNullException();
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
            StringBuilder logBuilder = new StringBuilder(LogMessages.GetAllProjects);

            IEnumerable<Project> results = (from p in SunAccess.Instance.Project
                                            orderby p.Id descending
                                            select p);

            if (campus != null)
            {
                results = (from p in results
                           where p.Id == campus.Id
                           select p);
                logBuilder.Append(string.Format(" - {0} : {1}", LogMessages.Campus, campus.Place));
            }

            results = results.Skip(indexFirstElement);
            logBuilder.Append(string.Format(" - {0} : {1}", LogMessages.IndexFirstElement, indexFirstElement));

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
                logBuilder.Append(string.Format(" - {0} : {1}", LogMessages.NumberOfResults, numberOfResults));
            }

            _log.Info(logBuilder.ToString());

            return results;
        }

        /// <summary>
        /// Returns last project id
        /// </summary>
        /// <returns>Id the last inserted project</returns>
        public int GetLastInsertedId()
        {
            Project project = (from p in SunAccess.Instance.Project
                               orderby p.Id descending
                               select p).FirstOrDefault();

            if (project != null)
            {
                _log.Info(string.Format("{0} : {1}", LogMessages.GetLastProjectInsertedID, project.Id));
                return project.Id;
            }

            _log.Error(string.Format("{0} - {1}", LogMessages.GetLastProjectInsertedID, LogMessages.ProjectNotFound));
            throw new ArgumentNullException();
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

                _log.Info(string.Format(LogMessages.AddProjectByUser, element.Name, username));

                return element.Id;
            }

            _log.Error(string.Format(LogMessages.AccessDeniedToUser, username));
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

                _log.Info(string.Format(LogMessages.EditProjectByUser, element.Name, username));
            }
            else
            {
                _log.Error(string.Format(LogMessages.AccessDeniedToUser, username));
                throw new AccessDeniedException(username);
            }
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
                Project project = Get(code);

                SunAccess.Instance.Project.Remove(project);
                SunAccess.Instance.SaveChanges();

                _log.Info(string.Format(LogMessages.DeleteProjectByUser, project.Name, username));
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