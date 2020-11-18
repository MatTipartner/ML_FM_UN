using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_MENU.Services;
using Ninject;
using System.Web.Http;

namespace MS_ML_FU_MENU.Controllers
{
    [RoutePrefix("api/MenuFormulario")]
    public class MsMenuController : ApiController
    {
        private IMsMenuServices serviceMenu;

        [Route("getSettingDataEstandar/{servicio}")]
        [HttpGet]
        public IHttpActionResult getSettingDataEstandar(ServiciosParametrica servicio)
        {
            return Ok(this.serviceMenu.RespuestaGetSettingData(servicio));
        } 

        [Route("getSettingDataReferencia/{servicio}/{datoEntrada}")]
        [HttpGet]
        public IHttpActionResult getSettingDataReferencia(ServiciosParametrica servicio, int datoEntrada)
        {
            return Ok(this.serviceMenu.RespuestaGetSettingDataParam(servicio, datoEntrada));
        }

        [Route("getBdEstandar/{tabla}")]
        [HttpGet]
        public IHttpActionResult getBaseDatosEstandar(BaseDatosParametrica tabla)
        {
            return Ok(this.serviceMenu.GetListaTablaEstandar(tabla));
        }


        [Route("getBdReferencia/{tabla}")]
        [HttpGet]
        public IHttpActionResult getBaseDatosReferencia(BaseDatosParametrica tabla)
        {
            return Ok(this.serviceMenu.GetListaTablaReferencia(tabla));
        }


        [Inject]
        public void setIniciarServicioDatosPoliza(IMsMenuServices serviceMenu)
        {
            this.serviceMenu = serviceMenu;
        }
    }
}