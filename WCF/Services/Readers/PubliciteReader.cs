using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
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