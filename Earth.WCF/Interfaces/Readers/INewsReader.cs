using System.Collections.Generic;
using System.ServiceModel;
using SolarSystem.Earth.Common;

namespace SolarSystem.Earth.WCF.Interfaces.Readers
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