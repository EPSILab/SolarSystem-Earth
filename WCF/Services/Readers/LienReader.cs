using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ReadersService : ILienReader
    {
        public Lien GetLien(int code)
        {
            IReader<Lien> business = new LienBusiness();
            return business.Get(code);
        }

        public IEnumerable<Lien> GetLiens()
        {
            IReader<Lien> business = new LienBusiness();
            return business.Get();
        }
    }
}