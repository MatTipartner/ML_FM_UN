using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_DATOSPOLIZA.Persistence
{
    public interface IMsDatosPolizaPersistence
    {        
        IEnumerable<ParametricasBdEstandar> GetListaPoliza();
        
        IEnumerable<ParametricasBdEstandar> GetListaRiesgo();
        
        IEnumerable<ParametricasBdEstandar> GetListaLineaNegocio();
        
        IEnumerable<ParametricasBdEstandar> GetListaCanalVenta();
        
        IEnumerable<ParametricasBdEstandar> GetListaTipoAdicion();
        
        DatosPolizaDtoMapper GetFormularioPoliza(int NroPoliza);
        
        IEnumerable<UbicacionGeograficaDtoMapper> GetUbicacionesGeograficaPorPoliza(int NroPoliza);

        Boolean SetDatosPoliza(DatosPolizaDtoMapper datosPoliza);

        Boolean SetDeletebicacionGeografica(IEnumerable<UbicacionGeograficaDtoMapper> listaEliminar);

        Boolean SetUbicacionGeografica(IEnumerable<UbicacionGeograficaDtoMapper> listaGeorgrafica);
    }
}