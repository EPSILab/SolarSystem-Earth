using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : ILienManager
    {
        public Lien GetLien(int code, string username, string password)
        {
            IManager<Lien> business = new LienBusiness();
            return business.Get(code, username, password);
        }

        public IEnumerable<Lien> GetLiens(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IManager<Lien> business = new LienBusiness();
            return business.Get(indexFirstResult, numberOfResults, username, password);
        }

        public int AddLien(Lien element, string username, string password)
        {
            IManager<Lien> business = new LienBusiness();
            return business.Add(element, username, password);
        }

        public void EditLien(Lien element, string username, string password)
        {
            IManager<Lien> business = new LienBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteLien(int code, string username, string password)
        {
            IManager<Lien> business = new LienBusiness();
            business.Delete(code, username, password);
        }
    }
}