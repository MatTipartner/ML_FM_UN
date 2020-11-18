using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Vista;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_TARIFA.Services;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MS_ML_FU_P_TARIFA.Controllers
{
    [RoutePrefix("api/Tarifa")]
    public class MsTarifaController : ApiController
    {

        private IMsTarifaServices serviceTarifa;

        [Route("getSettingData/{servicio}")]
        [HttpGet]
        public IHttpActionResult GetSettingData(ServiciosParametrica servicio)
        {
            IEnumerable<ParametricaServicioEstandar> ListaServicio = this.serviceTarifa.RespuestaGetSettingData(servicio);
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
            IEnumerable<ParametricasBdEstandar> TablaParametros = serviceTarifa.GetListaTabla(tabla);
            if (TablaParametros.Count() > 0 && TablaParametros != null)
            {
                return Ok(TablaParametros);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getTasaPrima/{grupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetTasaPrima(int grupoFormulario)
        {
            IEnumerable<TasaPrimaDtoMapper> TasaPrima = serviceTarifa.GetTasaPrima(grupoFormulario);
            if (TasaPrima.Count() > 0)
            {
                return Ok(TasaPrima);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("getTasaEspecial/{grupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetTasaEspecial(int grupoFormulario)
        {
            IEnumerable<TasaEspecialDtoMapper> ListaEspecial = serviceTarifa.GetListaEspecial(grupoFormulario);
            if (ListaEspecial.Count() > 0)
            {
                return Ok(ListaEspecial);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }


        [Route("tarifaPoliza/{nroFormulario}")]
        [HttpGet]
        public IHttpActionResult TarifaPoliza(int nroFormulario)
        {
            TarifaDtoMapper tarifa = serviceTarifa.GetTarifa(nroFormulario);
            if (tarifa != null)
            {
                return Ok(tarifa);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("tarifaGrupo/{grupoFormulario}")]
        [HttpGet]
        public IHttpActionResult TarifaCoberturaGrupo(int grupoFormulario)
        {
            IEnumerable< TarifaGrupoDtoMapper> tarifaGrupo = serviceTarifa.GetTarifaCoberturaGrupo(grupoFormulario);
            if (tarifaGrupo != null)
            {
                return Ok(tarifaGrupo);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("tarifaGrupoDto/{grupoFormulario}")]
        [HttpGet]
        public IHttpActionResult TarifaCoberturaGrupoDto(int grupoFormulario)
        {
            IEnumerable<TarifaGrupoDto> tarifaGrupo = serviceTarifa.GetTarifaCoberturaGrupoDto(grupoFormulario);
            if (tarifaGrupo != null)
            {
                return Ok(tarifaGrupo);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }


        [Route("setTarifa/{nroFormulario}")]
        [HttpPost]
        public IHttpActionResult SetTarifa(TarifaDtoMapper listaTarifaGrupoDto)
        {
            return Ok(this.serviceTarifa.SetTarifa(listaTarifaGrupoDto));
        }


        [Route("setListaTarifaCobertura/{grupoFormulario}")]
        [HttpPost]
        public IHttpActionResult SetListaTarifaCobertura(IEnumerable<TarifaGrupoDtoMapper> listaTarifaGrupoDto ,int grupoFormulario)
        {
            return Ok(this.serviceTarifa.SetTarifaCobertura(listaTarifaGrupoDto, grupoFormulario));
        }

        [Route("setListaTarifaCoberturaFull/{grupoFormulario}")]
        [HttpPost]
        public IHttpActionResult SetListaTarifaCoberturaFull(IEnumerable<TarifaGrupoDtoMapper> listaTarifaGrupoDto, int grupoFormulario)
        {
            return Ok(this.serviceTarifa.SetTarifaCoberturaFull(listaTarifaGrupoDto, grupoFormulario));
        }

        /*   [Route("setTarifaPrimas/{grupoFormulario}")]
           [HttpPost]
           public IHttpActionResult setTarifaPrimas(IEnumerable<TasaPrimaDto> listaTasaPrima, int grupoFormulario)
           {
               return Ok(this.serviceTarifa.SetTasaPrima(listaTasaPrima, grupoFormulario));
           }

           [Route("setTarifaEspecial/{grupoFormulario}")]
           [HttpPost]
           public IHttpActionResult setTarifaEspecial(IEnumerable<TasaEspecialDto> listaTasaEspecial, int grupoFormulario)
           {
               return Ok(this.serviceTarifa.SetTasaEspecial(listaTasaEspecial, grupoFormulario));
           }*/





        /* [Route("setListaVidaAp/{GrupoFormulario}")]
         [HttpPost]
         public IHttpActionResult SetListaVidaAp(listaVidaAp, int GrupoFormulario)
         {
             return Ok(this.serviceProductos.SetListVidaAp(listaVidaAp, GrupoFormulario));
         }*/

        /***********************************************************************/
        [Inject]
        public void setIniciarServicioConvenios(IMsTarifaServices serviceTarifa)
        {
            this.serviceTarifa = serviceTarifa;
        }

    }
}