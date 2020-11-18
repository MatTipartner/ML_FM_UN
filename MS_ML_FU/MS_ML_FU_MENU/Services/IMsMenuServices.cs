using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System.Collections.Generic;


namespace MS_ML_FU_MENU.Services
{
    public interface IMsMenuServices
    {
        IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio);

        IEnumerable<ParametricaServicioReferencia> RespuestaGetSettingDataParam(ServiciosParametrica servicio, int datoEntrada);

        List<ParametricasBdEstandar> GetListaTablaEstandar(BaseDatosParametrica tabla);

        List<ParametricasBdReferencia> GetListaTablaReferencia(BaseDatosParametrica tabla);
    }
}