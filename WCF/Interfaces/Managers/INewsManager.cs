using System.Collections.Generic;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface INewsManager
    {
        [OperationContract]
        News GetNews(int code);

        [OperationContract]
        IEnumerable<News> GetListNews();

        [OperationContract]
        IEnumerable<News> GetListNewsLimited(int indexFirstElement, int numberOfResults);

        [OperationContract]
        int AddNews(News element, string username, string password);

        [OperationContract]
        void EditNews(News element, string username, string password);

        [OperationContract]
        void DeleteNews(int code, string username, string password);
    }
}