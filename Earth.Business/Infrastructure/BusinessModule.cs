using EPSILab.SolarSystem.Earth.Common.Interfaces;
using Ninject;
using Ninject.Modules;
using CampusDTO = EPSILab.SolarSystem.Earth.Common.Campus;
using ConferenceDTO = EPSILab.SolarSystem.Earth.Common.Conference;
using LinkDTO = EPSILab.SolarSystem.Earth.Common.Link;
using MemberDTO = EPSILab.SolarSystem.Earth.Common.Member;
using LostPasswordRequestDTO = EPSILab.SolarSystem.Earth.Common.LostPasswordRequest;
using NewsDTO = EPSILab.SolarSystem.Earth.Common.News;
using ProjectDTO = EPSILab.SolarSystem.Earth.Common.Project;
using PromotionDTO = EPSILab.SolarSystem.Earth.Common.Promotion;
using ShowDTO = EPSILab.SolarSystem.Earth.Common.Show;
using SlideDTO = EPSILab.SolarSystem.Earth.Common.Slide;

namespace EPSILab.SolarSystem.Earth.Business.Infrastructure
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
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
