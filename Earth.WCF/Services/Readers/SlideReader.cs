using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : ISlideReader
    {
        public Slide GetSlide(int code)
        {
            IReader<Slide> business = new SlideBusiness();
            return business.Get(code);
        }

        public IEnumerable<Slide> GetSlides()
        {
            IReader<Slide> business = new SlideBusiness();
            return business.Get();
        }
    }
}