using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Parametros;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System.Collections.Generic;

namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface IParametrosClient
    {
        ParametroDto GetFormularioTarida(int nroFormulario, int grupoFormulario);

        List<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio, int grupoFormulario);

        List<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio, int grupoFormulario);

        List<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla, int grupoFormulario);

        List<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla, int grupoFormulario);
    }
}