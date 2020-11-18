using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Domain.Utilidades.Serializacion;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace MS_ML_FU_ORQUESTADOR.RestClients.Impl
{
    public class DatosPolizaClient: IDatosPolizaClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();

        /*
         * Ver comentario en la clase JsonNetSerializer en DOMAIN
         */
        [System.Obsolete]
        public DatosPolizaDtoMapper GetFormularioPoliza(int nroFormulario)
        {
            DatosPolizaDtoMapper poliza = null;
            var client = new RestClient(values.BaseUrlMSFUDatosPoliza + FUControllers.CONTROLLER_MS_FU_DATOSPOLIZA + "/getFormularioPoliza/{nroPoliza}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<DatosPolizaDtoMapper>(new RestRequest(Method.GET).AddUrlSegment("nroPoliza", nroFormulario));
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                poliza = response.Data;
            }
            return poliza;
        }

        public IEnumerable<ParametricaServicioEstandar> GetSettingServercio(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUDatosPoliza + FUControllers.CONTROLLER_MS_FU_DATOSPOLIZA + "/getSettingData/{servicio}");
            var response = client.Execute<IEnumerable<ParametricaServicioEstandar>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public IEnumerable<ParametricasBdEstandar> GetSettingBaseDatos(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUDatosPoliza + FUControllers.CONTROLLER_MS_FU_DATOSPOLIZA + "/getBaseDatos/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        public Boolean SetDatosPoliza(DatosPolizaDtoMapper datosPoliza)
        {           
            var client = new RestClient(values.BaseUrlMSFUDatosPoliza + FUControllers.CONTROLLER_MS_FU_DATOSPOLIZA + "/setDatosPolizaPoliza");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(datosPoliza);
            request.AddJsonBody(json);
            var response = client.Execute<Boolean>(request);
            return response.Data;            
        }
    }
}