using EJEMPLO.Utilities;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace EJEMPLO.RestClients.Impl
{
    public class MsEjemploRest:IMsEjemploRest
    {
        private ValoresAmbiente vAmbiente = new ValoresAmbiente();

        public GetSettingDataRespuesta respuesta(GetSettingDataSolicitud soliRest) {          
            
            var client = new RestClient(vAmbiente.ServicioMetLife);
            client.Authenticator = new HttpBasicAuthenticator(vAmbiente.UsuarioServicioMetLife, vAmbiente.ClaveServicioMetLife);
            //client.Encoding = Encoding.;

            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            
            string json = JsonConvert.SerializeObject(soliRest);
            request.AddJsonBody(json);
            var response = client.Execute<GetSettingDataRespuesta>(request);
            return response.Data;
            
        }
    }
}