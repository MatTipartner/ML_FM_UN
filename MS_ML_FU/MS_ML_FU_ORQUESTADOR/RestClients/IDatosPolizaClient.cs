using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface IDatosPolizaClient
    {
        DatosPolizaDtoMapper GetFormularioPoliza(int nroFormulario);

        IEnumerable<ParametricaServicioEstandar> GetSettingServercio(ServiciosParametrica servicio);

        IEnumerable<ParametricasBdEstandar> GetSettingBaseDatos(BaseDatosParametrica tabla);

        Boolean SetDatosPoliza(DatosPolizaDtoMapper datosPoliza);

    }
}