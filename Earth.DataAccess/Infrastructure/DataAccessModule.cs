using System.IO;
using EPSILab.SolarSystem.Earth.DataAccess.DAL;
using EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract;
using log4net;
using log4net.Config;
using Ninject.Extensions.Logging;
using Ninject.Extensions.Logging.Log4net.Infrastructure;
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

            // Logger
            Kernel.Bind<ILog>().ToMethod(c => LogManager.GetLogger(c.Request.Target.Member.DeclaringType.Name)).InSingletonScope();
            Kernel.Bind<ILogger>().To<Log4NetLogger>().InSingletonScope();

            // Get the file path of the config file
            var configFile = Directory.GetCurrentDirectory() + @"\log4net.config";

            // Load configuration defined in file log4net.config
            XmlConfigurator.Configure(new FileInfo(configFile));
        }
    }
}
