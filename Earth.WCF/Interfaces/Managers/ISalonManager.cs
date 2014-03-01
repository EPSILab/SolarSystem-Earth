using EPSILab.SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IShowManager
    {
        [OperationContract]
        Show GetShow(int code);

        [OperationContract]
        IEnumerable<Show> GetShows(int indexFirstElement, int numberOfResults);

        [OperationContract]
        int AddShow(Show element, string username, string password);

        [OperationContract]
        void EditShow(Show element, string username, string password);

        [OperationContract]
        void DeleteShow(int code, string username, string password);
    }
}