using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Exceptions;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class ProjetDAL : DALBase, IReader1Filter<Projet, Ville>, IManager<Projet>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        #endregion

        #region IReader1Filter methods

        public Projet Get(int code)
        {
            return (from projet in Db.Projet
                    where projet.Code_Projet == code
                    select projet).First();
        }

        public IEnumerable<Projet> Get()
        {
            return Get(0, 0);
        }

        public IEnumerable<Projet> Get(int indexFirstResult, int numberOfResults)
        {
            return Get(null, indexFirstResult, numberOfResults);
        }

        public IEnumerable<Projet> Get(Ville ville)
        {
            return Get(ville, 0, 0);
        }

        public IEnumerable<Projet> Get(Ville ville, int indexFirstResult, int numberOfResults)
        {
            IEnumerable<Projet> results = (from p in Db.Projet
                                           orderby p.Code_Projet descending
                                           select p);

            if (ville != null)
            {
                results = (from p in results
                           where p.Code_Ville == ville.Code_Ville
                           select p);
            }

            results = results.Skip(indexFirstResult);

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
            }

            return results;
        }

        public int GetLastInsertedId()
        {
            return (from p in Db.Projet
                    orderby p.Code_Projet descending
                    select p).First().Code_Projet;
        }

        #endregion

        #region IManager methods

        public int Add(Projet element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Projet> rulesManager = new ProjetRulesManager();
                rulesManager.Check(element);

                Db.Projet.AddObject(element);
                Db.SaveChanges();

                return element.Code_Projet;
            }
            throw new AccessDeniedException();
        }

        public void Edit(Projet element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Projet> rulesManager = new ProjetRulesManager();
                rulesManager.Check(element);

                Projet p = Get(element.Code_Projet);

                p.Code_Ville = element.Code_Ville;
                p.Nom = element.Nom;
                p.Description = element.Description;
                p.Avancement = element.Avancement;
                p.Image = element.Image;

                Db.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException();
            }
        }

        public void Delete(int code, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                Projet projet = Get(code);

                Db.Projet.DeleteObject(projet);
                Db.SaveChanges();
            }
            else
            {
                throw new AccessDeniedException();
            }
        }

        #endregion
    }
}