using EPSILab.SolarSystem.Earth.Business.Infrastructure;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF.Infrastructure
{
    public static class NinjectKernel
    {
        public static IKernel Kernel { get; private set; }

        public static void RegisterServices()
        {
            if (Kernel == null)
                Kernel = new StandardKernel(new BusinessModule());
        }
    }
}
