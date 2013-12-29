using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : ISalonManager
    {
        #region ISalonReader methods

        public Salon GetSalon(int code)
        {
            IReader<Salon> business = new SalonBusiness();
            return business.Get(code);
        }

        public IEnumerable<Salon> GetSalons()
        {
            IReader<Salon> business = new SalonBusiness();
            return business.Get();
        }

        public IEnumerable<Salon> GetSalonsLimited(int indexFirstElement, int numberOfResults)
        {
            IReaderLimit<Salon> business = new SalonBusiness();
            return business.Get(indexFirstElement, numberOfResults);
        }

        public IEnumerable<Salon> GetSalonsSorted(int indexFirstElement, int numberOfResults, SortOrder order)
        {
            IReaderSort<Salon> business = new SalonBusiness();
            return business.Get(indexFirstElement, numberOfResults, order);
        }

        public int GetSalonLastInsertedId()
        {
            IReaderLimit<Salon> business = new SalonBusiness();
            return business.GetLastInsertedId();
        }

        public IEnumerable<Salon> SearchSalons(string keywords)
        {
            ISearchable<Salon> business = new SalonBusiness();
            return business.Search(keywords);
        }

        #endregion

        #region ISalonManager methods

        public int AddSalon(Salon element, string username, string password)
        {
            IManager<Salon> business = new SalonBusiness();
            return business.Add(element, username, password);
        }

        public void EditSalon(Salon element, string username, string password)
        {
            IManager<Salon> business = new SalonBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteSalon(int code, string username, string password)
        {
            IManager<Salon> business = new SalonBusiness();
            business.Delete(code, username, password);
        }

        #endregion
    }
}