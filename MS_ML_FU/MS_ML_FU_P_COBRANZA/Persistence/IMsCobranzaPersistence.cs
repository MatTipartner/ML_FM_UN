using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;


namespace MS_ML_FU_P_COBRANZA.Persistence
{
    public interface IMsCobranzaPersistence
    {
        IEnumerable<ParametricasBdEstandar> GetListaAquienCobranza();
        
        IEnumerable<ParametricasBdEstandar> GetListaTipoCobro();
        
        IEnumerable<ParametricasBdEstandar> GetListaCalculoPrima();
        
        IEnumerable<ParametricasBdEstandar> GetListaDestintarioCobranza();
        
        IEnumerable<ParametricasBdEstandar> GetListaTipoFacturacionCobranza();
        
        IEnumerable<ParametricasBdEstandar> GetListaRiegoFacturacion();
        
        CobranzaDtoMapper GetCobranza(int nroFormulario);
        
        CobranzaGrupoDtoMapper GetCobranzaGrupo(int grupoFormulario);

        Boolean SetDeleteCobranza(CobranzaDtoMapper listaCobranzaMapper);

        Boolean SetCobranza(CobranzaDtoMapper listaCobranzaMapper);

        Boolean SetDeleteCobranzaGrupo(CobranzaGrupoDtoMapper listaCobranzaGrupoMapper);

        Boolean SetCobranzaGrupo(CobranzaGrupoDtoMapper listaCobranzaGrupoMapper);

        Boolean SetDeleteCobranzaRiesgo(IEnumerable<CobranzaRiesgoDtoMapper> listaCobranzaRiesgoMapper);

        Boolean SetCobranzaRiesgo(IEnumerable<CobranzaRiesgoDtoMapper> listaCobranzaRiesgoMapper);

        IEnumerable<ParametricasBdEstandar> GetListaTipoContributoriedad();

        Boolean SetPeriodicidad(string periodicidad, int nroFormulario);
    }
}