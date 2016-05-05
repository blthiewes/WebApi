using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using Castle.Windsor;
using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;

namespace RestfulApi.Infrastructure
{
    public class CastleWindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public CastleWindsorDependencyResolver(IWindsorContainer container)
        {
            _container = container;
        }
        
        public IDependencyScope BeginScope()
        {
            return new CastleWindsorDependencyScope(_container);
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }
            try
            {
                return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
            }
            catch (ComponentNotFoundException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }
            try
            {
                return _container.ResolveAll(serviceType).Cast<object>();
            }
            catch (ComponentNotFoundException)
            {
                return null;
            }
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}