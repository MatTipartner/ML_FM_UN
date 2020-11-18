using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_ORQUESTADOR.Services;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Net;
using System.Web.Http;

namespace MS_ML_FU_ORQUESTADOR.Controllers
{
    [RoutePrefix("api/formulariounico")]
    public class FormularioUnicoController : ApiController
    {
        private IFormularioUnicoService serviceFormularioUnico;

        /*  Acceso de usuario */
        [Route("{siglaUsuario}/{nroBizFlow}/{idEstadoBizFlow}")]
        [HttpGet] 
        public IHttpActionResult GetPerfilAccesoPerfil(string siglaUsuario, int nroBizFlow, int idEstadoBizFlow)
        {
            return Ok(this.serviceFormularioUnico.GetPerfilAcceso(siglaUsuario, nroBizFlow, idEstadoBizFlow));
        }

        /*  Menu */
        [Route("{idRedireccion}/{nroBizFlow}")]
        [HttpGet]
        public IHttpActionResult GetDespliegueMenu(int idRedireccion, int nroBizFlow)
        {
            return Ok(this.serviceFormularioUnico.GetCargaInicial(idRedireccion, nroBizFlow));
        }

        [Route("guardarFormulario")]
        [HttpPost]
        public IHttpActionResult GetGuardarFormulario(object objectPestana)
        {
            Respuesta respuesta = this.serviceFormularioUnico.GuardarDatosPestana(objectPestana);
            if (respuesta.AlmacenadoCorrecto)
            {
                return Ok(respuesta.Cabecera);
            }
            else {
                return StatusCode(HttpStatusCode.NotFound);
            }
                       
        }

        [Route("buscarFormulario")]
        [HttpPost]
        public IHttpActionResult GetFormulario(CabeceraJsonDto cabecera)
        {
            object Formulario = this.serviceFormularioUnico.GetDatosFormulario(cabecera);
            if (null != Formulario)
            {
                return Ok(Formulario);
            }
            else
            {
                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
        }

        // ELIMINAR
        [Route("credenciales")]
        [HttpPost]
        public IHttpActionResult Credenciales(CabeceraJsonDto cabecera)
        {
            this.serviceFormularioUnico.ControlAcceso(cabecera);
            return Ok(cabecera);
        }

        /***********************************************************************************/
        [Inject]
        public void SetServiceFormularioUnico(IFormularioUnicoService serviceFormularioUnico)
        {
            this.serviceFormularioUnico = serviceFormularioUnico;
        }

    }
}
