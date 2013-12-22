using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;
using SolarSystem.Earth.Common;

namespace SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface IConferenceReader
    {
        [OperationContract]
        Conference GetConference(int code);

        [OperationContract]
        IEnumerable<Conference> GetConferences();

        [OperationContract]
        IEnumerable<Conference> GetConferencesLimited(int indexFirstResult, int numberOfResults);

        [OperationContract]
        IEnumerable<Conference> GetConferencesSorted(int indexFirstResult, int numberOfResults, SortOrder order);

        [OperationContract]
        IEnumerable<Conference> GetConferencesByVille(Ville ville, int indexFirstResult, int numberOfResults, SortOrder order);

        [OperationContract]
        int GetConferenceLastInsertedId();

        [OperationContract]
        IEnumerable<Conference> SearchConferences(string keywords);
    }
}
