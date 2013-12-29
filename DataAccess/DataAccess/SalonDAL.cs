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
    public class SalonDAL : DALBase, IReaderSort<Salon>, ISearchable<Salon>, IManager<Salon>
    {
        #region Attributes

        private readonly MembreDAL _membreDAL = new MembreDAL();

        #endregion

        #region IReaderSort methods

        public Salon Get(int code)
        {
            return (from salon in Db.Salon
                    where salon.Code_Salon == code
                    select salon).First();
        }

        public IEnumerable<Salon> Get()
        {
            return Get(0, 0);
        }

        public IEnumerable<Salon> Get(int indexFirstElement, int numberOfResults)
        {
            return Get(indexFirstElement, numberOfResults, SortOrder.Descending);
        }

        public IEnumerable<Salon> Get(int indexFirstElement, int numberOfResults, SortOrder order)
        {
            IEnumerable<Salon> results = (from salon in Db.Salon
                                          where salon.Publie
                                          orderby salon.Date_Heure_Debut descending, salon.Date_Heure_Fin descending
                                          select salon);

            if (order == SortOrder.Ascending)
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
            return (from salon in Db.Salon
                    orderby salon.Code_Salon descending
                    select salon).First().Code_Salon;
        }

        #endregion

        #region ISearchable methods

        public IEnumerable<Salon> Search(string keywords)
        {
            IEnumerable<Salon> salons = new List<Salon>();

            if (!string.IsNullOrWhiteSpace(keywords))
            {
                keywords = keywords.ToLower();

                salons = (from salon in Db.Salon
                          where salon.Nom.ToLower().Contains(keywords) ||
                                salon.Lieu.ToLower().Contains(keywords)
                          orderby salon.Date_Heure_Debut descending
                          orderby salon.Date_Heure_Fin descending
                          select salon);
            }

            return salons;
        }

        #endregion

        #region IManager methods

        public int Add(Salon element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Salon> rulesManager = new SalonRulesManager();
                rulesManager.Check(element);

                Db.Salon.AddObject(element);
                Db.SaveChanges();

                return element.Code_Salon;
            }

                throw new AccessDeniedException(ErrorMessages_FR.ACCES_REFUSE);
        }

        public void Edit(Salon element, string username, string password)
        {
            if (_membreDAL.Exists(username, password))
            {
                IRulesManager<Salon> rulesManager = new SalonRulesManager();
                rulesManager.Check(element);

                Salon s = Get(element.Code_Salon);
                s.Nom = element.Nom;
                s.Date_Heure_Debut = element.Date_Heure_Debut;
                s.Date_Heure_Fin = element.Date_Heure_Fin;
                s.Lieu = element.Lieu;
                s.Image = element.Image;
                s.Description = element.Description;

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
                Salon salon = Get(code);
                Db.Salon.DeleteObject(salon);
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