using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface ICredencialesService
    {
        Boolean ControlAcceso(String SiglaUsuario, int NroBizflow, TokenInformacion TokenInformacion, out CredencialDto credencial);
    }
}
