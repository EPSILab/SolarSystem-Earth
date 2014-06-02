using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : ICampusReader
    {
        public Campus GetCampus(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Campus>>().Get(code);
        }

        public IEnumerable<Campus> GetCampuses()
        {
            return NinjectKernel.Kernel.Get<IReader<Campus>>().Get();
        }
    }
}