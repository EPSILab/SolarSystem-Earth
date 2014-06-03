using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.Infrastructure;
using EPSILab.SolarSystem.Earth.Mappers.Infrastructure;
using Ninject;
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

namespace EPSILab.SolarSystem.Earth.Business.Infrastructure
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            // Load Mappers
            Kernel.Load(new MapperModule());

            // Load DAL
            Kernel.Load(new DataAccessModule());

            // Business bindings

            // Business Singleton
            Kernel.Bind<CampusBusiness>().ToSelf().InSingletonScope();
            Kernel.Bind<ConferenceBusiness>().ToSelf().InSingletonScope();
            Kernel.Bind<LinkBusiness>().ToSelf().InSingletonScope();
            Kernel.Bind<MemberBusiness>().ToSelf().InSingletonScope();
            Kernel.Bind<NewsBusiness>().ToSelf().InSingletonScope();
            Kernel.Bind<ProjectBusiness>().ToSelf().InSingletonScope();
            Kernel.Bind<PromotionBusiness>().ToSelf().InSingletonScope();
            Kernel.Bind<ShowBusiness>().ToSelf().InSingletonScope();
            Kernel.Bind<SlideBusiness>().ToSelf().InSingletonScope();

            // Readers interfaces
            Kernel.Bind<IReader<CampusDTO>>().ToMethod(c => c.Kernel.Get<CampusBusiness>());

            Kernel.Bind<IReader<ConferenceDTO>>().ToMethod(c => c.Kernel.Get<ConferenceBusiness>());
            Kernel.Bind<IReaderLimit<ConferenceDTO>>().ToMethod(c => c.Kernel.Get<ConferenceBusiness>());
            Kernel.Bind<IReader2Filters<ConferenceDTO, CampusDTO, bool?>>().ToMethod(c => c.Kernel.Get<ConferenceBusiness>());
            Kernel.Bind<ISearchable<ConferenceDTO>>().ToMethod(c => c.Kernel.Get<ConferenceBusiness>());

            Kernel.Bind<IReader<LinkDTO>>().ToMethod(c => c.Kernel.Get<LinkBusiness>());

            Kernel.Bind<IReader<MemberDTO>>().ToMethod(c => c.Kernel.Get<MemberBusiness>());
            Kernel.Bind<IMemberReader<MemberDTO, CampusDTO>>().ToMethod(c => c.Kernel.Get<MemberBusiness>());
            Kernel.Bind<ISearchable<MemberDTO>>().ToMethod(c => c.Kernel.Get<MemberBusiness>());

            Kernel.Bind<IReader<NewsDTO>>().ToMethod(c => c.Kernel.Get<NewsBusiness>());
            Kernel.Bind<IReaderLimit<NewsDTO>>().ToMethod(c => c.Kernel.Get<NewsBusiness>());
            Kernel.Bind<IReader2Filters<NewsDTO, MemberDTO, bool?>>().ToMethod(c => c.Kernel.Get<NewsBusiness>());
            Kernel.Bind<ISearchable<NewsDTO>>().ToMethod(c => c.Kernel.Get<NewsBusiness>());

            Kernel.Bind<IReader<ProjectDTO>>().ToMethod(c => c.Kernel.Get<ProjectBusiness>());
            Kernel.Bind<IReaderLimit<ProjectDTO>>().ToMethod(c => c.Kernel.Get<ProjectBusiness>());
            Kernel.Bind<IReader1Filter<ProjectDTO, CampusDTO>>().ToMethod(c => c.Kernel.Get<ProjectBusiness>());

            Kernel.Bind<IReader<PromotionDTO>>().ToMethod(c => c.Kernel.Get<PromotionBusiness>());
            Kernel.Bind<IAvailable<PromotionDTO>>().ToMethod(c => c.Kernel.Get<PromotionBusiness>());

            Kernel.Bind<IReader<ShowDTO>>().ToMethod(c => c.Kernel.Get<ShowBusiness>());
            Kernel.Bind<IReaderLimit<ShowDTO>>().ToMethod(c => c.Kernel.Get<ShowBusiness>());
            Kernel.Bind<IReader1Filter<ShowDTO, bool?>>().ToMethod(c => c.Kernel.Get<ShowBusiness>());
            Kernel.Bind<ISearchable<ShowDTO>>().ToMethod(c => c.Kernel.Get<ShowBusiness>());

            Kernel.Bind<IReader<SlideDTO>>().ToMethod(c => c.Kernel.Get<SlideBusiness>());
            Kernel.Bind<IReader1Filter<SlideDTO, bool?>>().ToMethod(c => c.Kernel.Get<SlideBusiness>());

            // Managers interfaces
            Kernel.Bind<IManager<CampusDTO>>().ToMethod(c => c.Kernel.Get<CampusBusiness>());

            Kernel.Bind<IManager<ConferenceDTO>>().ToMethod(c => c.Kernel.Get<ConferenceBusiness>());

            Kernel.Bind<IManager<LinkDTO>>().ToMethod(c => c.Kernel.Get<LinkBusiness>());

            Kernel.Bind<IManager<MemberDTO>>().ToMethod(c => c.Kernel.Get<MemberBusiness>());
            Kernel.Bind<ILogin<MemberDTO, LostPasswordRequestDTO>>().ToMethod(c => c.Kernel.Get<MemberBusiness>());

            Kernel.Bind<IManager<NewsDTO>>().ToMethod(c => c.Kernel.Get<NewsBusiness>());

            Kernel.Bind<IManager<ProjectDTO>>().ToMethod(c => c.Kernel.Get<ProjectBusiness>());

            Kernel.Bind<IManager<PromotionDTO>>().ToMethod(c => c.Kernel.Get<PromotionBusiness>());

            Kernel.Bind<IManager<ShowDTO>>().ToMethod(c => c.Kernel.Get<ShowBusiness>());

            Kernel.Bind<IManager<SlideDTO>>().ToMethod(c => c.Kernel.Get<SlideBusiness>());
        }
    }
}
