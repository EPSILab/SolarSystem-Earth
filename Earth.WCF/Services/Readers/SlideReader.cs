using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : ISlideReader
    {
        public Slide GetSlide(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Slide>>().Get(code);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return NinjectKernel.Kernel.Get<IReader<Slide>>().Get();
        }
    }
}