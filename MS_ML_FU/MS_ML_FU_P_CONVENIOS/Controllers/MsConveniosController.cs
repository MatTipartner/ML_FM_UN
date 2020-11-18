using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_CONVENIOS.Services;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MS_ML_FU_P_CONVENIOS.Controllers
{
    [RoutePrefix("api/Convenios")]
    public class MsConveniosController : ApiController
    {
        private IMsConveniosServices serviceConvenios;

        [Route("getSettingData/{servicio}")]
        [HttpGet]
        public IHttpActionResult GetSettingData(ServiciosParametrica servicio)
            {

                IEnumerable<ParametricaServicioEstandar> ListaServicio = this.serviceConvenios.RespuestaGetSettingData(servicio);

                if (ListaServicio != null)
                {
                    return Ok(ListaServicio);
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }

            }


        [Route("getBaseDatosEst/{tabla}")]
        [HttpGet]
        public IHttpActionResult GetBaseDatosEst(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdEstandar> TablaDatosPoliza = serviceConvenios.GetListaTabla(tabla);

            if (TablaDatosPoliza.Count() > 0)
            {
                return Ok(TablaDatosPoliza);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getBaseDatosRef/{tabla}")]
        [HttpGet]
        public IHttpActionResult GetBaseDatosRef(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdReferencia> TablaDatosPoliza = serviceConvenios.GetListaTablaRef(tabla);

            if (TablaDatosPoliza.Count() > 0)
            {
                return Ok(TablaDatosPoliza);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getOtrosConveniosMapper/{GrupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetOtrosConveniosMapper(int GrupoFormulario)
        {
            IEnumerable<OtrosConveniosDtoMapper> OtrosConvenios = serviceConvenios.GetOtrosConveniosMapper(GrupoFormulario);

            if (OtrosConvenios.Count() > 0)
            {
                return Ok(OtrosConvenios);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }


        [Route("getOtrosConvenios/{GrupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetOtrosConvenios(int GrupoFormulario)
        {
            IEnumerable<OtrosConvenioDto> OtrosConvenios = serviceConvenios.GetOtrosConvenios(GrupoFormulario);

            if (OtrosConvenios.Count() > 0)
            {
                return Ok(OtrosConvenios);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }


        [Route("getFarmaciaMapper/{GrupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetFarmaciaMapper(int GrupoFormulario)
        {
            IEnumerable<FarmaciaDto> Faramacia = serviceConvenios.GetFarmacia(GrupoFormulario);

            if (Faramacia.Count() > 0)
            {
                return Ok(Faramacia);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getFarmacia/{GrupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetFarmacia(int GrupoFormulario)
        {
            IEnumerable<FarmaciaDto> Faramacia = serviceConvenios.GetFarmacia(GrupoFormulario);

            if (Faramacia.Count() > 0)
            {
                return Ok(Faramacia);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("setOtrosConvenios/{GrupoFormulario}")]
        [HttpPost]
        public IHttpActionResult SetOtrosConvenios(IEnumerable<OtrosConvenioDto> listaOtrosConvenios,int GrupoFormulario)
        {
            return Ok(this.serviceConvenios.SetConvenio(listaOtrosConvenios, GrupoFormulario));
        }

        [Route("setFarmacia/{GrupoFormulario}")]
        [HttpPost]
        public IHttpActionResult SetFarmaciaa(IEnumerable<FarmaciaDto> listaFarmacia, int GrupoFormulario)
        {
            return Ok(this.serviceConvenios.SetFarmacia(listaFarmacia, GrupoFormulario));
        }


        [Inject]
        public void SetIniciarServicioConvenios(IMsConveniosServices serviceConvenios)
        {
            this.serviceConvenios = serviceConvenios;
        }
    }
}
