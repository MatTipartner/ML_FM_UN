using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_ORQUESTADOR.RestClients;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class CredencialesService : ICredencialesService
    {
        private ICredencialesClient credencialesClient;

        public Boolean ControlAcceso(String SiglaUsuario, int NroBizflow, TokenInformacion TokenInformacion, out CredencialDto Credencial)
        {
            Boolean Resultado = false;
            Credencial = new CredencialDto()
            {
                Usuario = SiglaUsuario,
                NroBizflow = NroBizflow,
                TokenAcceso = TokenInformacion.TokenAcceso,
                TokenRefresco = TokenInformacion.TokenRefresco
            };
            // Primero validar el Token
            if (!this.credencialesClient.EsTokenValido(Credencial))
            {
                OAuth2ResponseDto Response = null;
                if (TokenInformacion.EsRenovacion)
                {
                    // Si renovacion, se utiliza refresh_token
                    Response = this.credencialesClient.GetOAuth2Renovacion(Credencial.TokenRefresco);
                }
                else
                {
                    // Si es primer acceso, se solicita access_token
                    Response = this.credencialesClient.GetOAuth2Acceso(Credencial);
                    TokenInformacion.EsRenovacion = true;
                }
                // Validacion respuesta
                if (null != Response && null == Response.Error)
                {
                    Resultado = true;
                    TokenInformacion.TokenAcceso = Response.AccessToken;
                    TokenInformacion.TokenRefresco = Response.RefreshToken;
                    Credencial.TokenAcceso = Response.AccessToken;
                    Credencial.TokenRefresco = Response.RefreshToken;
                    // Validar Modo
                    CredencialDto credencialModo = this.credencialesClient.ActualizarModoAcceso(Credencial);
                    if(null != credencialModo)
                    {
                        // Actualizar datos en servicio Credenciales
                        Credencial = this.credencialesClient.ActualizarCredencialUsuario(credencialModo);
                    } else
                    {
                        // En caso de error consultando el Modo, se actualiza el registro de todas formas en modo Visualizacion
                        Credencial.ModoAcceso = Convert.ToDecimal(ModoAccesoUsuario.MODO_VISUALIZACION);
                        Credencial = this.credencialesClient.ActualizarCredencialUsuario(Credencial);
                    }
                }
                else
                {
                    // Sin respuesta correcta, comenzar nuevamente
                    TokenInformacion.EsRenovacion = false;
                    TokenInformacion.TokenAcceso = null;
                    TokenInformacion.TokenRefresco = null;
                }
            }
            else
            {
                // Token sigue siendo valido
                Resultado = true;
            }
            return Resultado;
        }

        [Inject]
        public void SetCredencialesClient(ICredencialesClient credencialesClient)
        {
            this.credencialesClient = credencialesClient;
        }
    }
}