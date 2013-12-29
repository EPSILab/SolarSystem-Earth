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

        public IEnumerable<Membre> GetMembresByVilleAndRole(Ville ville, Role role)
        {
            IReaderTwoFilters<Membre, Ville, Role> business = new MembreBusiness();
            return business.Get(ville, role, 0, 0, SortOrder.Ascending);
        }

        public Membre Login(string username, string password)
        {
            ILogin<Membre, RecupMotDePasse> business = new MembreBusiness();
            return business.Login(username, password);
        }

        public bool ExistsMembre(string username, string password)
        {
            ILogin<Membre, RecupMotDePasse> business = new MembreBusiness();
            return business.Exists(username, password);
        }

        public bool ExistsUsername(string username)
        {
            ILogin<Membre, RecupMotDePasse> business = new MembreBusiness();
            return business.Exists(username);
        }

        public int Register(Membre membre)
        {
            ILogin<Membre, RecupMotDePasse> business = new MembreBusiness();
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
    }
}