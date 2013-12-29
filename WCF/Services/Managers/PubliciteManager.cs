using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IPubliciteManager
    {
        #region IPubliciteReader methods

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

        #endregion

        #region IPubliciteManager methods

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

        #endregion
    }
}