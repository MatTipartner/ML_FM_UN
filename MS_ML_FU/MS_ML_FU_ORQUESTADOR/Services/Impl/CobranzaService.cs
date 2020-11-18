using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Cobranza.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.RestClients;
using MS_ML_FU_ORQUESTADOR.Utilities.Cobranza;
using Ninject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class CobranzaService : ICobranzaService
    {
        private ICobranzaClient clientCobranza;
        private IBrokerClient clientBroker;
        private IMensajeClient clientMensaje;

        public CobranzaPestanaDto GetCobranza(CabeceraJsonDto cabeceraDto)
        {
            CobranzaPestanaDto cobranzaPestana = new CobranzaPestanaDto {
                Cabecera = cabeceraDto,
                Parametrica = this.GetParametricasCobranza(cabeceraDto.IdGrupoFormulario),
                DatosCarga = this.GetPestanaCobranza(cabeceraDto),
            };
            return cobranzaPestana;
        }

        public CobranzaDto GetPestanaCobranza(CabeceraJsonDto cabecera)
        {
            Task<CobranzaDtoMapper> nroFormularioWait = Task.Run(() =>
            {
                return this.clientCobranza.GetCobranza(cabecera.NroFormulario);
            });
            Task<CobranzaGrupoDtoMapper> idGrupoWait = Task.Run(() =>
            {
                return this.clientCobranza.GetCobranzaGrupo(cabecera.IdGrupoFormulario);
            });
            Task<IEnumerable<MensajeDtoMapper>> mensajeWait = Task.Run(() =>
            {
                return this.clientMensaje.GetBdMensaje(cabecera.IdGrupoFormulario, cabecera.IdPestana);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(nroFormularioWait, idGrupoWait, mensajeWait);
            // Rescate de datos
            return MapperCobranza.TransformarCobranzaDtoMapperEnDTO(
                nroFormularioWait.Result, idGrupoWait.Result, mensajeWait.Result);
        }

        public ParametricasCobranzaDetalle GetParametricasCobranza(int grupoFormulario)
        {
            Task<IEnumerable<ParametricasBdEstandar>> tipoCobroWait = Task.Run(() =>
            {
                return this.clientCobranza.GetSettingBaseDatosEst(BaseDatosParametrica.TipoCobro);
            });
            Task<IEnumerable<ParametricasBdEstandar>> primaWait = Task.Run(() =>
            {
                return this.clientCobranza.GetSettingBaseDatosEst(BaseDatosParametrica.CalculoPrima);
            });
            Task<IEnumerable<ParametricasBdEstandar>> destinatarioWait = Task.Run(() =>
            {
                return this.clientCobranza.GetSettingBaseDatosEst(BaseDatosParametrica.DestinatarioCobranza);
            });
            Task<IEnumerable<ParametricasBdEstandar>> aquienWait = Task.Run(() =>
            {
                return this.clientCobranza.GetSettingBaseDatosEst(BaseDatosParametrica.AQuienCobranza);
            });
            Task<IEnumerable<ParametricasBdEstandar>> tipoFacturacionWait = Task.Run(() =>
            {
                return this.clientCobranza.GetSettingBaseDatosEst(BaseDatosParametrica.TipoFacturacionCobranza);
            });
            Task<IEnumerable<ParametricasBdEstandar>> riesgoFacturacionWait = Task.Run(() =>
            {
                return this.clientCobranza.GetSettingBaseDatosEst(BaseDatosParametrica.RiesgoFacturacion);
            });
            Task<IEnumerable<ParametricasBdEstandar>> tipoContrWait = Task.Run(() =>
            {
                return this.clientCobranza.GetSettingBaseDatosEst(BaseDatosParametrica.TipoContrubutoriedad);
            });
            Task<IEnumerable<ParametricaServicioEstandar>> cobroPrimaWait = Task.Run(() =>
            {
                return this.clientCobranza.GetSettingServercioEst(ServiciosParametrica.CobroPrima);
            });
            Task<IEnumerable<ParametricaServicioEstandar>> reporteWait = Task.Run(() =>
            {
                return this.clientCobranza.GetSettingServercioEst(ServiciosParametrica.ReporteFacturacion);
            });
            Task<IEnumerable<ParametricaServicioEstandar>> contabilizacionWait = Task.Run(() =>
            {
                return this.clientCobranza.GetSettingServercioEst(ServiciosParametrica.Contabilizacion);
            });
            Task<IEnumerable<ParametricaServicioEstandar>> tipoProcesoWait = Task.Run(() =>
            {
                return this.clientCobranza.GetSettingServercioEst(ServiciosParametrica.TipoProcesoCobranza);
            });
            Task<IEnumerable<ParametricaServicioEstandar>> tipoFacturaWait = Task.Run(() =>
            {
                return this.clientCobranza.GetSettingServercioEst(ServiciosParametrica.TipoFactura);
            });
            Task<IEnumerable<ParametricasInfoFacturacion>> infoFacturacionWait = Task.Run(() =>
            {
                return this.clientBroker.GetInfofacturacion(grupoFormulario);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(tipoCobroWait, primaWait, destinatarioWait, aquienWait, tipoFacturacionWait, riesgoFacturacionWait, tipoContrWait,
                cobroPrimaWait, reporteWait, contabilizacionWait, tipoProcesoWait, tipoFacturaWait, infoFacturacionWait);
            // Rescate de datos
            ParametricasCobranzaDetalle cobranzaParam = new ParametricasCobranzaDetalle {
                TipoCobro = tipoCobroWait.Result,
                CalculoPrima = primaWait.Result,
                DestinatrioCobranza = destinatarioWait.Result,
                Aquien = aquienWait.Result,
                TipoFacturacion = tipoFacturacionWait.Result,
                RiesgoFacturacion = riesgoFacturacionWait.Result,
                TipoContributoriedad = tipoContrWait.Result,
                Periodicidad = cobroPrimaWait.Result,
                ReporteFacturacion = reporteWait.Result,
                Contabilizacion = contabilizacionWait.Result,
                ProcesoCobranza = tipoProcesoWait.Result,
                TipoFactura = tipoFacturaWait.Result,
                InfoFacturacion = infoFacturacionWait.Result
            };
            return cobranzaParam;
        }

        public Boolean SetGuardarPestanaCobranza(CobranzaPestanaDto datosCobranza)
        {
            int grupoFormulario = datosCobranza.Cabecera.IdGrupoFormulario;
            Task<Boolean> guardarConranza = Task.Run(() =>
            {
                return this.SetGuardarCobranza(datosCobranza);
            });
            Task<Boolean> guardarConranzaGrupo = Task.Run(() =>
            {
                return this.SetGuardarCobranzaGrupo(datosCobranza, grupoFormulario);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(guardarConranza, guardarConranzaGrupo);
            // Rescate de datos
            Boolean guardar = false;
            if (guardarConranza.Result && guardarConranzaGrupo.Result)
            {
                guardar=  true;
            }            
            return guardar;    
        }

        public Boolean SetGuardarCobranza(CobranzaPestanaDto cobranza) 
        {            
            return this.clientCobranza.SetCobranza(MapperCobranza.TransformarCobranzaDTOEnDtoMapper(cobranza.DatosCarga, cobranza.Cabecera.NroFormulario));
        }

        public Boolean SetGuardarCobranzaGrupo(CobranzaPestanaDto cobranza, int grupoFormulario)
        {
            return this.clientCobranza.SetCobranzaGrupo(MapperCobranza.TransformarCobranzGaDTOEnDtoMapper(cobranza.DatosCarga, grupoFormulario), grupoFormulario);
        }


        public Boolean SetPeriodicidad(string periodicidad, int nroFormulario)
        {
            return this.clientCobranza.SetPeriodicidad(periodicidad, nroFormulario);
        }

        /***************************************************************/
        [Inject]
        public void SetApiCobranza(ICobranzaClient clientCobranza)
        {
            this.clientCobranza = clientCobranza;
        }
        [Inject]
        public void SetApiBroker(IBrokerClient clientBroker)
        {
            this.clientBroker = clientBroker;
        }

        [Inject]
        public void SetApiMensaje(IMensajeClient clientMensaje)
        {
            this.clientMensaje = clientMensaje;
        }
    }
}