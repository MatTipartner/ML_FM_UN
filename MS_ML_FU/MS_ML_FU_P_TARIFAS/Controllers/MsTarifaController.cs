using MS_ML_FU_P_TARIFAS.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MS_ML_FU_P_TARIFAS.Controllers
{
    [RoutePrefix("api/Tarifa")]
    public class MsTarifaController : ApiController
    {
        private IMsTarifaServices serviceTarifa;
        [Route("relacion")]
        [HttpPost]
        public IHttpActionResult GetGitHubRepos()
        {
            return Ok(this.serviceTarifa.getListaRelacion());
        }
        [Inject]
        public void setIniciarServicioTarifa(IMsTarifaServices serviceTarifa) {
            this.serviceTarifa = serviceTarifa;
        }
    }

}
