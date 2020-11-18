using Microsoft.Owin.Security.OAuth;
using MS_ML_FU_CREDENCIALES.Persistence.Impl;
using MS_ML_FU_CREDENCIALES.RestClients.Impl;
using MS_ML_FU_CREDENCIALES.Services;
using MS_ML_FU_CREDENCIALES.Services.Impl;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MS_ML_FU_CREDENCIALES.Credenciales
{
    public class TokenProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Login inicial
            // No se disponen de datos de los tokens
            CredencialDto credencial = new CredencialDto();
            credencial.Usuario = context.UserName;
            credencial.TokenAcceso = context.Password;
            IMsCredencialesService credencialesService = new MsCredencialesService(new MsCredencialesPersistence(), new MsCredencialesClient());
            if (credencialesService.ValidarCredencialUsuario(credencial))
            {
                ClaimsIdentity identidad = new ClaimsIdentity(context.Options.AuthenticationType);
                identidad.AddClaim(new Claim(ClaimTypes.Role, "FORMULARIO"));
                context.Validated(identidad);
            }
        }

    }
}