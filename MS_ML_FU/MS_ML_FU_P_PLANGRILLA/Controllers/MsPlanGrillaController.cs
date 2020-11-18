using MS_ML_FU_P_PLANGRILLA.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MS_ML_FU_P_PLANGRILLA.Controllers
{
    [RoutePrefix("api/PlanGrilla")]
    public class MsPlanGrillaController : ApiController
    {
        private IMsPlanGrillaServices servicePlanGrilla;
        [Route("listaPlanes")]
        [HttpPost]
        public IHttpActionResult GetListaPlanes()
        {
            return Ok(this.servicePlanGrilla.getListaPlanGrilla());
        }
        [Inject]
        public void setIniciarServicioReqAseg(IMsPlanGrillaServices servicePlanGrilla)
        {
            this.servicePlanGrilla = servicePlanGrilla;
        }
    }
}
