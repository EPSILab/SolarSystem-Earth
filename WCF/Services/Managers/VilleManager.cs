using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IVilleManager
    {
        #region IVilleReader methods

        public Ville GetVille(int code)
        {
            IReader<Ville> business = new VilleBusiness();
            return business.Get(code);
        }

        public IEnumerable<Ville> GetVilles()
        {
            IReader<Ville> business = new VilleBusiness();
            return business.Get();
        }

        #endregion

        #region IVilleManager methods

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

        #endregion
    }
}