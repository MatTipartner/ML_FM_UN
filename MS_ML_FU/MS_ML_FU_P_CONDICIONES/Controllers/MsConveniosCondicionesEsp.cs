using MS_ML_FU_P_CONDICIONES.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MS_ML_FU_P_CONDICIONES.Controllers
{
    public class MsConveniosCondicionesEsp : ApiController
    {
        //CondicionesEspeciales
        [RoutePrefix("api/CondicionesEspeciales")]
        public class ConveniosController : ApiController
        {
            private IMsCondicionesEspServices serviceCondicionesEsp;

            [Route("listaEjemCondicionesEsp")]
            [HttpPost]
            public IHttpActionResult GetlistaDatosPoliza()
            {
                return Ok(this.serviceCondicionesEsp.getListaEjemCondicionesEspeciales());
            }

            [Inject]
            public void setIniciarServicioCondicionesEsp(IMsCondicionesEspServices serviceCondicionesEsp)
            {
                this.serviceCondicionesEsp = serviceCondicionesEsp;
            }
        }
    }
}
