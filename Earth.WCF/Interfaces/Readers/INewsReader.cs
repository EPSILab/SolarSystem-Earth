using System.Collections.Generic;
using System.ServiceModel;
using EPSILab.SolarSystem.Earth.Common;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    public interface INewsReader
    {
        [OperationContract]
        News GetNews(int code);

        [OperationContract]
        IEnumerable<News> GetListNews();

        [OperationContract]
        IEnumerable<News> GetListNewsLimited(int indexFirstElement, int numberOfResults);

        [OperationContract]
        int GetNewsLastInsertedId();

        [OperationContract]
        IEnumerable<News> SearchNews(string keywords);
    }
}