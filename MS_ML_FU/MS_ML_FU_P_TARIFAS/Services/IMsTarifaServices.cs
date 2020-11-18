using MS_ML_FU_DLL_TERCEROS.Model.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_TARIFAS.Services
{
    public interface IMsTarifaServices
    {
        List<DatosEstandar> getListaRelacion();
    }
}