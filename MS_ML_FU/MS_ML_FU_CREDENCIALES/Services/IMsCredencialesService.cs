using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_CREDENCIALES.Services
{
    public interface IMsCredencialesService
    {
        Boolean ValidarCredencialUsuario(CredencialDto credencial);

        Boolean ActualizarCredencial(CredencialDto credencial);

        void ActualizacionModoAcceso(CredencialDto credencial);

    }
}