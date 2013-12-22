using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;
using System.Collections.Generic;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class ClasseDAL : DALBase, IManager<Classe>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        #endregion

        #region IManager methods

        public Classe Get(int code, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                return (from c in Db.Classe
                        where c.Code_Classe == code
                        select c).First();
            }

            return null;
        }

        public IEnumerable<Classe> Get(int indexFirstResult, int numberOfResults, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                return (from c in Db.Classe
                        orderby c.Annee_Promo_Sortante
                        select c);
            }

            return null;
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

            return 0;
        }

        public void Edit(Classe element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Classe> rulesManager = new ClasseRulesManager();
                rulesManager.Check(element);

                Classe c = Get(element.Code_Classe, username, password);
                c.Libelle = element.Libelle;
                c.Annee_Promo_Sortante = element.Annee_Promo_Sortante;
                c.Encore_Presente = element.Encore_Presente;

                Db.SaveChanges();
            }
        }

        public void Delete(int code, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                Classe classe = Get(code, username, password);

                if (classe != null)
                {
                    Db.Classe.DeleteObject(classe);
                    Db.SaveChanges();
                }
            }
        }

        #endregion
    }
}