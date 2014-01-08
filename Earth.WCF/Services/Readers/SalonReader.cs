using System.Collections.Generic;
using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Readers;

namespace SolarSystem.Earth.WCF
{
    public partial class ReadersService : ISalonReader
    {
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
    }
}