using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;


namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface IConvenioClient
    {

        IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio);

        IEnumerable<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio);

        IEnumerable<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla);

        IEnumerable<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla);

        IEnumerable<FarmaciaDto> GetFarmacia(int GrupoFormulario);

        IEnumerable<OtrosConvenioDto> GetOtrosConvenios(int GrupoFormulario);

        Boolean SetOtrosConvenios(IEnumerable<OtrosConvenioDto> otrosConvenioDto, int grupoFormulario);

        Boolean SetFarmacia(IEnumerable<FarmaciaDto> farmaciaDto, int grupoFormulario);
    }
}