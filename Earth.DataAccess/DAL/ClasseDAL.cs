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
    /// Access to promos table
    /// </summary>
    public class ClasseDAL : IReader<Classe>, IAvailable<Classe>, IManager<Classe>
    {
        #region Attributes

        /// <summary>
        /// Access to member table
        /// </summary>
        private readonly MembreDAL _memberDAL = new MembreDAL();

        #endregion

        #region IReader methods

        /// <summary>
        /// Get one promo
        /// </summary>
        /// <param name="code">Promo id</param>
        /// <returns>Matching promo</returns>
        public Classe Get(int code)
        {
            return (from c in SunAccess.Instance.Classe
                    where c.Code_Classe == code
                    select c).First();
        }

        /// <summary>
        /// Returns all promos
        /// </summary>
        /// <returns>List of promos</returns>
        public IEnumerable<Classe> Get()
        {
            return (from c in SunAccess.Instance.Classe
                    orderby c.Code_Classe descending
                    select c);
        }

        /// <summary>
        /// Returns last promo id
        /// </summary>
        /// <returns>Id the last inserted promo</returns>
        public int GetLastInsertedId()
        {
            return (from c in SunAccess.Instance.Classe
                    orderby c.Code_Classe descending
                    select c).First().Code_Classe;
        }

        #endregion

        #region IAvailable methods

        /// <summary>
        /// Get all availables promos for new members
        /// </summary>
        /// <returns>List of promos</returns>
        public IEnumerable<Classe> GetAvailables()
        {
            IEnumerable<Classe> results = (from c in SunAccess.Instance.Classe
                                           where c.Encore_Presente
                                           orderby c.Annee_Promo_Sortante descending
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
        public int Add(Classe element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Classe> rulesManager = new ClasseRulesManager();
                rulesManager.Check(element);

                SunAccess.Instance.Classe.AddObject(element);
                SunAccess.Instance.SaveChanges();

                return element.Code_Classe;
            }

            throw new AccessDeniedException(username);
        }

        /// <summary>
        /// Edit a promo
        /// </summary>
        /// <param name="element">Edited promo</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(Classe element, string username, string password)
        {
            if (_memberDAL.Exists(username, password))
            {
                IRulesManager<Classe> rulesManager = new ClasseRulesManager();
                rulesManager.Check(element);

                Classe c = Get(element.Code_Classe);
                c.Libelle = element.Libelle;
                c.Annee_Promo_Sortante = element.Annee_Promo_Sortante;
                c.Encore_Presente = element.Encore_Presente;

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
                Classe classe = Get(code);

                if (classe != null)
                {
                    SunAccess.Instance.Classe.DeleteObject(classe);
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