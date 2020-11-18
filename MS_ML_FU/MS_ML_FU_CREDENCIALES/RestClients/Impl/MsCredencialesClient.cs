using MS_ML_FU_CREDENCIALES.Models.Environment;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MS_ML_FU_CREDENCIALES.RestClients.Impl
{
    public class MsCredencialesClient : IMsCredencialesClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();

        public UsuarioDto GetUsuario(String siglaUsuario)
        {
            UsuarioDto result = null;
            var client = new RestClient(values.BaseUrlMSFUAccesoPerfil + FUControllers.CONTROLLER_MS_FU_ACCESOPERFIL_USUARIOS + "/{siglaUsuario}");
            var response = client.Execute<UsuarioDto>(new RestRequest().AddUrlSegment("siglaUsuario", siglaUsuario));
            switch(response.StatusCode) {
                case HttpStatusCode.OK:
                    result = response.Data;
                    break;
                case HttpStatusCode.NoContent:
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}