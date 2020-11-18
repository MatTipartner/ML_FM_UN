using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.RestClients;
using MS_ML_FU_ORQUESTADOR.Utilities.Producto;
using Ninject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class ProductosService : IProductosService
    {
        private IProductosClient clientProducto;
        private IMensajeClient clientMensaje;

        public ProductoPestanaDto GetProducto(CabeceraJsonDto cabecera)
        {
            ProductoPestanaDto proPestana = new ProductoPestanaDto {
                Parametrica = this.GetParametricasProducto(),
                DatosCarga = this.GetPestanaProducto(cabecera.IdGrupoFormulario, cabecera.IdPestana),
                Cabecera = cabecera
            };
            return proPestana;
        }

        public ProductoDto GetPestanaProducto(int grupoFormulario, PestanaParametrica pestana)
        {
            Task<IEnumerable<ProductoSaludDetalleDtoMapper>> saludWait = Task.Run(() =>
            {
                return this.clientProducto.GetProductoListaSalud(grupoFormulario);
            });
            Task<IEnumerable<ProductoVidaApDetalleDtoMapper>> vidaDetalleWait = Task.Run(() =>
            {
                return this.clientProducto.GetProductoListaVidaAp(grupoFormulario);
            });
            Task<ProductoVidaApDtoMapper> vidaWait = Task.Run(() =>
            {
                return this.clientProducto.GetProductoVidaAp(grupoFormulario);
            });
            Task<IEnumerable<CascadaDtoMapper>> cascadaWait = Task.Run(() =>
            {
                return this.clientProducto.GetCascada(grupoFormulario);
            });
            Task<IEnumerable<MensajeDtoMapper>> mensajeWait = Task.Run(() =>
            {
                return this.clientMensaje.GetBdMensaje(grupoFormulario, pestana);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(saludWait, vidaDetalleWait, vidaWait, cascadaWait, mensajeWait);
            // Rescate de datos
            return MapperProducto.TransformarProductoDtoMapperEnDTO(
                saludWait.Result, vidaDetalleWait.Result, vidaWait.Result, cascadaWait.Result, mensajeWait.Result);
        }

        public ParametricaProductoDetalle GetParametricasProducto()
        {
            Task<IEnumerable<ParametricasBdEstandar>> tipoProductoWait = Task.Run(() =>
            {
                return this.clientProducto.GetSettingBaseDatosEst(BaseDatosParametrica.TipoProducto);
            });
            Task<IEnumerable<ParametricasBdReferencia>> coberturaWait = Task.Run(() =>
            {
                return this.clientProducto.GetSettingBaseDatosRef(BaseDatosParametrica.Cobertura);
            });
            Task<IEnumerable<ParametricaServicioReferencia>> polCadWait = Task.Run(() =>
            {
                return this.clientProducto.GetSettingServercioRef(ServiciosParametrica.PolCad);
            });
            Task<IEnumerable<ParametricaServicioEstandar>> relacionWait = Task.Run(() =>
            {
                return this.clientProducto.GetSettingServercioEst(ServiciosParametrica.Relacion);
            });
            Task<IEnumerable<ParametricaServicioEstandar>> sexoWait = Task.Run(() =>
            {
                return this.clientProducto.GetSettingServercioEst(ServiciosParametrica.Sexo);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(tipoProductoWait, coberturaWait, polCadWait, relacionWait, sexoWait);
            // Rescate de datos
            ParametricaProductoDetalle parametrica = new ParametricaProductoDetalle {
                TipoProducto = tipoProductoWait.Result,
                Cobertura = coberturaWait.Result,
                PolCal = polCadWait.Result,
                Relacion = relacionWait.Result,
                Sexo = sexoWait.Result
            };
            return parametrica;
        }

        public IEnumerable<ParametricasBdReferencia> listaCobertura(int grupoFormulario)
        {
            return this.clientProducto.GetCoberturaPorGrupo(BaseDatosParametrica.Cobertura, grupoFormulario);
        }

        public Boolean SetGuardarPestanaProducto(ProductoPestanaDto datosProducto)
        {
            int grupoFormulario = datosProducto.Cabecera.IdGrupoFormulario;
            Boolean guardar =false;
            Task<Boolean> guardarListaSalu = Task.Run(() =>
            {
                return this.SetGuardarListaSalud(datosProducto, grupoFormulario);
            });
            Task<Boolean> guardarListaCascada = Task.Run(() =>
            {
                return this.SetGuardarListaCascada(datosProducto, grupoFormulario);
            });
            Task<Boolean> guardaListaVidaAp = Task.Run(() =>
            {
                return this.SetGuardaListaVidaAp(datosProducto, grupoFormulario);
            });
            Task<Boolean> guardarVidaApa = Task.Run(() =>
            {
                return this.SetGuardarVidaAp(datosProducto, grupoFormulario);
            });
            // Espera por resultados, el tiempo de espera total sera solo el del proceso que tome mas tiempo
            Task.WaitAll(guardarListaSalu, guardarListaCascada, guardaListaVidaAp, guardarVidaApa);
            // Rescate de datos
            if (guardarListaSalu.Result && guardarListaCascada.Result && guardaListaVidaAp.Result && guardarVidaApa.Result)
            {
                guardar = true;
            }
            return guardar;
        }

        public Boolean SetGuardaListaVidaAp(ProductoPestanaDto datosProducto, int grupoFormulario)
        {
            return this.clientProducto.SetListaVidaAps(MapperProducto.TransformarListVidaApDTOEnDtoMapper(datosProducto.DatosCarga), grupoFormulario);
        }

        public Boolean SetGuardarListaSalud(ProductoPestanaDto datosProducto, int grupoFormulario)
        {
            return this.clientProducto.SetListaSalud(MapperProducto.TransformarListSaludDTOEnDtoMapper(datosProducto.DatosCarga), grupoFormulario);
        }

        public Boolean SetGuardarListaCascada(ProductoPestanaDto datosProducto, int grupoFormulario)
        {
            return this.clientProducto.SetListaCascada(MapperProducto.TransformarCascadaDTOEnDtoMapper(datosProducto.DatosCarga), grupoFormulario);
        }
        public Boolean SetGuardarVidaAp(ProductoPestanaDto datosProducto, int grupoFormulario)
        {
            return this.clientProducto.SetVidaAp(MapperProducto.TransformarVidaApDTOEnDtoMapper(datosProducto.DatosCarga, grupoFormulario), grupoFormulario);
        }

        [Inject]
        public void SetApiProducto(IProductosClient clientProducto)
        {
            this.clientProducto = clientProducto;
        }

        [Inject]
        public void SetApiMensaje(IMensajeClient clientMensaje)
        {
            this.clientMensaje = clientMensaje;
        }
    }
}