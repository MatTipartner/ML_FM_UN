using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_REQ_ASEG.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MS_ML_FU_P_REQ_ASEG.Controllers
{

    [RoutePrefix("api/ReqAseg")]
    public class MsReqAsegController : ApiController
    {
        private IMsReqAsegServices serviceReqAseg;

        [Route("getSettingData/{servicio}")]
        [HttpGet]
        public IHttpActionResult getSettingData(ServiciosParametrica servicio)
        {
            IEnumerable<ParametricaServicioEstandar> ListaServicio = this.serviceReqAseg.RespuestaGetSettingData(servicio);

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
            List<ParametricasBdEstandar> TablaRequisito = serviceReqAseg.GetListaTabla(tabla);

            if (TablaRequisito.Count > 0)
            {
                return Ok(TablaRequisito);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
        [Inject]
        public void setIniciarServicioReqAseg(IMsReqAsegServices serviceReqAseg)
        {
            this.serviceReqAseg = serviceReqAseg;
        }
    }
}
