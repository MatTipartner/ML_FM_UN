using System.Collections.Generic;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Varios;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Wikimedia;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_DLL_DOMAIN.Tests.Dtos.GitHub;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using RestSharp;

namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public class EjemploClient : IEjemploClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();

        public List<Repository> GetGithubRepositories()
        {
            var client = new RestClient(values.BaseUrlMSFUEjemplo + FUControllers.CONTROLLER_MS_FU_EJEMPLO + "/github");
            var response = client.Execute<List<Repository>>(new RestRequest());
            return response.Data;
        }

        public List<WikimediaAvailability> GetWikimediaAvailabilities()
        {
            var client = new RestClient(values.BaseUrlMSFUEjemplo + FUControllers.CONTROLLER_MS_FU_EJEMPLO + "/wiki/{id}");
            var response = client.Execute<List<WikimediaAvailability>>(new RestRequest().AddUrlSegment("id", 1));
            return response.Data;
        }

        public void SendTestObject(TestObjectJson toj)
        {
            //
            var client = new RestClient(values.BaseUrlMSFUEjemplo + FUControllers.CONTROLLER_MS_FU_EJEMPLO + "/object/{id}");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(toj);
            var response = client.Execute(request.AddUrlSegment("id", 999));
            System.Diagnostics.Debug.WriteLine(response.StatusCode);

        }

        public List<ParametricaServicioEstandar> GetSetting(ServiciosParametrica servicio) {
            var client = new RestClient(values.BaseUrlMSFUEjemplo + FUControllers.CONTROLLER_MS_FU_EJEMPLO + "/getSettingData/{servicio}");
            var response = client.Execute<List<ParametricaServicioEstandar>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

    }
}