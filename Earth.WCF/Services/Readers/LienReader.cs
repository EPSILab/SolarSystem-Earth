using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
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