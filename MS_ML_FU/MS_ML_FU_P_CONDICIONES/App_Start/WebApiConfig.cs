using MS_ML_FU_P_CONDICIONES.Persistence;
using MS_ML_FU_P_CONDICIONES.Persistence.Impl;
using MS_ML_FU_P_CONDICIONES.RestClients;
using MS_ML_FU_P_CONDICIONES.RestClients.Impl;
using MS_ML_FU_P_CONDICIONES.Services;
using MS_ML_FU_P_CONDICIONES.Services.Impl;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace MS_ML_FU_P_CONDICIONES
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.DependencyResolver = new NinjectResolver();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel())
        {
        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {

        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            /*
             * API Clients
             */
            kernel.Bind<IMsCondicionesEspClient>().To<MsCondicionesEspClient>().InSingletonScope();

            /*
             * Services
             */
            kernel.Bind<IMsCondicionesEspServices>().To<MsCondicionesEspServices>().InSingletonScope();

            /*
             * Persistence
             */
            kernel.Bind<IMsCondicionesEspPersistence>().To<MsCondicionesEspPersistence>().InSingletonScope();
            return kernel;
        }
    }
}
