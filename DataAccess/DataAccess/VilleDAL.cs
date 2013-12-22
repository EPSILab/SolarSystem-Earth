using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;
using System.Collections.Generic;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class VilleDAL : DALBase, IReaderLimit<Ville>, IManager<Ville>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        #endregion

        #region IReaderLimit methods

        public Ville Get(int code)
        {
            return (from ville in Db.Ville
                    where ville.Code_Ville == code
                    select ville).First();
        }

        public IEnumerable<Ville> Get()
        {
            return Get(0, 0);
        }

        public IEnumerable<Ville> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<Ville> results = (from r in Db.Ville
                                          select r);

            results = results.Skip(indexFirstElement);

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
            }

            return results;
        }

        public int GetLastInsertedId()
        {
            return (from ville in Db.Ville
                    orderby ville.Code_Ville descending
                    select ville).First().Code_Ville; 
        }

        #endregion

        #region IManager methods

        public IEnumerable<Ville> Get(int indexFirstResult, int numberOfResults, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                return Get(indexFirstResult, numberOfResults);
            }

            return null;
        }

        public Ville Get(int code, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                return Get(code);
            }

            return null;
        }

        public int Add(Ville element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                Db.Ville.AddObject(element);
                Db.SaveChanges();

                return element.Code_Ville;
            }

            return 0;
        }

        public void Edit(Ville element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Ville> rulesManager = new VilleRulesManager();
                rulesManager.Check(element);

                Ville v = Get(element.Code_Ville);
                v.Libelle = element.Libelle;

                Db.SaveChanges();
            }
        }

        public void Delete(int code, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                Ville v = Get(code);
                Db.Ville.DeleteObject(v);

                Db.SaveChanges();
            }
        }

        #endregion
    }
}