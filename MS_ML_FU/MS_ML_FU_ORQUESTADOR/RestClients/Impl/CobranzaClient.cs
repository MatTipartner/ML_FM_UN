using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza;
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
    public class CobranzaClient: ICobranzaClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();


        public IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUCobranza + FUControllers.CONTROLLER_MS_FU_COBRANZA + "/getSettingData/{servicio}");
            var response = client.Execute<IEnumerable<ParametricaServicioEstandar>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public IEnumerable<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUCobranza + FUControllers.CONTROLLER_MS_FU_COBRANZA + "/getSettingData/{servicio}");
            var response = client.Execute<IEnumerable<ParametricaServicioReferencia>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public IEnumerable<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUCobranza + FUControllers.CONTROLLER_MS_FU_COBRANZA + "/getBaseDatos/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        public IEnumerable<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUCobranza + FUControllers.CONTROLLER_MS_FU_COBRANZA + "/getBaseDatosRef/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdReferencia>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }
        /*
        * Ver comentario en la clase JsonNetSerializer en DOMAIN
        */
        [System.Obsolete]
        public CobranzaDtoMapper GetCobranza(int nroFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUCobranza + FUControllers.CONTROLLER_MS_FU_COBRANZA + "/getCobranza/{nroFormulario}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<CobranzaDtoMapper>(new RestRequest().AddUrlSegment("nroFormulario", nroFormulario));
            return response.Data;
        }
        /*
        * Ver comentario en la clase JsonNetSerializer en DOMAIN
        */
        [System.Obsolete]
        public CobranzaGrupoDtoMapper GetCobranzaGrupo(int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUCobranza + FUControllers.CONTROLLER_MS_FU_COBRANZA + "/getCobranzaGrupo/{grupoFormulario}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<CobranzaGrupoDtoMapper>(new RestRequest().AddUrlSegment("grupoFormulario", grupoFormulario));
            return response.Data;
        }

        public Boolean SetCobranza(CobranzaDtoMapper cobranza)
        {
            var client = new RestClient(values.BaseUrlMSFUCobranza + FUControllers.CONTROLLER_MS_FU_COBRANZA + "/setCobranza");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(cobranza);
            request.AddJsonBody(json);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }


        public Boolean SetCobranzaGrupo(CobranzaGrupoDtoMapper cobranzaGrupo, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUCobranza + FUControllers.CONTROLLER_MS_FU_COBRANZA + "/setCobranzaGrupo/{GrupoFormulario}");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(cobranzaGrupo);
            request.AddJsonBody(json);
            request.AddUrlSegment("GrupoFormulario", grupoFormulario);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }


        public Boolean SetListaRiesgo(IEnumerable<CobranzaRiesgoDtoMapper> cobranzaRiesgo, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUCobranza + FUControllers.CONTROLLER_MS_FU_COBRANZA + "/setCobranzaRiesgo/{GrupoFormulario}");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(cobranzaRiesgo);
            request.AddJsonBody(json);
            request.AddUrlSegment("GrupoFormulario", grupoFormulario);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }


        public Boolean SetPeriodicidad(string periodicidad, int nroFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUCobranza + FUControllers.CONTROLLER_MS_FU_COBRANZA + "/setPeriodicidad/{periodicidad}/{nroFormulario}");
            var request = new RestRequest(Method.POST);
            request.AddUrlSegment("periodicidad", periodicidad);
            request.AddUrlSegment("nroFormulario", nroFormulario);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }
    }
}