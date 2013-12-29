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

        public void ChangePassword(string username, string oldPassword, string newPassword)
        {
            ILogin<Membre, RecupMotDePasse> business = new MembreBusiness();
            business.ChangePassword(username, oldPassword, newPassword);
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

        public void RequestLostPassword(string username, string email)
        {
            ILogin<Membre, RecupMotDePasse> business = new MembreBusiness();
            business.RequestLostPassword(username, email);
        }

        public void SetNewPasswordAfterLost(string username, string newPassword, string key)
        {
            ILogin<Membre, RecupMotDePasse> business = new MembreBusiness();
            business.SetNewPasswordAfterLost(username, newPassword, key);
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