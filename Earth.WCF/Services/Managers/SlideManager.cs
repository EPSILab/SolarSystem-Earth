using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : ISlideManager
    {
        public Slide GetSlide(int code)
        {
            IReader<Slide> business = new SlideBusiness();
            return business.Get(code);
        }

        public IEnumerable<Slide> GetSlides()
        {
            IReader<Slide> business = new SlideBusiness();
            return business.Get();
        }

        public int AddSlide(Slide element, string username, string password)
        {
            IManager<Slide> business = new SlideBusiness();
            return business.Add(element, username, password);
        }

        public void EditSlide(Slide element, string username, string password)
        {
            IManager<Slide> business = new SlideBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteSlide(int code, string username, string password)
        {
            IManager<Slide> business = new SlideBusiness();
            business.Delete(code, username, password);
        }
    }
}