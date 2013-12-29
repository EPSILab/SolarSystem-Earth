using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Exceptions;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class ProjetDAL : DALBase, IReaderOneFilter<Projet, Ville>, IManager<Projet>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        #endregion

        #region IReaderOneFilter methods

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

        public IEnumerable<Projet> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(indexFirstElement, numberOfResults, SortOrder.Ascending);
        }

        public IEnumerable<Projet> Get(int indexFirstElement, int numberOfResults, SortOrder order)
        {
            return Get(null, indexFirstElement, numberOfResults, order);
        }

        public IEnumerable<Projet> Get(Ville filter, int indexFirstElement, int numberOfResults, SortOrder order)
        {
            IEnumerable<Projet> results = (from projet in Db.Projet
                                           select projet);

            if (filter != null)
            {
                results = Db.Projet.Where(p => p.Code_Ville == filter.Code_Ville);
            }

            if (order == SortOrder.Descending)
            {
                results = results.Reverse();
            }

            results = results.Skip(indexFirstElement);

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
                throw new AccessDeniedException(ErrorMessages_FR.ACCES_REFUSE);
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
                throw new AccessDeniedException(ErrorMessages_FR.ACCES_REFUSE);
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
                throw new AccessDeniedException(ErrorMessages_FR.ACCES_REFUSE);
            }
        }

        #endregion
    }
}