using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : IPubliciteReader
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
    }
}