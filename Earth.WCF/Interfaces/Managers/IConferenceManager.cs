using EPSILab.SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IConferenceManager
    {
        [OperationContract]
        Conference GetConference(int code);

        [OperationContract]
        IEnumerable<Conference> GetConferences(int indexFirstResult, int numberOfResults);

        [OperationContract]
        int AddConference(Conference element, string username, string password);

        [OperationContract]
        void EditConference(Conference element, string username, string password);

        [OperationContract]
        void DeleteConference(int code, string username, string password);
    }
}