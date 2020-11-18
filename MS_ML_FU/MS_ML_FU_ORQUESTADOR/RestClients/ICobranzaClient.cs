using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;


namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface ICobranzaClient
    {
        IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio);

        IEnumerable<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio);

        IEnumerable<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla);

        IEnumerable<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla);

        CobranzaDtoMapper GetCobranza(int nroFormulario);

        CobranzaGrupoDtoMapper GetCobranzaGrupo(int grupoFormulario);

        Boolean SetCobranza(CobranzaDtoMapper cobranza);

        Boolean SetCobranzaGrupo(CobranzaGrupoDtoMapper cobranzaGrupo, int grupoFormulario);

        Boolean SetListaRiesgo(IEnumerable<CobranzaRiesgoDtoMapper> cobranzaRiesgo, int grupoFormulario);

        Boolean SetPeriodicidad(string periodicidad, int nroFormulario);
    }
}