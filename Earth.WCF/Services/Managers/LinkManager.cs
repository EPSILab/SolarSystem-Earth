using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : ILinkManager
    {
        #region ILinkReader methods

        public Link GetLink(int code)
        {
            IReader<Link> business = new LinkBusiness();
            return business.Get(code);
        }

        public IEnumerable<Link> GetLinks()
        {
            IReader<Link> business = new LinkBusiness();
            return business.Get();
        }

        #endregion
        

        #region ILinkManager methods

        public int AddLink(Link element, string username, string password)
        {
            IManager<Link> business = new LinkBusiness();
            return business.Add(element, username, password);
        }

        public void EditLink(Link element, string username, string password)
        {
            IManager<Link> business = new LinkBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteLink(int code, string username, string password)
        {
            IManager<Link> business = new LinkBusiness();
            business.Delete(code, username, password);
        }

        #endregion
    }
}