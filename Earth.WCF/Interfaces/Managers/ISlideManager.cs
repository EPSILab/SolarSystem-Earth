using EPSILab.SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface ISlideManager
    {
        [OperationContract]
        Slide GetSlide(int code);

        [OperationContract]
        IEnumerable<Slide> GetSlides();

        [OperationContract]
        int AddSlide(Slide element, string username, string password);

        [OperationContract]
        void EditSlide(Slide element, string username, string password);

        [OperationContract]
        void DeleteSlide(int code, string username, string password);
    }
}