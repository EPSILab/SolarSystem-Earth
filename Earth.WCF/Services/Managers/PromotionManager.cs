using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : IPromotionManager
    {
        public Promotion GetPromotion(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Promotion>>().Get(code);
        }

        public IEnumerable<Promotion> GetPromotions()
        {
            return NinjectKernel.Kernel.Get<IReader<Promotion>>().Get();
        }

        public IEnumerable<Promotion> GetPromotionsAvailables()
        {
            return NinjectKernel.Kernel.Get<IAvailable<Promotion>>().GetAvailables();
        }

        public int AddPromotion(Promotion element, string username, string password)
        {
            return NinjectKernel.Kernel.Get<IManager<Promotion>>().Add(element, username, password);
        }

        public void EditPromotion(Promotion element, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Promotion>>().Edit(element, username, password);
        }

        public void DeletePromotion(int code, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Promotion>>().Delete(code, username, password);
        }
    }
}