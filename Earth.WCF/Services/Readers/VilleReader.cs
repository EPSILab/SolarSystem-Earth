using System.Collections.Generic;
using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Readers;

namespace SolarSystem.Earth.WCF
{
    public partial class ReadersService : IVilleReader
    {
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
    }
}