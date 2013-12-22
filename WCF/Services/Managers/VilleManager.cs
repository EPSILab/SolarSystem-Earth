using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IVilleManager
    {
        public Ville GetVille(int code, string username, string password)
        {
            IManager<Ville> business = new VilleBusiness();
            return business.Get(code, username, password);
        }

        public IEnumerable<Ville> GetVilles(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IManager<Ville> business = new VilleBusiness();
            return business.Get(indexFirstResult, numberOfResults, username, password);
        }

        public int AddVille(Ville element, string username, string password)
        {
            IManager<Ville> business = new VilleBusiness();
            return business.Add(element, username, password);
        }

        public void EditVille(Ville element, string username, string password)
        {
            IManager<Ville> business = new VilleBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteVille(int code, string username, string password)
        {
            IManager<Ville> business = new VilleBusiness();
            business.Delete(code, username, password);
        }
    }
}