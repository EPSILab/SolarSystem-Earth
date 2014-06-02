using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : ILinkReader
    {
        public Link GetLink(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Link>>().Get(code);
        }

        public IEnumerable<Link> GetLinks()
        {
            return NinjectKernel.Kernel.Get<IReader<Link>>().Get();
        }
    }
}