using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_PRODUCTOS.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MS_ML_FU_P_PRODUCTOS.Controllers
{
    [RoutePrefix("api/Productos")]
    public class MsProductosController : ApiController
    {
        private IMsProductosServices serviceProductos;

        [Route("getSettingData/{servicio}")]
        [HttpGet]
        public IHttpActionResult GetSettingData(ServiciosParametrica servicio)
        {
            IEnumerable<ParametricaServicioEstandar> ListaServicio = this.serviceProductos.RespuestaGetSettingData(servicio);

            if (ListaServicio != null)
            {
                return Ok(ListaServicio);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getSettingDataRef/{servicio}")]
        [HttpGet]
        public IHttpActionResult GetSettingDataRef(ServiciosParametrica servicio)
        {
            IEnumerable<ParametricaServicioReferencia> ListaServicio = this.serviceProductos.RespuestaGetSettingDataRef(servicio);

            if (ListaServicio != null)
            {
                return Ok(ListaServicio);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getBaseDatosEst/{tabla}")]
        [HttpGet]
        public IHttpActionResult GetBaseDatosEst(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdEstandar> TablaProductos = serviceProductos.GetListaTablaEst(tabla);
            if (TablaProductos.Count() > 0)
            {
                return Ok(TablaProductos);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getBaseDatosEstPorGrupo/{tabla}/{grupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetBaseDatosPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario)
        {
            IEnumerable<ParametricasBdEstandar> TablaProductos = serviceProductos.GetListaTablaPorGrupo(tabla, GrupoFormulario);

            if (TablaProductos.Count() > 0)
            {
                return Ok(TablaProductos);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getBaseDatosRefPorGrupo/{tabla}/{grupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetBaseDatosReferenciaPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario)
        {
            IEnumerable<ParametricasBdReferencia> TablaProductos = serviceProductos.GetListaTablaReferenciaPorGrupo(tabla, GrupoFormulario);

            if (TablaProductos.Count() > 0)
            {
                return Ok(TablaProductos);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getBaseDatosPrestaciones/{tabla}/{GrupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetListaTablaPrestacionesPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario)
        {
            IEnumerable<ParametricasBdPrestacionParametrica> TablaProductos = serviceProductos.GetListaTablaPrestacionesPorGrupo(tabla, GrupoFormulario);

            if (TablaProductos.Count() > 0)
            {
                return Ok(TablaProductos);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getBaseDatosRef/{tabla}")]
        [HttpGet]
        public IHttpActionResult GetBaseDatosRef(BaseDatosParametrica tabla)
        {
            return Ok(this.serviceProductos.GetListaTablaRef(tabla));
        }

        [Route("getProductoListaSalud/{GrupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetProductoListaSalud(int GrupoFormulario)
        {
            IEnumerable<ProductoSaludDetalleDtoMapper> TablaProductos = serviceProductos.GetListaSalud( GrupoFormulario);

            if (TablaProductos.Count() > 0)
            {
                return Ok(TablaProductos);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getProductoListaVidaAp/{GrupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetProductoListaVidaAp( int GrupoFormulario)
        {
            IEnumerable<ProductoVidaApDetalleDtoMapper> TablaProductos = serviceProductos.GetListaVidaAp( GrupoFormulario);

            if (TablaProductos.Count() > 0)
            {
                return Ok(TablaProductos);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getProductoVidaAp/{GrupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetProductoVidaAp(int GrupoFormulario)
        {
            ProductoVidaApDtoMapper TablaProductos = serviceProductos.GetVidaAp(GrupoFormulario);

            if (TablaProductos != null)
            {
                return Ok(TablaProductos);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getCascada/{GrupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetCascada( int GrupoFormulario)
        {
            IEnumerable<CascadaDtoMapper> TablaProductos = serviceProductos.GetCascada(GrupoFormulario);

            if (TablaProductos.Count() > 0)
            {
                return Ok(TablaProductos);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("setListaVidaAp/{GrupoFormulario}")]
        [HttpPost]
        public IHttpActionResult SetListaVidaAp(IEnumerable<ProductoVidaApDetalleDtoMapper> listaVidaAp, int GrupoFormulario)
        {
            return Ok(this.serviceProductos.SetListVidaAp(listaVidaAp, GrupoFormulario));
        }

        [Route("setListaSalud/{GrupoFormulario}")]
        [HttpPost]
        public IHttpActionResult SetListaSalud(IEnumerable<ProductoSaludDetalleDtoMapper> listaSalud, int GrupoFormulario)
        {
            return Ok(this.serviceProductos.SetListaSalud(listaSalud, GrupoFormulario));
        }

        [Route("setListaCascada/{GrupoFormulario}")]
        [HttpPost]
        public IHttpActionResult SetListaCascada(IEnumerable<CascadaDtoMapper> listaCascada, int GrupoFormulario)
        {
            return Ok(this.serviceProductos.SetListaCascada(listaCascada, GrupoFormulario));
        }

        [Route("setVidaAp/{GrupoFormulario}")]
        [HttpPost]
        public IHttpActionResult SetVidaAp(ProductoVidaApDtoMapper vidaAp, int GrupoFormulario)
        {
            return Ok(this.serviceProductos.SetVidaAp(vidaAp, GrupoFormulario));
        }

        /******************************************************************************/
        [Inject]
        public void setIniciarServicioProductos(IMsProductosServices serviceProductos)
        {
            this.serviceProductos = serviceProductos;
        }
    }
}
