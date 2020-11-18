using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System.Collections.Generic;


namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface IMenuClient
    {
        List<ParametricaServicioEstandar> GetParametrosMenuServicio(ServiciosParametrica servicio);

        List<ParametricasBdEstandar> GetParametrosMenuBd(BaseDatosParametrica tabla);

        List<ParametricasBdReferencia> GetParametrosMenuBdRef(BaseDatosParametrica tabla);
    }
}