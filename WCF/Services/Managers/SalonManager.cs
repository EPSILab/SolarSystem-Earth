using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : ISalonManager
    {
        public Salon GetSalon(int code, string username, string password)
        {
            IManager<Salon> business = new SalonBusiness();
            return business.Get(code, username, password);
        }

        public IEnumerable<Salon> GetSalons(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IManager<Salon> business = new SalonBusiness();
            return business.Get(indexFirstResult, numberOfResults, username, password);
        }

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
    }
}