using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_CONVENIOS.Persistence
{
    public interface IMsConveniosPersistence
    {
        IEnumerable<ParametricasBdEstandar> GetListaVademecum();

        IEnumerable<ParametricasBdEstandar> GetListaTipoFacturacion();

        IEnumerable<ParametricasBdReferencia> GetListaConvenio();

        IEnumerable<OtrosConveniosDtoMapper> GetConvenioPorGrupo(int GrupoPoliza);

        IEnumerable<FarmaciaDtoMapper> GetFarmaciaPorGrupo(int GrupoPoliza);

        Boolean SetsFarmacia(IEnumerable<FarmaciaDtoMapper> listaFarmaciaMapper);

        Boolean SetDeleteFarmacia(IEnumerable<FarmaciaDtoMapper> listaFarmaciaMapper);

        Boolean SetOtrosConvenios(IEnumerable<OtrosConveniosDtoMapper> listaOtrosConveniosMapper);

        Boolean SetDeleteOtrosConvenios(IEnumerable<OtrosConveniosDtoMapper> listaOtrosConveniosMapper);
    }
}