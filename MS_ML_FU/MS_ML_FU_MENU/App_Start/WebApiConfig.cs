﻿using MS_ML_FU_MENU.Persistence;
using MS_ML_FU_MENU.Persistence.Impl;
using MS_ML_FU_MENU.RestClients;
using MS_ML_FU_MENU.RestClients.Impl;
using MS_ML_FU_MENU.Services;
using MS_ML_FU_MENU.Services.Impl;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace MS_ML_FU_MENU
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
            kernel.Bind<IMsMenuClient>().To<MsMenuClient>().InSingletonScope();
            /*
             * Services
             */
            kernel.Bind<IMsMenuServices>().To<MsMenuServices>().InSingletonScope();

            /*
             * Persistence
             */
            kernel.Bind<IMsMenuPersistence>().To<MsMenuPersistence>().InSingletonScope();
            return kernel;
        }
    }
}
