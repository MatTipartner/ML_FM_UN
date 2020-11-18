using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_DATOSPOLIZA.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MS_ML_FU_P_DATOSPOLIZA.Controllers
{
    [RoutePrefix("api/DatosPoliza")]
    public class MsDatosPolizaController : ApiController
    {
        private IMsDatosPolizaServices serviceDatosPoliza;

        [Route("getSettingData/{servicio}")]
        [HttpGet]
        public IHttpActionResult getSettingData(ServiciosParametrica servicio)
        {
            IEnumerable<ParametricaServicioEstandar> ListaServicio = this.serviceDatosPoliza.RespuestaGetSettingData(servicio);

            if (ListaServicio != null)
            {
                return Ok(ListaServicio);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getBaseDatos/{tabla}")]
        [HttpGet]
        public IHttpActionResult getBaseDatos(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdEstandar> TablaDatosPoliza = serviceDatosPoliza.GetListaTabla(tabla);

            if (TablaDatosPoliza.Count() > 0)
            {
                return Ok(TablaDatosPoliza);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getFormularioPoliza/{nroPoliza}")]
        [HttpGet]
        public IHttpActionResult GetFormularioPoliza(int nroPoliza)
        {
            DatosPolizaDtoMapper poliza = this.serviceDatosPoliza.GetFormularioPoliza(nroPoliza);
            if(null != poliza)
            {
                return Ok(poliza);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("formulario/{NroPoliza}")]
        [HttpGet]
        public IHttpActionResult GetUbicacionesGeograficaPorPoliza(int NroPoliza)
        {
            IEnumerable<UbicacionGeograficaDtoMapper> ubicaciones = this.serviceDatosPoliza.GetUbicacionesGeograficaPorPoliza(NroPoliza);
            if (ubicaciones.Count() > 0)
            {
                return Ok(ubicaciones);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("setDatosPolizaPoliza")]
        [HttpPost]
        public IHttpActionResult SetDatosPoliza(DatosPolizaDtoMapper datosPoliza)
        {
            return Ok(this.serviceDatosPoliza.SetDatosPoliza(datosPoliza));
        }

        /***************************************************************/
        [Inject]
        public void setIniciarServicioDatosPoliza(IMsDatosPolizaServices serviceDatosPoliza)
        {
            this.serviceDatosPoliza = serviceDatosPoliza;
        }

    }

}
