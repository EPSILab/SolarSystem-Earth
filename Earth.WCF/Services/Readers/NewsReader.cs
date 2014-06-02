using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : INewsReader
    {
        public News GetNews(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<News>>().Get(code);
        }

        public IEnumerable<News> GetListNews()
        {
            return NinjectKernel.Kernel.Get<IReader2Filters<News, Member, bool?>>().Get(true);
        }

        public IEnumerable<News> GetListNewsLimited(int indexFirstElement, int numberOfResults)
        {
            return NinjectKernel.Kernel.Get<IReader2Filters<News, Member, bool?>>().Get(true, indexFirstElement, numberOfResults);
        }

        public int GetNewsLastInsertedId()
        {
            return NinjectKernel.Kernel.Get<IReader2Filters<News, Member, bool?>>().GetLastInsertedId();
        }

        public IEnumerable<News> SearchNews(string keywords)
        {
            return NinjectKernel.Kernel.Get<ISearchable<News>>().Search(keywords);
        }
    }
}