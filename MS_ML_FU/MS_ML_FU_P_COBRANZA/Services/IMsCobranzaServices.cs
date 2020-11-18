using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_COBRANZA.Services
{
    public interface IMsCobranzaServices
    {
        IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio);

        IEnumerable<ParametricasBdEstandar> GetListaTabla(BaseDatosParametrica tabla);

        CobranzaDtoMapper GetCobranza(int nroFormulario);

        CobranzaGrupoDtoMapper GetCobranzaGrupo(int grupoFormulario);

        Boolean SetCobranza(CobranzaDtoMapper listaCobranzaMapper);

        Boolean SetCobranzaGrupo(CobranzaGrupoDtoMapper cobranzaGrupo, int nroFormulario);

        Boolean SetCobranzaRiesgo(IEnumerable<CobranzaRiesgoDtoMapper> listaCobranzaRiesgoMapper, int grupoFormulario);

        Boolean SetPeriodicidad(string periodicidad, int nroFormulario);
    }
}