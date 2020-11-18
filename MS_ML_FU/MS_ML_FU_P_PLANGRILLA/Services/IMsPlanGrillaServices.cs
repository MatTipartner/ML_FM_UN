using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_PLANGRILLA.Services
{
    public interface IMsPlanGrillaServices
    {
        List<ParametricasBdEstandar> getListaPlanGrilla();
    }
}