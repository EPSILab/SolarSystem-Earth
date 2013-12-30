using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SolarSystem.Earth.WCF
{
    public partial class ReadersService : IMembreReader
    {
        public Membre GetMembre(int code)
        {
            IReader<Membre> business = new MembreBusiness();
            return business.Get(code);
        }

        public IEnumerable<Membre> GetMembres()
        {
            IReader<Membre> business = new MembreBusiness();
            return business.Get();
        }

        public IEnumerable<Membre> GetMembresLimited(int indexFirstElement, int numberOfResults)
        {
            IReaderLimit<Membre> business = new MembreBusiness();
            return business.Get(indexFirstElement, numberOfResults);
        }

        public IEnumerable<Membre> GetMembresSorted(int indexFirstElement, int numberOrResults, SortOrder order)
        {
            IReaderSort<Membre> business = new MembreBusiness();
            return business.Get(indexFirstElement, numberOrResults, order);
        }

        public IEnumerable<Membre> GetMembresByVilleAndRole(Ville ville, Role role, int indexFirstResult, int numberOfResults, SortOrder order)
        {
            IReader2Filters<Membre, Ville, Role> business = new MembreBusiness();
            return business.Get(ville, role, indexFirstResult, numberOfResults, order);
        }

        public int GetMembreLastInsertedId()
        {
            IReaderLimit<Membre> business = new MembreBusiness();
            return business.GetLastInsertedId();
        }

        public IEnumerable<Membre> SearchMembres(string keywords)
        {
            ISearchable<Membre> business = new MembreBusiness();
            return business.Search(keywords);
        }
    }
}