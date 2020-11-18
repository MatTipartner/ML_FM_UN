using MS_ML_FU_DLL_TERCEROS.Model.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_TARIFAS.Services.Impl
{
    public class MsTarifaServices:IMsTarifaServices
    {
        public List<DatosEstandar> getListaRelacion()
        {
            List<DatosEstandar> listRelacion = new List<DatosEstandar>();
            DatosEstandar lE = new DatosEstandar();
            lE.Id = 1;
            lE.Nombre = "Madre";
            listRelacion.Add(lE);
            DatosEstandar lE2 = new DatosEstandar();
            lE2.Id = 2;
            lE2.Nombre = "Esposo";
            listRelacion.Add(lE2);
            return listRelacion;
        }
    }
}