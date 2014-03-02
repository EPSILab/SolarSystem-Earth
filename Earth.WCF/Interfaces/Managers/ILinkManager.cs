using EPSILab.SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface ILinkManager
    {
        [OperationContract]
        Link GetLink(int code);

        [OperationContract]
        IEnumerable<Link> GetLinks();

        [OperationContract]
        int AddLink(Link element, string username, string password);

        [OperationContract]
        void EditLink(Link element, string username, string password);

        [OperationContract]
        void DeleteLink(int code, string username, string password);
    }
}