using EPSILab.SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers
{
    [ServiceContract]
    interface IPromotionManager
    {
        [OperationContract]
        Promotion GetPromotion(int code);

        [OperationContract]
        IEnumerable<Promotion> GetPromotions();

        [OperationContract]
        IEnumerable<Promotion> GetPromotionsAvailables();

        [OperationContract]
        int AddPromotion(Promotion element, string username, string password);

        [OperationContract]
        void EditPromotion(Promotion element, string username, string password);

        [OperationContract]
        void DeletePromotion(int code, string username, string password);
    }
}