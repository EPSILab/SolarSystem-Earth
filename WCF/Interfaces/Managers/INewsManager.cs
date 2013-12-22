using SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface INewsManager
    {
        [OperationContract]
        IEnumerable<News> GetNewsList(int indexFirstResult, int numberOfResults, string username, string password);

        [OperationContract]
        News GetNews(int code, string username, string password);

        [OperationContract]
        int AddNews(News element, string username, string password);

        [OperationContract]
        void EditNews(News element, string username, string password);

        [OperationContract]
        void DeleteNews(int code, string username, string password);
    }
}