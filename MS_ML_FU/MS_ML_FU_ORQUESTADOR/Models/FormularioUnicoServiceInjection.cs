using MS_ML_FU_ORQUESTADOR.Services;
using Ninject;


namespace MS_ML_FU_ORQUESTADOR.Models
{
    public abstract class FormularioUnicoServiceInjection
    {
        // Services injection
        protected IBrokerService serviceBroker;
        protected ICobranzaService serviceCobranza;
        protected ICondicionesEspecialesService serviceCondiciones;
        protected IConveniosService serviceConvenios;
        protected IDatosPolizaService serviceDatosPoliza;
        protected IImedService serviceImed;
        protected IParametrosService serviceParametros;
        protected IPlanGrillaService servicePlanGrilla;
        protected IProductosService serviceProductos;
        protected IRequisitoAsegurabilidadService serviceRequisito;
        protected ITarifasService serviceTarifas;
        protected IAccesoPerfilService serviceAccesoPerfil;
        protected IMenuService serviceMenu;
        protected ICredencialesService serviceCredenciales;
        protected IMensajeService serviceMensajes;
        //
        protected IEjemploService serviceEjemplo; // Ejemplo

        [Inject]
        public void SetServiceCredenciales(IMensajeService serviceMensajes)
        {
            this.serviceMensajes = serviceMensajes;
        }

        [Inject]
        public void SetServiceCredenciales(ICredencialesService serviceCredenciales)
        {
            this.serviceCredenciales = serviceCredenciales;
        }

        [Inject]
        public void SetServiceAccesoPerfil(IMenuService serviceMenu)
        {
            this.serviceMenu = serviceMenu;
        }

        [Inject]
        public void SetServiceAccesoPerfil(IAccesoPerfilService serviceAccesoPerfil)
        {
            this.serviceAccesoPerfil = serviceAccesoPerfil;
        }

        [Inject]
        public void SetServiceBroker(IBrokerService serviceBroker)
        {
            this.serviceBroker = serviceBroker;
        }

        [Inject]
        public void SetServiceCobranza(ICobranzaService serviceCobranza)
        {
            this.serviceCobranza = serviceCobranza;
        }

        [Inject]
        public void SetServiceCondiciones(ICondicionesEspecialesService serviceCondiciones)
        {
            this.serviceCondiciones = serviceCondiciones;
        }

        [Inject]
        public void SetServiceConvenios(IConveniosService serviceConvenios)
        {
            this.serviceConvenios = serviceConvenios;
        }

        [Inject]
        public void SetServiceDatosPoliza(IDatosPolizaService serviceDatosPoliza)
        {
            this.serviceDatosPoliza = serviceDatosPoliza;
        }

        [Inject]
        public void SetServiceImed(IImedService serviceImed)
        {
            this.serviceImed = serviceImed;
        }

        [Inject]
        public void SetServiceParametros(IParametrosService serviceParametros)
        {
            this.serviceParametros = serviceParametros;
        }

        [Inject]
        public void SetServicePlanGrilla(IPlanGrillaService servicePlanGrilla)
        {
            this.servicePlanGrilla = servicePlanGrilla;
        }

        [Inject]
        public void SetServiceProductos(IProductosService serviceProductos)
        {
            this.serviceProductos = serviceProductos;
        }

        [Inject]
        public void SetServiceRequisito(IRequisitoAsegurabilidadService serviceRequisito)
        {
            this.serviceRequisito = serviceRequisito;
        }

        [Inject]
        public void SetServiceTarifas(ITarifasService serviceTarifas)
        {
            this.serviceTarifas = serviceTarifas;
        }

        // Ejemplo
        [Inject]
        public void SetServiceEjemplo(IEjemploService serviceEjemplo)
        {
            this.serviceEjemplo = serviceEjemplo;
        }

    }
}