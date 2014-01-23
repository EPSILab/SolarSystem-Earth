using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : IPubliciteManager
    {
        public Publicite GetPublicite(int code)
        {
            IReader<Publicite> business = new PubliciteBusiness();
            return business.Get(code);
        }

        public IEnumerable<Publicite> GetPublicites()
        {
            IReader<Publicite> business = new PubliciteBusiness();
            return business.Get();
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