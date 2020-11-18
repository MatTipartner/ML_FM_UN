using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.CondicionEspecial;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System.Collections.Generic;

namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface ICondicionesEspecialesClient
    {
        CondEspecDto GetFormularioTarida(int nroFormulario, int grupoFormulario);

        List<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio);

        List<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio);

        List<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla);

        List<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla);
    }
}