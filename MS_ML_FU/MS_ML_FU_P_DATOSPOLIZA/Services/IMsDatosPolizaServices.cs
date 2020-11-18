using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_DATOSPOLIZA.Services
{
    public interface IMsDatosPolizaServices
    {
        IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio);

        IEnumerable<ParametricasBdEstandar> GetListaTabla(BaseDatosParametrica tabla);

        DatosPolizaDtoMapper GetFormularioPoliza(int NroPoliza);

        IEnumerable<UbicacionGeograficaDtoMapper> GetUbicacionesGeograficaPorPoliza(int NroPoliza);

        Boolean SetDatosPoliza(DatosPolizaDtoMapper datosPoliza);
    }
}