using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : IConferenceReader
    {
        public Conference GetConference(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Conference>>().Get(code);
        }

        public IEnumerable<Conference> GetConferences()
        {
            return NinjectKernel.Kernel.Get<IReader2Filters<Conference, Campus, bool?>>().Get(true);
        }

        public IEnumerable<Conference> GetConferencesLimited(int indexFirstResult, int numberOfResults)
        {
            return NinjectKernel.Kernel.Get<IReader2Filters<Conference, Campus, bool?>>().Get(true, indexFirstResult, numberOfResults);
        }

        public IEnumerable<Conference> GetConferencesByCampus(Campus campus)
        {
            return NinjectKernel.Kernel.Get<IReader2Filters<Conference, Campus, bool?>>().Get(campus, true);
        }

        public IEnumerable<Conference> GetConferencesByCampusLimited(Campus campus, int indexFirstElement, int numberOfResults)
        {
            return NinjectKernel.Kernel.Get<IReader2Filters<Conference, Campus, bool?>>().Get(campus, true, indexFirstElement, numberOfResults);
        }

        public int GetConferenceLastInsertedId()
        {
            return NinjectKernel.Kernel.Get<IReader2Filters<Conference, Campus, bool?>>().GetLastInsertedId();
        }

        public IEnumerable<Conference> SearchConferences(string keywords)
        {
            return NinjectKernel.Kernel.Get<ISearchable<Conference>>().Search(keywords);
        }
    }
}