using MS_ML_FU_ACCESO_PERFIL.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MS_ML_FU_ACCESO_PERFIL.Controllers
{
    [RoutePrefix("api/AccesoPerfil")]
    public class MsAccesoPerfilController : ApiController
    {
        private IMsAccesoPerfilServices serviceAccesoPerfil;

        [Route("redireccion/{siglaUsuario}/{nroBizFlow}/{idEstadoBizFlow}")]
        //object/{id}/grupo/{value}
        [HttpGet] 
        public IHttpActionResult GetPerfilAccesoPerfil(string siglaUsuario, int nroBizFlow, int idEstadoBizFlow)
        {
            return Ok(this.serviceAccesoPerfil.GetPerfilAccesoPerfil(siglaUsuario, nroBizFlow, idEstadoBizFlow));
        }

        [Route("redireccion/{nroBizFlow}")]
        [HttpGet] 
        public IHttpActionResult GetPerfilAccesoDireccion(int nroBizFlow)
        {
            return Ok(this.serviceAccesoPerfil.GetPerfilAccesoDireccion(nroBizFlow));
        }

        /*********************************************************************************/
        [Inject]
        public void setIniciarServicioCondicionesEsp(IMsAccesoPerfilServices serviceAccesoPerfil)
        {
            this.serviceAccesoPerfil = serviceAccesoPerfil;
        }
    }
}
