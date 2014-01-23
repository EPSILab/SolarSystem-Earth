using System.Collections.Generic;
using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;

namespace EPSILab.SolarSystem.Earth.WCF
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