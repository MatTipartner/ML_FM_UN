using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface ICredencialesClient
    {
        OAuth2ResponseDto GetOAuth2Acceso(CredencialDto credencial);

        OAuth2ResponseDto GetOAuth2Renovacion(String refreshToken);

        Boolean EsTokenValido(CredencialDto credencial);

        CredencialDto ActualizarCredencialUsuario(CredencialDto credencial);

        CredencialDto ActualizarModoAcceso(CredencialDto credencial);

    }
}
