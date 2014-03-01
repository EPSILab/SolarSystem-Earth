using System.Collections.Generic;
using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : ICampusReader
    {
        public Campus GetCampus(int code)
        {
            IReader<Campus> business = new CampusBusiness();
            return business.Get(code);
        }

        public IEnumerable<Campus> GetCampuss()
        {
            IReader<Campus> business = new CampusBusiness();
            return business.Get();
        }
    }
}