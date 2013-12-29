using SolarSystem.Earth.Common;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IConferenceManager : IConferenceReader
    {
        [OperationContract]
        int AddConference(Conference element, string username, string password);

        [OperationContract]
        void EditConference(Conference element, string username, string password);

        [OperationContract]
        void DeleteConference(int code, string username, string password);
    }
}