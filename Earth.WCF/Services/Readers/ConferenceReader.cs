using System.Collections.Generic;
using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Readers;

namespace SolarSystem.Earth.WCF
{
    public partial class ReadersService : IConferenceReader
    {
        public Conference GetConference(int code)
        {
            IReader<Conference> business = new ConferenceBusiness();
            return business.Get(code);
        }

        public IEnumerable<Conference> GetConferences()
        {
            IReader2Filters<Conference, Ville, bool?> business = new ConferenceBusiness();
            return business.Get(true);
        }

        public IEnumerable<Conference> GetConferencesLimited(int indexFirstResult, int numberOfResults)
        {
            IReader2Filters<Conference, Ville, bool?> business = new ConferenceBusiness();
            return business.Get(true, indexFirstResult, numberOfResults);
        }

        public IEnumerable<Conference> GetConferencesByVille(Ville ville)
        {
            IReader2Filters<Conference, Ville, bool?> business = new ConferenceBusiness();
            return business.Get(ville, true);
        }

        public IEnumerable<Conference> GetConferencesByVilleLimited(Ville ville, int indexFirstElement, int numberOfResults)
        {
            IReader2Filters<Conference, Ville, bool?> business = new ConferenceBusiness();
            return business.Get(ville, true, indexFirstElement, numberOfResults);
        }

        public int GetConferenceLastInsertedId()
        {
            IReaderLimit<Conference> business = new ConferenceBusiness();
            return business.GetLastInsertedId();
        }

        public IEnumerable<Conference> SearchConferences(string keywords)
        {
            ISearchable<Conference> business = new ConferenceBusiness();
            return business.Search(keywords);
        }
    }
}