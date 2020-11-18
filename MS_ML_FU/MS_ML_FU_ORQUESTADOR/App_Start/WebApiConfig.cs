using MS_ML_FU_ORQUESTADOR.RestClients;
using MS_ML_FU_ORQUESTADOR.RestClients.Impl;
using MS_ML_FU_ORQUESTADOR.Services;
using MS_ML_FU_ORQUESTADOR.Services.Impl;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace MS_ML_FU_ORQUESTADOR
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
             * Services
             */
            // Principal
            kernel.Bind<IFormularioUnicoService>().To<FormularioUnicoService>().InSingletonScope();
            // Nodos
            kernel.Bind<IBrokerService>().To<BrokerService>().InSingletonScope();
            kernel.Bind<ICobranzaService>().To<CobranzaService>().InSingletonScope();
            kernel.Bind<ICondicionesEspecialesService>().To<CondicionesEspecialesService>().InSingletonScope();
            kernel.Bind<IConveniosService>().To<ConveniosService>().InSingletonScope();
            kernel.Bind<IDatosPolizaService>().To<DatosPolizaService>().InSingletonScope();
            kernel.Bind<IImedService>().To<ImedService>().InSingletonScope();
            kernel.Bind<IParametrosService>().To<ParametrosService>().InSingletonScope();
            kernel.Bind<IPlanGrillaService>().To<PlanGrillaService>().InSingletonScope();
            kernel.Bind<IProductosService>().To<ProductosService>().InSingletonScope();
            kernel.Bind<IRequisitoAsegurabilidadService>().To<RequisitoAsegurabilidadService>().InSingletonScope();
            kernel.Bind<ITarifasService>().To<TarifasService>().InSingletonScope();
            kernel.Bind<IAccesoPerfilService>().To<AccesoPerfilService>().InSingletonScope();
            kernel.Bind<IMenuService>().To<MenuService>().InSingletonScope();
            kernel.Bind<ICredencialesService>().To<CredencialesService>().InSingletonScope();
            kernel.Bind<IMensajeService>().To<MensajeService>().InSingletonScope();
            //
            kernel.Bind<IEjemploService>().To<EjemploService>().InSingletonScope();

            /*
             * API Clients
             */
            kernel.Bind<IBrokerClient>().To<BrokerClient>().InSingletonScope();            
            kernel.Bind<IEjemploClient>().To<EjemploClient>().InSingletonScope();
            kernel.Bind<IAccesoPerfilClient>().To<AccesoPerfilClient>().InSingletonScope();
            kernel.Bind<ICobranzaClient>().To<CobranzaClient>().InSingletonScope();
            kernel.Bind<ICondicionesEspecialesClient>().To<CondicionesEspecialesClient>().InSingletonScope();
            kernel.Bind<IConvenioClient>().To<ConvenioClient>().InSingletonScope();
            kernel.Bind<IDatosPolizaClient>().To<DatosPolizaClient> ().InSingletonScope();
            kernel.Bind<IImedClient>().To<ImedClient>().InSingletonScope();
            kernel.Bind<IParametrosClient>().To<ParametrosClient>().InSingletonScope();
            kernel.Bind<IPlanGrillaClient>().To<PlanGrillaClient>().InSingletonScope();
            kernel.Bind<IProductosClient>().To<ProductosClient>().InSingletonScope();
            kernel.Bind<IRequisitosAsegClient>().To<RequisitosAsegClient>().InSingletonScope();
            kernel.Bind<ITarifasClient>().To<TarifasClient>().InSingletonScope();
            kernel.Bind<IMenuClient>().To<MenuClient>().InSingletonScope();
            kernel.Bind<ICredencialesClient>().To<CredencialesClient>().InSingletonScope();
            kernel.Bind<IMensajeClient>().To<MensajeClient>().InSingletonScope();

            return kernel;
        }
    }

}
