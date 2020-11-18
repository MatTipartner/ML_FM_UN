using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_COBRANZA.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace MS_ML_FU_P_COBRANZA.Controllers
{
    [RoutePrefix("api/Cobranza")]
    public class CobranzaController : ApiController
    {
        private IMsCobranzaServices serviceCobranza;

        [Route("getSettingData/{servicio}")]
        [HttpGet]
        public IHttpActionResult GetSettingData(ServiciosParametrica servicio)
        {
            IEnumerable<ParametricaServicioEstandar> ListaServicio = this.serviceCobranza.RespuestaGetSettingData(servicio);

            if (ListaServicio != null)
            {
                return Ok(ListaServicio);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

        }

        [Route("getBaseDatos/{tabla}")]
        [HttpGet]
        public IHttpActionResult GetBaseDatos(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdEstandar> TablaCobranza = serviceCobranza.GetListaTabla(tabla);

            if (TablaCobranza != null)
            {
                return Ok(TablaCobranza);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getCobranza/{nroFormulario}")]
        [HttpGet]
        public IHttpActionResult GetCobranza(int nroFormulario)
        {
            CobranzaDtoMapper cobranza = serviceCobranza.GetCobranza(nroFormulario);

            if (cobranza != null)
            {
                return Ok(cobranza);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
        [Route("getCobranzaGrupo/{grupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetCobranzaGrupo(int grupoFormulario)
        {
            CobranzaGrupoDtoMapper cobranzaGrupo = serviceCobranza.GetCobranzaGrupo(grupoFormulario);

            if (cobranzaGrupo != null)
            {
                return Ok(cobranzaGrupo);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("setPeriodicidad/{periodicidad}/{nroFormulario}")]
        [HttpPost]
        public IHttpActionResult SetPeriodicidad(String periodicidad, int nroFormulario)
        {
            return Ok(this.serviceCobranza.SetPeriodicidad(periodicidad, nroFormulario));
        }

        [Route("setCobranza")]
        [HttpPost]
        public IHttpActionResult SetCobranza(CobranzaDtoMapper listaCobranzaMapper)
        {
            return Ok(this.serviceCobranza.SetCobranza(listaCobranzaMapper));
        }

        [Route("setCobranzaGrupo/{GrupoFormulario}")]
        [HttpPost]
        public IHttpActionResult SetCobranzaGrupo(CobranzaGrupoDtoMapper listaCobranzaGrupoMapper, int GrupoFormulario)
        {
            return Ok(this.serviceCobranza.SetCobranzaGrupo(listaCobranzaGrupoMapper, GrupoFormulario));
        }

        [Route("setCobranzaRiesgo/{GrupoFormulario}")]
        [HttpPost]
        public IHttpActionResult SetCobranzaRiesgo(IEnumerable<CobranzaRiesgoDtoMapper> listaCobranza, int GrupoFormulario)
        {
            return Ok(this.serviceCobranza.SetCobranzaRiesgo(listaCobranza, GrupoFormulario));
        }
        /*************************************************************/
        [Inject]
        public void SetIniciarServicioCondicionesEsp(IMsCobranzaServices serviceCobranza)
        {
            this.serviceCobranza = serviceCobranza;
        }
    }
}
