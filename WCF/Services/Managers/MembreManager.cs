using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IMembreManager
    {
        public int Login(string username, string password)
        {
            ILogin business = new MembreBusiness();
            return business.Login(username, password);
        }

        public bool Exists(string username, string password)
        {
            ILogin business = new MembreBusiness();
            return business.Exists(username, password);
        }

        public Membre GetMembre(int code, string username, string password)
        {
            IManager<Membre> business = new MembreBusiness();
            return business.Get(code, username, password);
        }

        public IEnumerable<Membre> GetMembres(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IManager<Membre> business = new MembreBusiness();
            return business.Get(indexFirstResult, numberOfResults, username, password);
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
    }
}