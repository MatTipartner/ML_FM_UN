using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.RestClients;
using MS_ML_FU_ORQUESTADOR.Utilities.Tarifa;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class TarifasService : ITarifasService
    {
        private ITarifasClient clientTarifa;
        private IMensajeClient clientMensaje;
        private IProductosClient clientProducto;

        public TarifaPestanaDto GetTarifa(CabeceraJsonDto cabeceraDto)
        {
            TarifaPestanaDto tarifaPestana = new TarifaPestanaDto {
                Cabecera = cabeceraDto,
                Parametrica = this.GetParametricasTarifa(cabeceraDto.IdGrupoFormulario)
            };
            tarifaPestana.DatosCarga = this.GetPestanaTarifa(cabeceraDto.IdGrupoFormulario, cabeceraDto.NroFormulario, cabeceraDto.IdPestana, tarifaPestana.Parametrica.Cobertura);
            return tarifaPestana;
        }
        
        public TarifaDto GetPestanaTarifa(int GrupoFormulario, int nroFormulario, PestanaParametrica pestana, IEnumerable<ParametricasBdReferencia>  coberturaFiltrada)
        {
            Task<TarifaDtoMapper> tarifaWait = Task.Run(() =>
            {
                return this.clientTarifa.GetTarifaPoliza(nroFormulario);
            });
            Task<IEnumerable<TarifaGrupoDto>> tarifaGrupoWait = Task.Run(() =>
            {
                return GetTarifaCoberturaActual(GrupoFormulario);
            });
            Task<IEnumerable<MensajeDtoMapper>> mensajeWait = Task.Run(() =>
            {
                return this.clientMensaje.GetBdMensaje(GrupoFormulario, pestana);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(tarifaWait, tarifaGrupoWait, mensajeWait);
            // Rescate de datos
            TarifaDtoMapper tarifa = tarifaWait.Result;
            IEnumerable<TarifaGrupoDto> tarifaGrupoSalud = null;
            IEnumerable<TarifaGrupoDto> tarifaGrupoVidaAp = null;
            IEnumerable<TarifaGrupoDto> listaTarifaCobertura =  tarifaGrupoWait.Result;
            if (listaTarifaCobertura != null && listaTarifaCobertura.Count() > 0)
            {
                tarifaGrupoSalud = listaTarifaCobertura.Where(x => x.ID_TIPOPRODUCTO == (int)TipoProducto.SALUD).ToList();
                tarifaGrupoVidaAp = listaTarifaCobertura.Where(x => x.ID_TIPOPRODUCTO == (int)TipoProducto.VIDA || x.ID_TIPOPRODUCTO == (int)TipoProducto.AP).ToList();
            }
            else
            {
                tarifaGrupoSalud = new List<TarifaGrupoDto>();
                tarifaGrupoVidaAp = new List<TarifaGrupoDto>();
            }
            return MapperTarifa.TransformarTarifaDtoMapperEnDTO(tarifa, tarifaGrupoSalud, tarifaGrupoVidaAp, mensajeWait.Result);
        }

        public ParametricaTarifasDetalle GetParametricasTarifa(int grupoFormulario)
        {
            Task<IEnumerable<ParametricasBdEstandar>> tipoProductoWait = Task.Run(() =>
            {
                return this.clientProducto.GetTipoProductoPorGrupo(BaseDatosParametrica.TipoProducto, grupoFormulario);
            });
            Task<IEnumerable<ParametricasBdReferencia>> coberturaWait = Task.Run(() =>
            {
                return GetCoberturaActualizada (grupoFormulario);
            });
            Task<IEnumerable<ParametricasBdEstandar>> defTributariaWait = Task.Run(() =>
            {
                return this.clientTarifa.GetSettingBaseDatosEst(BaseDatosParametrica.DefinicionTributaria);
            });
            Task<IEnumerable<ParametricaServicioEstandar>> cobroPrimaWait = Task.Run(() =>
            {
                return this.clientTarifa.GetSettingServercioEst(ServiciosParametrica.CobroPrima);
            });
            Task<IEnumerable<ParametricaServicioEstandar>> relacionWait = Task.Run(() =>
            {
                return this.clientTarifa.GetSettingServercioEst(ServiciosParametrica.Relacion);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(tipoProductoWait, coberturaWait, defTributariaWait, cobroPrimaWait, relacionWait);
            // Rescate de datos
            ParametricaTarifasDetalle parametrica = new ParametricaTarifasDetalle {
                TipoProducto = tipoProductoWait.Result,
                Cobertura = coberturaWait.Result,
                DefinicionTributaria = defTributariaWait.Result,
                CobroPrima = cobroPrimaWait.Result,
                Relacion = relacionWait.Result
            };
            return parametrica;
        }

        public IEnumerable<ParametricasBdReferencia> GetCoberturaActualizada(int grupoFormulario) { 
            return this.clientProducto.GetCoberturaPorGrupo(BaseDatosParametrica.Cobertura, grupoFormulario);
        }

        public IEnumerable<TarifaGrupoDto> GetTarifaCoberturaActual(int grupoFormulario)
        {
            return this.clientTarifa.GetTarifaCoberturaGrupo(grupoFormulario);

        }
        public Boolean SetGuardarPestanaTarifa(TarifaPestanaDto datosTarifa)
        {
            int grupoFormulario = datosTarifa.Cabecera.IdGrupoFormulario;
            int nroFormulario = datosTarifa.Cabecera.NroFormulario;
            Boolean guardar = false;
            Task<Boolean> guardarTarifa = Task.Run(() =>
            {
                return this.SetTarifa(datosTarifa, nroFormulario);
            });
            Task<Boolean> guardarTarifaCobertura = Task.Run(() =>
            {
                return this.SetTarifaCobertura(datosTarifa, grupoFormulario);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(guardarTarifa, guardarTarifaCobertura);
            // Rescate de datos           
            if (guardarTarifa.Result && guardarTarifaCobertura.Result)
            {
                guardar = true;
            }
            return guardar;
        }

        public Boolean SetActualizarTarifaCobertura(int grupoFormulario) {
            try {
                IEnumerable<TarifaGrupoDto> listaTarifaCobertura = FiltrarTarifa.FiltrarTarifaCobertura(GetCoberturaActualizada(grupoFormulario),
                                                                                                        GetTarifaCoberturaActual(grupoFormulario),
                                                                                                        grupoFormulario);
                Boolean guardar = this.clientTarifa.SetListaTariafaCoberturaFull(MapperTarifa.TransformarListaTarifaDTOEnDtoMapper(listaTarifaCobertura), 
                                                                                 grupoFormulario);

                return guardar;
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Boolean SetTarifa(TarifaPestanaDto datosTarifa, int nroFormulario)
        {
            return this.clientTarifa.SetTarifa(MapperTarifa.TransformarTarifaDTOEnDtoMapper(datosTarifa.DatosCarga, nroFormulario));
        }

        public Boolean SetTarifaCobertura(TarifaPestanaDto datosTarifaCobertura, int grupoFormualario)
        {
            return this.clientTarifa.SetListaTariafaCobertura(MapperTarifa.TransformarTarifaCoberturaDTOEnDtoMapper(datosTarifaCobertura), grupoFormualario);
        }

        /****************************************************/

        [Inject]
        public void SetApiTarifa(ITarifasClient clientTarifa)
        {
            this.clientTarifa = clientTarifa;
        }

        [Inject]
        public void SetApiMensaje(IMensajeClient clientMensaje)
        {
            this.clientMensaje = clientMensaje;
        }
        [Inject]
        public void SetApiProducto(IProductosClient clientProducto)
        {
            this.clientProducto = clientProducto;
        }
    }
}