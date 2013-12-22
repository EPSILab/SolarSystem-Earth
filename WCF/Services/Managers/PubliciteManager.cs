using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IPubliciteManager
    {
        public IEnumerable<Publicite> GetPublicites(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IManager<Publicite> business = new PubliciteBusiness();
            return business.Get(indexFirstResult, numberOfResults, username, password);
        }

        public Publicite GetPublicite(int code, string username, string password)
        {
            IManager<Publicite> business = new PubliciteBusiness();
            return business.Get(code, username, password);
        }

        public int AddPublicite(Publicite element, string username, string password)
        {
            IManager<Publicite> business = new PubliciteBusiness();
            return business.Add(element, username, password);
        }

        public void EditPublicite(Publicite element, string username, string password)
        {
            IManager<Publicite> business = new PubliciteBusiness();
            business.Edit(element, username, password);
        }

        public void DeletePublicite(int code, string username, string password)
        {
            IManager<Publicite> business = new PubliciteBusiness();
            business.Delete(code, username, password);
        }
    }
}