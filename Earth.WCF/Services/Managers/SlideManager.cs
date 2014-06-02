using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : ISlideManager
    {
        public Slide GetSlide(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<Slide>>().Get(code);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return NinjectKernel.Kernel.Get<IReader<Slide>>().Get();
        }

        public int AddSlide(Slide element, string username, string password)
        {
            return NinjectKernel.Kernel.Get<IManager<Slide>>().Add(element, username, password);
        }

        public void EditSlide(Slide element, string username, string password)
        {
             NinjectKernel.Kernel.Get<IManager<Slide>>().Edit(element, username, password);
        }

        public void DeleteSlide(int code, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<Slide>>().Delete(code, username, password);
        }
    }
}