using Microsoft.Owin.Security.OAuth;
using MS_ML_FU_CREDENCIALES.Credenciales;
using MS_ML_FU_CREDENCIALES.Persistence;
using MS_ML_FU_CREDENCIALES.Persistence.Impl;
using MS_ML_FU_CREDENCIALES.RestClients;
using MS_ML_FU_CREDENCIALES.RestClients.Impl;
using MS_ML_FU_CREDENCIALES.Services;
using MS_ML_FU_CREDENCIALES.Services.Impl;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace MS_ML_FU_CREDENCIALES
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
             * Services
             */
            kernel.Bind<IMsCredencialesClient>().To<MsCredencialesClient>().InSingletonScope();

            /*
             * Services
             */
            kernel.Bind<IMsCredencialesService>().To<MsCredencialesService>().InSingletonScope();

            /*
             * Persistence
             */
            kernel.Bind<IMsCredencialesPersistence>().To<MsCredencialesPersistence>().InSingletonScope();
            return kernel;
        }
    }

}
