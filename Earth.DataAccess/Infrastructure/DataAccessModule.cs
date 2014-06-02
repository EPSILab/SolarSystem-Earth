using EPSILab.SolarSystem.Earth.DataAccess.DAL;
using EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract;
using Ninject.Modules;

namespace EPSILab.SolarSystem.Earth.DataAccess.Infrastructure
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            // DAL bindings
            Kernel.Bind<ICampusDAL>().To<CampusDAL>().InSingletonScope();
            Kernel.Bind<IConferenceDAL>().To<ConferenceDAL>().InSingletonScope();
            Kernel.Bind<ILinkDAL>().To<LinkDAL>().InSingletonScope();
            Kernel.Bind<IMemberDAL>().To<MemberDAL>().InSingletonScope();
            Kernel.Bind<INewsDAL>().To<NewsDAL>().InSingletonScope();
            Kernel.Bind<IProjectDAL>().To<ProjectDAL>().InSingletonScope();
            Kernel.Bind<IPromotionDAL>().To<PromotionDAL>().InSingletonScope();
            Kernel.Bind<IShowDAL>().To<ShowDAL>().InSingletonScope();
            Kernel.Bind<ISlideDAL>().To<SlideDAL>().InSingletonScope();
        }
    }
}
