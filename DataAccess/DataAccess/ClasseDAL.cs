using System.Collections.Generic;
using System.Linq;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Exceptions;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class ClasseDAL : DALBase, IReader<Classe>, IAvailable<Classe>, IManager<Classe>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        #endregion

        #region IReader methods

        public Classe Get(int code)
        {
            return (from c in Db.Classe
                    where c.Code_Classe == code
                    select c).First();
        }

        public IEnumerable<Classe> Get()
        {
            return Db.Classe;
        }

        public int GetLastInsertedId()
        {
            return (from c in Db.Classe
                    orderby c.Code_Classe descending
                    select c).First().Code_Classe;
        }

        #endregion

        #region IAvailable methods

        public IEnumerable<Classe> GetAvailables()
        {
            IEnumerable<Classe> results = (from c in Db.Classe
                                           where c.Encore_Presente
                                           orderby c.Annee_Promo_Sortante descending
                                           select c);

            return results;
        }

        #endregion

        #region IManager methods

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

            throw new AccessDeniedException();
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
                throw new AccessDeniedException();
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
                throw new AccessDeniedException();
            }
        }

        #endregion
    }
}