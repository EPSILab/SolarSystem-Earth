using System.ServiceModel;
using Ninject;
using Ninject.Extensions.Wcf;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public class NinjectFileLessServiceHostFactory : NinjectServiceHostFactory
    {
        public NinjectFileLessServiceHostFactory()
        {
            var kernel = new StandardKernel();

            kernel.Bind<ServiceHost>().To<NinjectServiceHost>();

            SetKernel(kernel);
        }
    }
}
