using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_BMI.Persistence
{
    public interface IMsParametrosPersistence
    {
        List<ParametricasBdEstandar> GetListaAquienParametros();
        List<ParametricasBdEstandar> GetListaGrupoIsapre();
        List<ParametricasBdEstandar> GetListaPrestacionBasica();
    }
}