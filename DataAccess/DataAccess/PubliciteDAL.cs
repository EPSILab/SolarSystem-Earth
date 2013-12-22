﻿using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;
using System.Collections.Generic;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class PubliciteDAL : DALBase, IReaderLimit<Publicite>, IManager<Publicite>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        #endregion

        #region IReaderLimit methods

        public Publicite Get(int code)
        {
            return (from publicite in Db.Publicite
                    where publicite.Code_Publicite == code
                    select publicite).First();
        }

        public IEnumerable<Publicite> Get()
        {
            return Get(0, 0);
        }

        public IEnumerable<Publicite> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<Publicite> results = (from publicite in Db.Publicite
                                              where publicite.Publiee
                                              select publicite);

            results = results.Skip(indexFirstElement);

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
            }

            return results;
        }

        public int GetLastInsertedId()
        {
            return (from p in Db.Publicite
                    orderby p.Code_Publicite descending
                    select p).First().Code_Publicite;
        }

        #endregion

        #region IManager methods

        public IEnumerable<Publicite> Get(int indexFirstResult, int numberOfResults, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                return Get(indexFirstResult, numberOfResults);
            }

            return null;
        }

        public Publicite Get(int code, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                return Get(code);
            }

            return null;
        }

        public int Add(Publicite element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Publicite> rulesManager = new PubliciteRulesManager();
                rulesManager.Check(element);

                Db.Publicite.AddObject(element);
                Db.SaveChanges();

                return element.Code_Publicite;
            }

            return 0;
        }

        public void Edit(Publicite element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                Publicite p = Get(element.Code_Publicite);

                p.Nom = element.Nom;
                p.Presentation = element.Presentation;
                p.URL = element.URL;
                p.Image = element.Image;

                Db.SaveChanges();
            }
        }

        public void Delete(int code, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                Publicite publicite = Get(code);

                Db.Publicite.DeleteObject(publicite);
                Db.SaveChanges();
            }
        }

        #endregion
    }
}