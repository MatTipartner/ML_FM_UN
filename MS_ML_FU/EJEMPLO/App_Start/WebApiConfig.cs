using EJEMPLO.Persistence;
using EJEMPLO.Persistence.Impl;
using EJEMPLO.RestClients;
using EJEMPLO.RestClients.Impl;
using EJEMPLO.Services;
using EJEMPLO.Services.Impl;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace EJEMPLO
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
            kernel.Bind<IGitHubClient>().To<GitHubClient>().InSingletonScope();
            kernel.Bind<IWikimediaClient>().To<WikimediaClient>().InSingletonScope();
            kernel.Bind<IMsEjemploRest>().To<MsEjemploRest>().InSingletonScope();

            /*
             * Services
             */
            kernel.Bind<IGitHubService>().To<GitHubService>().InSingletonScope();
            kernel.Bind<IWikimediaService>().To<WikimediaService>().InSingletonScope();
            kernel.Bind<IMsEjemplo>().To<MsEjemplo>().InSingletonScope();


            /*
            * Persistence
            */
            kernel.Bind<IMsEjemploPersistence>().To<MsEjemploPersistence>().InSingletonScope();
            return kernel;
        }
    }
}
