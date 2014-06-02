using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Infrastructure;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : INewsManager
    {
        public News GetNews(int code)
        {
            return NinjectKernel.Kernel.Get<IReader<News>>().Get(code);
        }

        public IEnumerable<News> GetListNews()
        {
            return NinjectKernel.Kernel.Get<IReader<News>>().Get();
        }

        public IEnumerable<News> GetListNewsLimited(int indexFirstElement, int numberOfResults)
        {
            return NinjectKernel.Kernel.Get<IReaderLimit<News>>().Get(indexFirstElement, numberOfResults);
        }

        public int AddNews(News element, string username, string password)
        {
            return NinjectKernel.Kernel.Get<IManager<News>>().Add(element, username, password);
        }

        public void EditNews(News element, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<News>>().Edit(element, username, password);
        }

        public void DeleteNews(int code, string username, string password)
        {
            NinjectKernel.Kernel.Get<IManager<News>>().Delete(code, username, password);
        }
    }
}