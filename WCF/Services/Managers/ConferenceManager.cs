using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IConferenceManager
    {
        #region IConferenceReader methods

        public Conference GetConference(int code)
        {
            IReader<Conference> business = new ConferenceBusiness();
            return business.Get(code);
        }

        public IEnumerable<Conference> GetConferences()
        {
            IReader<Conference> business = new ConferenceBusiness();
            return business.Get();
        }

        public IEnumerable<Conference> GetConferencesLimited(int indexFirstResult, int numberOfResults)
        {
            IReaderLimit<Conference> business = new ConferenceBusiness();
            return business.Get(indexFirstResult, numberOfResults);
        }

        public IEnumerable<Conference> GetConferencesSorted(int indexFirstResult, int numberOfResults, SortOrder order)
        {
            IReaderSort<Conference> business = new ConferenceBusiness();
            return business.Get(indexFirstResult, numberOfResults, order);
        }

        public IEnumerable<Conference> GetConferencesByVille(Ville ville, int indexFirstElement, int number, SortOrder order)
        {
            IReaderOneFilter<Conference, Ville> business = new ConferenceBusiness();
            return business.Get(ville, indexFirstElement, number, order);
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

        #endregion

        #region IConferenceManager methods

        public int AddConference(Conference element, string username, string password)
        {
            IManager<Conference> business = new ConferenceBusiness();
            return business.Add(element, username, password);
        }

        public void EditConference(Conference element, string username, string password)
        {
            IManager<Conference> business = new ConferenceBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteConference(int code, string username, string password)
        {
            IManager<Conference> business = new ConferenceBusiness();
            business.Delete(code, username, password);
        }

        #endregion
    }
}