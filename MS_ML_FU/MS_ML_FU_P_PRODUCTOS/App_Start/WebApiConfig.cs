using MS_ML_FU_P_PRODUCTOS.Persistence;
using MS_ML_FU_P_PRODUCTOS.Persistence.Impl;
using MS_ML_FU_P_PRODUCTOS.RestClients;
using MS_ML_FU_P_PRODUCTOS.RestClients.Impl;
using MS_ML_FU_P_PRODUCTOS.Services;
using MS_ML_FU_P_PRODUCTOS.Services.Impl;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace MS_ML_FU_P_PRODUCTOS
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
            kernel.Bind<IMsProductosClient>().To<MsProductosClient>().InSingletonScope();

            /*
             * Services
             */
            kernel.Bind<IMsProductosServices>().To<MsProductosServices>().InSingletonScope();

            /*
             * Persistence
             */
            kernel.Bind<IMsProductosPersistence>().To<MsProductosPersistence>().InSingletonScope();
            return kernel;
        }
    }
}
