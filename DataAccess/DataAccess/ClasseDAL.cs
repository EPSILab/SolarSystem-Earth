using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Exceptions;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;
using System.Collections.Generic;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class ClasseDAL : DALBase, IManager<Classe>, IAvailable<Classe>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        #endregion

        #region IManager methods

        public Classe Get(int code)
        {
            return (from c in Db.Classe
                    where c.Code_Classe == code
                    select c).First();
        }

        public IEnumerable<Classe> Get()
        {
            return Get(0, 0);
        }

        public IEnumerable<Classe> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<Classe> results = (from c in Db.Classe
                                           orderby c.Annee_Promo_Sortante
                                           select c);

            results = results.Skip(indexFirstElement);

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
            }

            return results;
        }

        public int GetLastInsertedId()
        {
            return (from c in Db.Classe
                    orderby c.Code_Classe descending
                    select c).First().Code_Classe;
        }

        public int Add(Classe element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Classe> rulesManager = new ClasseRulesManager();
                rulesManager.Check(element);

                Db.Classe.AddObject(element);
                Db.SaveChanges();

                return element.Code_Classe;
            }
            
            throw new AccessDeniedException(ErrorMessages_FR.ACCES_REFUSE);
        }

        public void Edit(Classe element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Classe> rulesManager = new ClasseRulesManager();
                rulesManager.Check(element);

                Classe c = Get(element.Code_Classe);
                c.Libelle = element.Libelle;
                c.Annee_Promo_Sortante = element.Annee_Promo_Sortante;
                c.Encore_Presente = element.Encore_Presente;

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
                Classe classe = Get(code);

                if (classe != null)
                {
                    Db.Classe.DeleteObject(classe);
                    Db.SaveChanges();
                }
            }
            else
            {
                throw new AccessDeniedException(ErrorMessages_FR.ACCES_REFUSE);
            }
        }

        #endregion

        #region IManager methods

        public IEnumerable<Classe> GetAvailables()
        {
            IEnumerable<Classe> results = (from c in Db.Classe
                                           where c.Encore_Presente == true
                                           orderby c.Annee_Promo_Sortante descending
                                           select c);

            return results;
        }

        #endregion
    }
}