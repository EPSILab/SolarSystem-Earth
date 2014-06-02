using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Ninject;

namespace EPSILab.SolarSystem.Earth.WCF.Infrastructure
{
    public class NinjectInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;
        private readonly IKernel _kernel;

        public NinjectInstanceProvider(IKernel kernel, Type serviceType)
        {
            _kernel = kernel;
            _serviceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return _kernel.Get(_serviceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}
