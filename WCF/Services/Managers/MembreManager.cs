using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IMembreManager
    {
        #region IMembreReader methods

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
            IReaderTwoFilters<Membre, Ville, Role> business = new MembreBusiness();
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

        #endregion

        #region IMembreManager methods

        public Membre Login(string username, string password)
        {
            ILogin<Membre> business = new MembreBusiness();
            return business.Login(username, password);
        }

        public bool Exists(string username, string password)
        {
            ILogin<Membre> business = new MembreBusiness();
            return business.Exists(username, password);
        }

        public int Register(Membre membre)
        {
            ILogin<Membre> business = new MembreBusiness();
            return business.Register(membre);
        }

        public int AddMembre(Membre element, string username, string password)
        {
            IManager<Membre> business = new MembreBusiness();
            return business.Add(element, username, password);
        }

        public void EditMembre(Membre element, string username, string password)
        {
            IManager<Membre> business = new MembreBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteMembre(int code, string username, string password)
        {
            IManager<Membre> business = new MembreBusiness();
            business.Delete(code, username, password);
        }

        #endregion
    }
}