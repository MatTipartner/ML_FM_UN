using MS_ML_FU_CREDENCIALES.Models;
using MS_ML_FU_CREDENCIALES.Services;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MS_ML_FU_CREDENCIALES.Controllers
{
    [Authorize]
    [RoutePrefix("api/Credenciales")]
    public class CredencialController : ApiController
    {
        private IMsCredencialesService credencialesService;

        [HttpGet]
        
        [Route("validar")]
        public IHttpActionResult Validar()
        {
            return Ok();
        }

        [HttpPost]
        [Route("actualizar")]
        public IHttpActionResult ActualizarCredencial(CredencialDto credencial)
        {
            if(this.credencialesService.ActualizarCredencial(credencial))
            {
                return Ok(credencial);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPost]
        [Route("actualizarModoAcceso")]
        public IHttpActionResult ActualizarModoAcceso(CredencialDto credencial)
        {
            this.credencialesService.ActualizacionModoAcceso(credencial);
            return Ok(credencial);
        }

        [Inject]
        public void SetCredencialesService(IMsCredencialesService credencialesService)
        {
            this.credencialesService = credencialesService;
        }
    }

}
