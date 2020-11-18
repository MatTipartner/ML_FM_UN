using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_MENSAJE.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace MS_ML_FU_MENSAJE.Controllers
{
    [RoutePrefix("api/Mensajes")]
    public class MsMensajeController : ApiController
    {
        private IMsMensajeServices serviceMensaje;

        [Route("getMensajeFormulario/{grupoPoliza}/{pestana}")]
        [HttpGet]
        public IHttpActionResult GetMensajeFormulario(int grupoPoliza, PestanaParametrica pestana)
        {
            ICollection<MensajeDtoMapper> ListaMensaje = this.serviceMensaje.GetMensajeFormulario(grupoPoliza, (Int32)pestana);

            if (ListaMensaje != null)
            {
                return Ok(ListaMensaje);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        /***************************************************************/
        [Inject]
        public void SetIniciarServicioDatosPoliza(IMsMensajeServices serviceMensaje)
        {
            this.serviceMensaje = serviceMensaje;
        }
    }
}
