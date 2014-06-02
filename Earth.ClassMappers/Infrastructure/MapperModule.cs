using EPSILab.SolarSystem.Earth.Common.Interfaces;
using Ninject.Modules;

using CampusDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Campus;
using CampusDTO = EPSILab.SolarSystem.Earth.Common.Campus;

using ConferenceDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Conference;
using ConferenceDTO = EPSILab.SolarSystem.Earth.Common.Conference;

using LinkDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Link;
using LinkDTO = EPSILab.SolarSystem.Earth.Common.Link;

using MemberDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Member;
using MemberDTO = EPSILab.SolarSystem.Earth.Common.Member;

using LostPasswordRequestDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.LostPasswordRequest;
using LostPasswordRequestDTO = EPSILab.SolarSystem.Earth.Common.LostPasswordRequest;

using NewsDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.News;
using NewsDTO = EPSILab.SolarSystem.Earth.Common.News;

using ProjectDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Project;
using ProjectDTO = EPSILab.SolarSystem.Earth.Common.Project;

using PromotionDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Promotion;
using PromotionDTO = EPSILab.SolarSystem.Earth.Common.Promotion;

using ShowDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Show;
using ShowDTO = EPSILab.SolarSystem.Earth.Common.Show;

using SlideDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Slide;
using SlideDTO = EPSILab.SolarSystem.Earth.Common.Slide;

namespace EPSILab.SolarSystem.Earth.Mappers.Infrastructure
{
    public class MapperModule : NinjectModule
    {
        public override void Load()
        {
            // Mapper bindings
            Kernel.Bind<IMapper<CampusDAO, CampusDTO>>().To<CampusMapper>().InSingletonScope();
            Kernel.Bind<IMapper<ConferenceDAO, ConferenceDTO>>().To<ConferenceMapper>().InSingletonScope();
            Kernel.Bind<IMapper<LinkDAO, LinkDTO>>().To<LinkMapper>().InSingletonScope();
            Kernel.Bind<IMapper<MemberDAO, MemberDTO>>().To<MemberMapper>().InSingletonScope();
            Kernel.Bind<IMapper<NewsDAO, NewsDTO>>().To<NewsMapper>().InSingletonScope();
            Kernel.Bind<IMapper<ProjectDAO, ProjectDTO>>().To<ProjectMapper>().InSingletonScope();
            Kernel.Bind<IMapper<PromotionDAO, PromotionDTO>>().To<PromotionMapper>().InSingletonScope();
            Kernel.Bind<IMapper<ShowDAO, ShowDTO>>().To<ShowMapper>().InSingletonScope();
            Kernel.Bind<IMapper<SlideDAO, SlideDTO>>().To<SlideMapper>().InSingletonScope();
        }
    }
}
