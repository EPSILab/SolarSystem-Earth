using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : ISalonManager
    {
        public Salon GetSalon(int code)
        {
            IReader<Salon> business = new SalonBusiness();
            return business.Get(code);
        }

        public IEnumerable<Salon> GetSalons(int indexFirstElement, int numberOfResults)
        {
            IReaderLimit<Salon> business = new SalonBusiness();
            return business.Get(indexFirstElement, numberOfResults);
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