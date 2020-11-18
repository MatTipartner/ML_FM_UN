using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_MENU.Persistence
{
    public interface IMsMenuPersistence
    {
        List<ParametricasBdEstandar> GetListaTipoFormulario();

        List<ParametricasBdReferencia> GetListaTipoFormularioDetalle();
    }
}