using MS_ML_FU_ACCESO_PERFIL.Services;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace MS_ML_FU_ACCESO_PERFIL.Controllers
{
    [RoutePrefix("api/Usuarios")]
    public class MsAccesoPerfilUsuarioController : ApiController
    {
        private IMsAccesoPerfilServices serviceAccesoPerfil;

        [Route("{siglaUsuario}")]
        [HttpGet]
        public IHttpActionResult GetUsuario(String siglaUsuario)
        {
            UsuarioDto usuario = this.serviceAccesoPerfil.GetUsuario(siglaUsuario);
            if (null != usuario)
            {
                return Ok(usuario);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        /*********************************************************************************/
        [Inject]
        public void setIniciarServicioCondicionesEsp(IMsAccesoPerfilServices serviceAccesoPerfil)
        {
            this.serviceAccesoPerfil = serviceAccesoPerfil;
        }
    }
}