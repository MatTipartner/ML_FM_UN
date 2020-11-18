using System.Configuration;

namespace MS_ML_FU_ORQUESTADOR.Models.Environment
{
    public class EnvironmentValues
    {
        public string BizflowUserGeneralKey { get; set; }
        
        public string BaseUrlMSFUEjemplo { get; set; }
        
        public string BaseUrlMSFUBroker { get; set; }
        
        public string BaseUrlMSFUCobranza { get; set; }
        
        public string BaseUrlMSFUCondiciones { get; set; }
        
        public string BaseUrlMSFUConvenios { get; set; }
        
        public string BaseUrlMSFUDatosPoliza { get; set; }
        
        public string BaseUrlMSFUImed { get; set; }
        
        public string BaseUrlMSFUParametros { get; set; }
        
        public string BaseUrlMSFUPlanGrilla { get; set; }
        
        public string BaseUrlMSFUProductos { get; set; }
        
        public string BaseUrlMSFURequerimientoAsegurado { get; set; }
        
        public string BaseUrlMSFUTarifas { get; set; }
        
        public string BaseUrlMSFUAccesoPerifl { get; set; }
        
        public string BaseUrlMSFUMenu { get; set; }
        
        public string BaseUrlMSFUCredenciales { get; set; }

        public string BaseUrlMsFUMensajes { get; set; }

        public EnvironmentValues()
        {
            var appSettings = ConfigurationManager.AppSettings;
            this.BizflowUserGeneralKey = appSettings["BIZFLOW_USER_GENERAL_KEY"];
            this.BaseUrlMSFUEjemplo = appSettings["BASE_URL_MS_FU_EJEMPLO"];
            this.BaseUrlMSFUBroker = appSettings["BASE_URL_MS_FU_BROKER"];
            this.BaseUrlMSFUCobranza = appSettings["BASE_URL_MS_FU_COBRANZA"];
            this.BaseUrlMSFUCondiciones = appSettings["BASE_URL_MS_FU_CONDICIONES"];
            this.BaseUrlMSFUConvenios = appSettings["BASE_URL_MS_FU_CONVENIOS"];
            this.BaseUrlMSFUDatosPoliza = appSettings["BASE_URL_MS_FU_DATOSPOLIZA"];
            this.BaseUrlMSFUImed = appSettings["BASE_URL_MS_FU_IMED"];
            this.BaseUrlMSFUParametros = appSettings["BASE_URL_MS_FU_PARAMETROS"];
            this.BaseUrlMSFUPlanGrilla = appSettings["BASE_URL_MS_FU_PLANGRILLA"];
            this.BaseUrlMSFUProductos = appSettings["BASE_URL_MS_FU_PRODUCTOS"];
            this.BaseUrlMSFURequerimientoAsegurado = appSettings["BASE_URL_MS_FU_REQ-ASEG"];
            this.BaseUrlMSFUTarifas = appSettings["BASE_URL_MS_FU_TARIFAS"];
            this.BaseUrlMSFUAccesoPerifl = appSettings["BASE_URL_MS_FU_ACCESOPERFIL"];
            this.BaseUrlMSFUMenu = appSettings["BASE_URL_MS_FU_MENU"];
            this.BaseUrlMSFUCredenciales = appSettings["BASE_URL_MS_FU_CREDENCIALES"];
            this.BaseUrlMsFUMensajes = appSettings["BASE_URL_MS_FU_MENSAJES"];
        }

    }
}