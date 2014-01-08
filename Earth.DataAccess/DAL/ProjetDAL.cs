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
    /// Access to project table
    /// </summary>
    public class ProjetDAL : IReader1Filter<Projet, Ville>, IManager<Projet>
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly MembreDAL _memberDAL = new MembreDAL();

        #endregion

        #region IReader1Filter methods

        /// <summary>
        /// Get a project
        /// </summary>
        /// <param name="code">Project id</param>
        /// <returns>Matching project</returns>
        public Projet Get(int code)
        {
            return (from projet in SunAccess.Instance.Projet
                    where projet.Code_Projet == code
                    select projet).First();
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <returns>List of projects</returns>
        public IEnumerable<Projet> Get()
        {
            return Get(0, 0);
        }

        /// <summary>
        /// Get a limited list of projects
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of projects</returns>
        public IEnumerable<Projet> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(null, indexFirstElement, numberOfResults);
        }

        /// <summary>
        /// Get projects of a city
        /// </summary>
        /// <param name="ville">Concerned city</param>
        /// <returns>List of projects</returns>
        public IEnumerable<Projet> Get(Ville ville)
        {
            return Get(ville, 0, 0);
        }

        /// <summary>
        /// Get a limited list of projects of a city
        /// </summary>
        /// <param name="ville">City</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of projects</returns>
        public IEnumerable<Projet> Get(Ville ville, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<Projet> results = (from p in SunAccess.Instance.Projet
                                           orderby p.Code_Projet descending
                                           select p);

            if (ville != null)
            {
                results = (from p in results
                           where p.Code_Ville == ville.Code_Ville
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
        /// Returns last project id
        /// </summary>
        /// <returns>Id the last inserted project</returns>
        public int GetLastInsertedId()
        {
            return (from p in SunAccess.Instance.Projet
                    orderby p.Code_Projet descending
                    select p).First().Code_Projet;
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
        public int Add(Projet element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Projet> rulesManager = new ProjetRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Projet.AddObject(element);
                SunAccess.Instance.SaveChanges();

                return element.Code_Projet;
            }

            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a project
        /// </summary>
        /// <param name="element">Edited project</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Projet element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Projet> rulesManager = new ProjetRulesManager();
                rulesManager.Check(element);

                Projet p = Get(element.Code_Projet);

                p.Code_Ville = element.Code_Ville;
                p.Nom = element.Nom;
                p.Description = element.Description;
                p.Avancement = element.Avancement;
                p.Image = element.Image;

                SunAccess.Instance.SaveChanges();
            }
            else
            {
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
                Projet projet = Get(code);

                SunAccess.Instance.Projet.DeleteObject(projet);
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