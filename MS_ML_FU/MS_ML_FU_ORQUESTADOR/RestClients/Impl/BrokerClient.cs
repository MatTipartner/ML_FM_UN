using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Broker;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Utilidades.Serializacion;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;


namespace MS_ML_FU_ORQUESTADOR.RestClients.Impl
{
	public class BrokerClient: IBrokerClient
	{
		private readonly EnvironmentValues values = new EnvironmentValues();
        /*
        * Ver comentario en la clase JsonNetSerializer en DOMAIN
        */
        [System.Obsolete]
        public IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio, int runCorredor)
        {
            var client = new RestClient(values.BaseUrlMSFUBroker + FUControllers.CONTROLLER_MS_FU_BROKER + "/getSettingData/{servicio}/{runCorredor}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<IEnumerable<ParametricaServicioEstandar>>(new RestRequest().AddUrlSegment("servicio", servicio).AddUrlSegment("runCorredor", runCorredor));
            return response.Data;
        }

        public IEnumerable<ParametricaServicioReferencia> GetSettingServercioRef(int runCorredor)
        {
            var client = new RestClient(values.BaseUrlMSFUBroker + FUControllers.CONTROLLER_MS_FU_BROKER + "/getEjecutivos/{runCorredor}");
            var response = client.Execute<IEnumerable<ParametricaServicioReferencia>>(new RestRequest().AddUrlSegment("runCorredor", runCorredor));
            return response.Data;
        }

        public IEnumerable<ParametricasInfoFacturacion> GetInfofacturacion(int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUBroker + FUControllers.CONTROLLER_MS_FU_BROKER + "/getInfoFacturacion/{grupoFormulario}");
            var response = client.Execute<IEnumerable<ParametricasInfoFacturacion>>(new RestRequest().AddUrlSegment("grupoFormulario", grupoFormulario));
            return response.Data;
        }

        /*
        * Ver comentario en la clase JsonNetSerializer en DOMAIN
        */
        [System.Obsolete]
        public IEnumerable<BrokerCcteDtoMapper> GetFormularioCcte(int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUBroker + FUControllers.CONTROLLER_MS_FU_BROKER + "/getFormularioCcte/{grupoFormulario}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<IEnumerable<BrokerCcteDtoMapper>>(new RestRequest().AddUrlSegment("grupoFormulario", grupoFormulario));
            return response.Data;
        }

        /*
        * Ver comentario en la clase JsonNetSerializer en DOMAIN
        */
        [System.Obsolete]
        public BrokerCorradorDtoMapper GetFormularioCorredor(int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUBroker + FUControllers.CONTROLLER_MS_FU_BROKER + "/getFormularioCorredor/{grupoFormulario}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<BrokerCorradorDtoMapper>(new RestRequest().AddUrlSegment("grupoFormulario", grupoFormulario));
            return response.Data;
        }

        public Boolean SetBrokerCcte(IEnumerable<BrokerCcteDtoMapper> ccte)
        {
            var client = new RestClient(values.BaseUrlMSFUBroker + FUControllers.CONTROLLER_MS_FU_BROKER + "/setBrokerCcte");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(ccte);
            request.AddJsonBody(json);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }

        public Boolean SetBrokerCorredor(BrokerCorradorDtoMapper corredor)
        {
            var client = new RestClient(values.BaseUrlMSFUBroker + FUControllers.CONTROLLER_MS_FU_BROKER + "/setBrokerCorredor");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(corredor);
            request.AddJsonBody(json);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }
    }
}