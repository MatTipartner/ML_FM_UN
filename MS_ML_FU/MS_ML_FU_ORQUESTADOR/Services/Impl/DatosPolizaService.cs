using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.RestClients;
using MS_ML_FU_ORQUESTADOR.Utilities.DatosPoliza;
using Ninject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class DatosPolizaService : IDatosPolizaService
    {
        private IDatosPolizaClient clientDatosPoliza;
        private IMensajeClient clientMensaje;

        public DatosPolizaPestanaDto GetDatosPoliza(CabeceraJsonDto cabecera)
        {
            DatosPolizaPestanaDto DatosPolizaPestana = new DatosPolizaPestanaDto();
            DatosPolizaPestana.Cabecera = cabecera;
            DatosPolizaPestana.ParameticasPoliza = this.GetParametricasPoliza();
            DatosPolizaDtoMapper polizaMapper = this.clientDatosPoliza.GetFormularioPoliza(cabecera.IdGrupoFormulario);
            if (null != polizaMapper)
            {
                DatosPolizaPestana.DatosCarga = MapperPoliza.TransformarPolizaDtoMapperEnDTO(polizaMapper, 
                                                                                             this.clientMensaje.GetBdMensaje(cabecera.IdGrupoFormulario, cabecera.IdPestana));
            }
            return DatosPolizaPestana;
        }

        public ParametricaPolizaDetalle GetParametricasPoliza()
        {
            Task<IEnumerable<ParametricaServicioEstandar>> monedaWait = Task.Run( () =>
            {
                return this.clientDatosPoliza.GetSettingServercio(ServiciosParametrica.MonedaPoliza);
            });
            Task<IEnumerable<ParametricaServicioEstandar>> sucursalWait = Task.Run(() =>
            {
                return this.clientDatosPoliza.GetSettingServercio(ServiciosParametrica.SucursalPoliza);
            });
            Task<IEnumerable<ParametricaServicioEstandar>> coberturaWait = Task.Run(() =>
            {
                return this.clientDatosPoliza.GetSettingServercio(ServiciosParametrica.EstadoCoberturaPoliza);
            });
            Task<IEnumerable<ParametricasBdEstandar>> canalVentaWait = Task.Run(() =>
            {
                return this.clientDatosPoliza.GetSettingBaseDatos(BaseDatosParametrica.CanalVenta);
            });
            Task<IEnumerable<ParametricasBdEstandar>> tipoAdittionWait = Task.Run(() =>
            {
                return this.clientDatosPoliza.GetSettingBaseDatos(BaseDatosParametrica.TipoAdittion);
            });
            Task<IEnumerable<ParametricasBdEstandar>> tipoPolizaWait = Task.Run(() =>
            {
                return this.clientDatosPoliza.GetSettingBaseDatos(BaseDatosParametrica.TipoPoliza);
            });
            Task<IEnumerable<ParametricasBdEstandar>> lineaNegocioWait = Task.Run(() =>
            {
                return this.clientDatosPoliza.GetSettingBaseDatos(BaseDatosParametrica.LineaNegocio);
            });
            Task<IEnumerable<ParametricasBdEstandar>> riesgoWait = Task.Run(() =>
            {
                return this.clientDatosPoliza.GetSettingBaseDatos(BaseDatosParametrica.Riesgo);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(monedaWait, sucursalWait, coberturaWait, canalVentaWait, tipoAdittionWait, tipoPolizaWait, lineaNegocioWait, riesgoWait);
            // Rescate de datos
            ParametricaPolizaDetalle parametrica = new ParametricaPolizaDetalle
            {
                Moneda = monedaWait.Result,
                Sucursal = sucursalWait.Result,
                EstadoCobertura = coberturaWait.Result,
                CanalVenta = canalVentaWait.Result,
                TipoAddiction = tipoAdittionWait.Result,
                TipoPoliza = tipoPolizaWait.Result,
                LineaNegocio = lineaNegocioWait.Result,
                Riesgo = riesgoWait.Result
            };
            return parametrica;
        }

        public Boolean SetGuardarPestanaPoliza(DatosPolizaPestanaDto datosPolizaPestana) {
            DatosPolizaDtoMapper datosPolizaMapper = new DatosPolizaDtoMapper();
            datosPolizaMapper = MapperPoliza.TransformarPolizaDTOEnDtoMapper(datosPolizaPestana.DatosCarga);
            return this.clientDatosPoliza.SetDatosPoliza(datosPolizaMapper);
        }

        /****************************************/

        [Inject]
        public void SetApiDatosPoliza(IDatosPolizaClient clientDatosPoliza)
        {
            this.clientDatosPoliza = clientDatosPoliza;
        }

        [Inject]
        public void SetApiMensaje(IMensajeClient clientMensaje)
        {
            this.clientMensaje = clientMensaje;
        }

    }
}