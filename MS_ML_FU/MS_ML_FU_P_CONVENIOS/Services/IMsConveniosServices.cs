using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;

namespace MS_ML_FU_P_CONVENIOS.Services
{
    public interface IMsConveniosServices
    {
        IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio);

        IEnumerable<ParametricasBdEstandar> GetListaTabla(BaseDatosParametrica tabla);

        IEnumerable<ParametricasBdReferencia> GetListaTablaRef(BaseDatosParametrica tabla);

        IEnumerable<OtrosConveniosDtoMapper> GetOtrosConveniosMapper(int GrupoFormulario);

        IEnumerable<OtrosConvenioDto> GetOtrosConvenios(int GrupoFormulario);

        IEnumerable<FarmaciaDto> GetFarmacia(int GrupoFormulario);

        IEnumerable<FarmaciaDtoMapper> GetFarmaciaMapper(int GrupoFormulario);

        Boolean SetConvenio(IEnumerable<OtrosConvenioDto> listaConvenioDto, int grupoFormulario);

        Boolean SetFarmacia(IEnumerable<FarmaciaDto> listaFarmaciaDto, int grupoFormulario);
    }
}