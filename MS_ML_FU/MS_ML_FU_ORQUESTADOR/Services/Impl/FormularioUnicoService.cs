using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas;
using MS_ML_FU_ORQUESTADOR.Models;
using Newtonsoft.Json;
using System;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Broker;
using System.Threading.Tasks;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class FormularioUnicoService : FormularioUnicoServiceInjection, IFormularioUnicoService
    {
        //Llamadas reales;
        /* Metodos de Control de acceso*/
        public AccesoPerfilDto GetPerfilAcceso(string siglaUsuario, int nroBizFlow, int idEstadoBisFlow) {
            return this.serviceAccesoPerfil.GetPerfilAcceso(siglaUsuario, nroBizFlow, idEstadoBisFlow);
        }

        public object GetCargaInicial(int idRedireccion, int nroBizFlow)
        {
            switch (idRedireccion) { 
                case 1:
                   // return this.serviceDatosPoliza.GetDatosPoliza(nroBizFlow);
                case 2:
                    return this.serviceMenu.GetParametrosMenu();
                default:
                    return null;
            }
        }
        public Respuesta GuardarDatosPestana( object objectPestana)
        {
            var pestana = this.IdentificarPestana(JsonConvert.DeserializeObject<PestanaPadre>(objectPestana.ToString()));  
            Respuesta respuesta = new Respuesta();
            respuesta.Cabecera = this.IdentificarCabecera(JsonConvert.DeserializeObject<PestanaPadre>(objectPestana.ToString()));
            switch (pestana)
            {
                case PestanaParametrica.PRODUCTO:
                    ProductoPestanaDto datosProductoPestana = JsonConvert.DeserializeObject<ProductoPestanaDto>(objectPestana.ToString());
                    respuesta.AlmacenadoCorrecto = this.serviceProductos.SetGuardarPestanaProducto(datosProductoPestana);
                    if (respuesta.AlmacenadoCorrecto)
                    {
                        respuesta.AlmacenadoCorrecto = this.EliminarPestanasasociadasAProducto(datosProductoPestana); 
                       
                    }
                    break;
                case PestanaParametrica.CONVENIOS:
                    respuesta.AlmacenadoCorrecto = this.serviceConvenios.SetGuardarPestanaConvenio(JsonConvert.DeserializeObject<ConvenioPestanaDto>(objectPestana.ToString()));                                        
                    break;
                case PestanaParametrica.IMED:
                    respuesta.AlmacenadoCorrecto = true;
                    break;
                case PestanaParametrica.COBRANZA:
                    respuesta.AlmacenadoCorrecto = this.serviceCobranza.SetGuardarPestanaCobranza(JsonConvert.DeserializeObject<CobranzaPestanaDto>(objectPestana.ToString())); 
                    break;
                case PestanaParametrica.TARIFAS:
                    respuesta.AlmacenadoCorrecto = this.MultiplesTareaTarida(JsonConvert.DeserializeObject<TarifaPestanaDto>(objectPestana.ToString()));
                        //this.serviceTarifas.SetGuardarPestanaTarifa(JsonConvert.DeserializeObject<TarifaPestanaDto>(objectPestana.ToString()));
                    break;
                case PestanaParametrica.PLAN_GRILLA:
                    respuesta.AlmacenadoCorrecto = true;
                    break;
                case PestanaParametrica.CONDICIONES_ESPECIALES:
                    respuesta.AlmacenadoCorrecto = true;
                    break;
                case PestanaParametrica.REQUISITOS_ASEGURABILIDAD:
                    respuesta.AlmacenadoCorrecto = true;
                    break; ;
                case PestanaParametrica.PARAMETROS:
                    respuesta.AlmacenadoCorrecto = true;
                    break;
                case PestanaParametrica.BROKER_CCTE:
                    respuesta.AlmacenadoCorrecto = this.serviceBroker.SetGuardarPestanaCobranza(JsonConvert.DeserializeObject<BrokerPestanaDto>(objectPestana.ToString()));
                    break;
                case PestanaParametrica.POLIZA:
                    respuesta.AlmacenadoCorrecto =  this.serviceDatosPoliza.SetGuardarPestanaPoliza(JsonConvert.DeserializeObject<DatosPolizaPestanaDto>(objectPestana.ToString()));
                    break;
                default:
                    respuesta.AlmacenadoCorrecto = false;
                    break;
            }
            return respuesta;
        }

        public Boolean EliminarPestanasasociadasAProducto(ProductoPestanaDto datosProducto) {
            try {
                int grupoFormulario = datosProducto.Cabecera.IdGrupoFormulario;
                Boolean guardar = this.serviceTarifas.SetActualizarTarifaCobertura(grupoFormulario);
                return guardar;
            }
            catch (Exception) {
                return false;
            }
            
        }

        public Boolean MultiplesTareaTarida(TarifaPestanaDto tarifaPestana) {
            int nroFormulario = tarifaPestana.Cabecera.NroFormulario;
            string periodicidad = tarifaPestana.DatosCarga.CobroPrima.Valor;
            Task<Boolean> guardarTarifaWait = Task.Run(() =>
            {
                return this.serviceTarifas.SetGuardarPestanaTarifa(tarifaPestana);
            });

            Task<Boolean> actualizarCobranzaWait = Task.Run(() =>
            {
                return this.serviceCobranza.SetPeriodicidad(periodicidad, nroFormulario);
            });

            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(guardarTarifaWait, actualizarCobranzaWait);
            // Rescate de datos
            Boolean resultadoTarifa = guardarTarifaWait.Result;
            Boolean resultadoCobranza = actualizarCobranzaWait.Result;

            return resultadoTarifa;
        }
        public PestanaParametrica IdentificarPestana(PestanaPadre pestanaPadre) {
            return pestanaPadre.Cabecera.IdPestana;
        }

        public CabeceraJsonDto IdentificarCabecera(PestanaPadre pestanaPadre)
        {
            return pestanaPadre.Cabecera;
        }

        public Boolean ControlAcceso(CabeceraJsonDto cabecera)
        {
            Boolean valido = this.serviceCredenciales.ControlAcceso(cabecera.SiglaUsuario, cabecera.NroBizflow, cabecera.TokenInformacion, out CredencialDto Credencial);
            return valido;
        }
        public object GetDatosFormulario(CabeceraJsonDto cabeceraDto) {
            object objeto = null;
            switch (cabeceraDto.IdPestana)
            {
                case PestanaParametrica.PRODUCTO:
                    objeto = this.serviceProductos.GetProducto(cabeceraDto);
                    break;
                case PestanaParametrica.CONVENIOS:
                    objeto = this.serviceConvenios.GetConvenio(cabeceraDto);
                    break;
                case PestanaParametrica.IMED:
                    objeto = this.serviceImed.GetImed(cabeceraDto);
                    break;
                case PestanaParametrica.COBRANZA:
                    objeto = this.serviceCobranza.GetCobranza(cabeceraDto);
                    break;
                case PestanaParametrica.TARIFAS:
                    objeto = this.serviceTarifas.GetTarifa(cabeceraDto);
                    break;
                case PestanaParametrica.PLAN_GRILLA:
                    objeto = this.servicePlanGrilla.GetPlanGrilla(cabeceraDto);
                    break;
                case PestanaParametrica.CONDICIONES_ESPECIALES:
                    objeto = this.serviceCondiciones.GetCondicionEspecial(cabeceraDto);
                    break;
                case PestanaParametrica.REQUISITOS_ASEGURABILIDAD:
                    objeto = this.serviceRequisito.GetRequisitoAsegurabilidad(cabeceraDto);
                    break;
                case PestanaParametrica.PARAMETROS:
                    objeto = this.serviceParametros.GetParametros(cabeceraDto);
                    break;
                case PestanaParametrica.BROKER_CCTE:
                    objeto = this.serviceBroker.GetBroker(cabeceraDto);
                    break;
                case PestanaParametrica.POLIZA:
                    objeto = this.serviceDatosPoliza.GetDatosPoliza(cabeceraDto);
                    break;
                default:
                    break;
            }
            return objeto;
        }
    }
}