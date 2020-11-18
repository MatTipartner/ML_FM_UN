using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_BMI.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MS_ML_FU_P_BMI.Controllers
{

    [RoutePrefix("api/Parametros")]
    public class MsParametrosController : ApiController
    {
        private IMsParametrosServices serviceParametros;
        
        [Route("getSettingData/{servicio}")]
        [HttpGet]
        public IHttpActionResult getSettingData(ServiciosParametrica servicio)
        {
            IEnumerable<ParametricaServicioEstandar> ListaServicio = this.serviceParametros.RespuestaGetSettingData(servicio);

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
            List<ParametricasBdEstandar> TablaParametros = serviceParametros.GetListaTabla(tabla);

            if (TablaParametros.Count > 0)
            {
                return Ok(TablaParametros);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Inject]
        public void setIniciarServicioReqAseg(IMsParametrosServices serviceParametros)
        {
            this.serviceParametros = serviceParametros;
        }
    }
}
