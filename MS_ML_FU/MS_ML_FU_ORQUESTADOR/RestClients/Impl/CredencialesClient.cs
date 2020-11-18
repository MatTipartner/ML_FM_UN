using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.RestClients.Impl
{
    public class CredencialesClient : ICredencialesClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();

        public OAuth2ResponseDto GetOAuth2Acceso(CredencialDto credencial)
        {
            OAuth2ResponseDto resultado = null;
            var client = new RestClient(values.BaseUrlMSFUCredenciales + "/token");
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "password", ParameterType.GetOrPost);
            request.AddParameter("username", credencial.Usuario, ParameterType.GetOrPost);
            request.AddParameter("password", values.BizflowUserGeneralKey, ParameterType.GetOrPost);
            var response = client.Execute<OAuth2ResponseDto>(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                resultado = response.Data;
            }
            return resultado;
        }

        public OAuth2ResponseDto GetOAuth2Renovacion(String refreshToken)
        {
            OAuth2ResponseDto resultado = null;
            var client = new RestClient(values.BaseUrlMSFUCredenciales + "/token");
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "refresh_token", ParameterType.GetOrPost);
            request.AddParameter("refresh_token", refreshToken, ParameterType.GetOrPost);
            var response = client.Execute<OAuth2ResponseDto>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                resultado = response.Data;
            }
            return resultado;
        }

        public Boolean EsTokenValido(CredencialDto credencial)
        {
            var client = new RestClient(values.BaseUrlMSFUCredenciales + FUControllers.CONTROLLER_MS_FU_CREDENCIALES + "/validar");
            var response = client.Execute(new RestRequest().AddHeader("Authorization", "bearer " + credencial.TokenAcceso));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public CredencialDto ActualizarCredencialUsuario(CredencialDto credencial)
        {
            var client = new RestClient(values.BaseUrlMSFUCredenciales + FUControllers.CONTROLLER_MS_FU_CREDENCIALES + "/actualizar");
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "bearer " + credencial.TokenAcceso);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(credencial);
            var response = client.Execute<CredencialDto>(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                credencial = response.Data;
            }
            return credencial;
        }

        public CredencialDto ActualizarModoAcceso(CredencialDto credencial)
        {
            CredencialDto resultado = null;
            var client = new RestClient(values.BaseUrlMSFUCredenciales + FUControllers.CONTROLLER_MS_FU_CREDENCIALES + "/actualizarModoAcceso");
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "bearer " + credencial.TokenAcceso);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(credencial);
            var response = client.Execute<CredencialDto>(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                resultado = response.Data;
            }
            return resultado;
        }

    }
}