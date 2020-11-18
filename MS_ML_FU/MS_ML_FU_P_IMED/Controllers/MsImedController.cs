using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_IMED.Services;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MS_ML_FU_P_IMED.Controllers
{
    [RoutePrefix("api/Imed")]
    public class MsImedController : ApiController
    {
        private IMsImedServices serviceImed;

        [Route("getSettingData/{servicio}")]
        [HttpGet]
        public IHttpActionResult getSettingData(ServiciosParametrica servicio)
        {
            IEnumerable<ParametricaServicioEstandar> ListaServicio = this.serviceImed.RespuestaGetSettingData(servicio);

            if (ListaServicio != null)
            {
                return Ok(ListaServicio);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getBaseDatosEstandar/{tabla}")]
        [HttpGet]
        public IHttpActionResult GetBaseDatosEstardar(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdEstandar> TablaImed = serviceImed.GetListaTablaEstandar(tabla);
            if (TablaImed != null &&  TablaImed.Count() > 0)
            {
                return Ok(TablaImed);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getBaseDatosReferencia/{tabla}")]
        [HttpGet]
        public IHttpActionResult GetBaseDatosReferencia(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdReferencia> TablaImed = serviceImed.GetListaTablaReferencial(tabla);
            if (TablaImed != null && TablaImed.Count() > 0)
            {
                return Ok(TablaImed);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Inject]
        public void setIniciarServicioImed(IMsImedServices serviceImed)
        {
            this.serviceImed = serviceImed;
        }
    }
}
