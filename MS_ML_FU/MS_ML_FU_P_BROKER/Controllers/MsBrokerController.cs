using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Broker;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_BROKER.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace MS_ML_FU_P_BROKER.Controllers
{
    [RoutePrefix("api/Broker")]
    public class MsBrokerController : ApiController
    {
        private IMsBrokerServices serviceBroker;

        [Route("getSettingData/{servicio}/{rutCorredor}")]
        [HttpGet]
        public IHttpActionResult GetSettingData(ServiciosParametrica servicio, int rutCorredor)
        {
            IEnumerable<ParametricaServicioEstandar> ListaServicio = this.serviceBroker.RespuestaGetSettingData(servicio, rutCorredor);
            if (ListaServicio != null)
            {
                return Ok(ListaServicio);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }


        [Route("getEjecutivos/{rutCorredor}")]
        [HttpGet]
        public IHttpActionResult GetEjecutivos(int rutCorredor)
        {
            IEnumerable<ParametricaServicioReferencia> listaEjecutivos = this.serviceBroker.GetListaEjecutivosPorCorredor(rutCorredor);
            if (listaEjecutivos != null)
            {
                return Ok(listaEjecutivos);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

        }

        [Route("getInfoFacturacion/{grupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetInfoFacturacion(int grupoFormulario)
        {
            IEnumerable<ParametricasInfoFacturacion> listaEjecutivos = this.serviceBroker.GetInforFacturacion(grupoFormulario);
            if (listaEjecutivos != null)
            {
                return Ok(listaEjecutivos);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

        }

        [Route("getFormularioCcte/{grupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetFormularioCcte( int grupoFormulario)
        {
            IEnumerable<BrokerCcteDtoMapper> listaEjecutivos = this.serviceBroker.GetFormularioCcte(grupoFormulario);
            if (listaEjecutivos != null)
            {
                return Ok(listaEjecutivos);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

        }

        [Route("getFormularioCorredor/{grupoFormulario}")]
        [HttpGet]
        public IHttpActionResult GetFormularioCorredor( int grupoFormulario)
        {
            BrokerCorradorDtoMapper listaEjecutivos = this.serviceBroker.GetFormularioCorredor(grupoFormulario);
            if (listaEjecutivos != null)
            {
                return Ok(listaEjecutivos);
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("setBrokerCcte")]
        [HttpPost]
        public IHttpActionResult SetBrokerCcte(IEnumerable<BrokerCcteDtoMapper> brokerCcte)
        {
            return Ok(this.serviceBroker.SetBrokerCcte(brokerCcte));
        }

        [Route("setBrokerCorredor")]
        [HttpPost]
        public IHttpActionResult SetBrokerCorredor(BrokerCorradorDtoMapper brokerCorredor)
        {
            return Ok(this.serviceBroker.SetBrokerCorredor(brokerCorredor));
        }





        /*****************************************/
        [Inject]
        public void setIniciarServicioBroker(IMsBrokerServices serviceBroker)
        {
            this.serviceBroker = serviceBroker;
        }
    }
}
