using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;


namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface ITarifasClient
    {
        IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio);

        IEnumerable<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla);

        IEnumerable<TarifaGrupoDto> GetTarifaCoberturaGrupo(int grupoFormulario);

        TarifaDtoMapper GetTarifaPoliza(int nroFormulario);

        Boolean SetTarifa(TarifaDtoMapper listaVidaAp);

        Boolean SetListaTariafaCobertura(IEnumerable<TarifaGrupoDtoMapper> listaTariafaCobertura, int grupoFormulario);

        Boolean SetListaTariafaCoberturaFull(IEnumerable<TarifaGrupoDtoMapper> listaTariafaCobertura, int grupoFormulario);
    }
}