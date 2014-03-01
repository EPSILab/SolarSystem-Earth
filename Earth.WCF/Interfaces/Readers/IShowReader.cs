using System.Collections.Generic;
using System.ServiceModel;
using EPSILab.SolarSystem.Earth.Common;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface IShowReader
    {
        [OperationContract]
        Show GetShow(int code);

        [OperationContract]
        IEnumerable<Show> GetShows();

        [OperationContract]
        IEnumerable<Show> GetShowsLimited(int indexFirstElement, int numberOfResults);

        [OperationContract]
        int GetShowLastInsertedId();

        [OperationContract]
        IEnumerable<Show> SearchShows(string keywords);
    }
}