using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : IPromotionManager
    {
        public Promotion GetPromotion(int code)
        {
            IReader<Promotion> business = new PromotionBusiness();
            return business.Get(code);
        }

        public IEnumerable<Promotion> GetPromotions()
        {
            IReader<Promotion> business = new PromotionBusiness();
            return business.Get();
        }

        public IEnumerable<Promotion> GetPromotionsAvailables()
        {
            IAvailable<Promotion> business = new PromotionBusiness();
            return business.GetAvailables();
        }

        public int AddPromotion(Promotion element, string username, string password)
        {
            IManager<Promotion> business = new PromotionBusiness();
            return business.Add(element, username, password);
        }

        public void EditPromotion(Promotion element, string username, string password)
        {
            IManager<Promotion> business = new PromotionBusiness();
            business.Edit(element, username, password);
        }

        public void DeletePromotion(int code, string username, string password)
        {
            IManager<Promotion> business = new PromotionBusiness();
            business.Delete(code, username, password);
        }
    }
}