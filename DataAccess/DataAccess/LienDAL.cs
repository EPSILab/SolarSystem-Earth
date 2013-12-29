using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Resources;
using SolarSystem.Earth.DataAccess.Exceptions;
using SolarSystem.Earth.DataAccess.Model;
using SolarSystem.Earth.DataAccess.RulesManager;
using System.Collections.Generic;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class LienDAL : DALBase, IManager<Lien>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        #endregion

        #region IManager methods

        public Lien Get(int code)
        {
            return (from lien in Db.Lien
                    where lien.Code_Lien == code
                    select lien).First();
        }

        public IEnumerable<Lien> Get()
        {
            return Get(0, 0);
        }

        public IEnumerable<Lien> Get(int indexFirstResult, int numberOfResults)
        {
            IEnumerable<Lien> results = (from l in Db.Lien
                                         orderby l.Ordre
                                         select l);

            results = results.Skip(indexFirstResult);

            if (numberOfResults > 0)
            {
                results = results.Take(numberOfResults);
            }

            return results;
        }

        public int GetLastInsertedId()
        {
            return (from l in Db.Lien
                    orderby l.Code_Lien descending
                    select l).First().Code_Lien;
        }

        public int Add(Lien element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Lien> rulesManager = new LienRulesManager();
                rulesManager.Check(element);

                Db.Lien.AddObject(element);
                Db.SaveChanges();

                return element.Code_Lien;
            }
                throw new AccesRefuseException(ErrorMessages_FR.ACCES_REFUSE);
        }

        public void Edit(Lien element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Lien> rulesManager = new LienRulesManager();
                rulesManager.Check(element);

                Lien l = Get(element.Code_Lien);
                l.Nom = element.Nom;
                l.URL = element.URL;
                l.Image = element.Image;
                l.Description = element.Description;
                l.Ordre = element.Ordre;

                Db.SaveChanges();
            }
            else
            {
                throw new AccesRefuseException(ErrorMessages_FR.ACCES_REFUSE);
            }
        }

        public void Delete(int code, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                Lien lien = Get(code);
                Db.Lien.DeleteObject(lien);

                Db.SaveChanges();
            }
            else
            {
                throw new AccesRefuseException(ErrorMessages_FR.ACCES_REFUSE);
            }
        }

        #endregion
    }
}