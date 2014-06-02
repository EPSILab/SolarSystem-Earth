using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : IShowReader
    {
        public Show GetShow(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Show>>().Get(code);
        }

        public IEnumerable<Show> GetShows()
        {
            return NinjectKernel.Kernel.Get<IReader<Show>>().Get();
        }

        public IEnumerable<Show> GetShowsLimited(int indexFirstElement, int numberOfResults)
        {
            return NinjectKernel.Kernel.Get<IReaderLimit<Show>>().Get(indexFirstElement, numberOfResults);
        }

        public int GetShowLastInsertedId()
        {
            return NinjectKernel.Kernel.Get<IReader<Show>>().GetLastInsertedId();
        }

        public IEnumerable<Show> SearchShows(string keywords)
        {
            return NinjectKernel.Kernel.Get<ISearchable<Show>>().Search(keywords);
        }
    }
}