using System.Collections.Generic;
using System.ServiceModel;
using EPSILab.SolarSystem.Earth.Common;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface ISlideReader
    {
        [OperationContract]
        Slide GetSlide(int code);

        [OperationContract]
        IEnumerable<Slide> GetSlides();
    }
}