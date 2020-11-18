using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_BMI.Services
{
    public interface IMsParametrosServices
    {
        IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio);

        List<ParametricasBdEstandar> GetListaTabla(BaseDatosParametrica tabla);
    }
}