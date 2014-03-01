using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : ILinkReader
    {
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
    }
}