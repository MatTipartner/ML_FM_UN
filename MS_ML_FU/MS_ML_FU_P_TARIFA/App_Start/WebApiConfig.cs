using MS_ML_FU_P_TARIFA.Persistence;
using MS_ML_FU_P_TARIFA.Persistence.Impl;
using MS_ML_FU_P_TARIFA.RestClients;
using MS_ML_FU_P_TARIFA.RestClients.Impl;
using MS_ML_FU_P_TARIFA.Services;
using MS_ML_FU_P_TARIFA.Services.Impl;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace MS_ML_FU_P_TARIFA
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            config.DependencyResolver = new NinjectResolver();
            // Rutas de API web
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

            kernel.Bind<IMsTarifaClient>().To<MsTarifaClient>().InSingletonScope();
            /*
             * Services
             */
            kernel.Bind<IMsTarifaServices>().To<MsTarifaServices>().InSingletonScope();

            /*
             * Persistence
             */
            kernel.Bind<IMsTarifaPersistence>().To<MsTarifaPersistence>().InSingletonScope();
            return kernel;
        }
    }

}
