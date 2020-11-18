using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_IMED.Services
{
    public interface IMsImedServices
    {
        IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio);

        IEnumerable<ParametricasBdEstandar> GetListaTablaEstandar(BaseDatosParametrica tabla);

        IEnumerable<ParametricasBdReferencia> GetListaTablaReferencial(BaseDatosParametrica tabla);
    }
}