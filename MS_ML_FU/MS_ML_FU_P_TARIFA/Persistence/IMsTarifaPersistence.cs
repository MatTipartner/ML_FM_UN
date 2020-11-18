using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_TARIFA.Persistence
{
    public interface IMsTarifaPersistence
    {
        IEnumerable<ParametricasBdEstandar> GetListaDefinicionTributaria();

        IEnumerable<TasaPrimaDtoMapper> GetTasaPrima(int TarifaGrupo);

        IEnumerable<TasaEspecialDtoMapper> GetListaEspecial(int TarifaGrupo);
        
        TarifaDtoMapper GetTarifaPoliza(int nroFormulario);
        
        IEnumerable<TarifaGrupoDtoMapper> GetTarifaCoberturaGrupo(int grupoFormulario);

        Boolean SetTarifa(TarifaDtoMapper tarifa);

        Boolean DeleteTarifa(TarifaDtoMapper tarifa);

        Boolean DeleteTarifaGrupo(IEnumerable<TarifaGrupoDtoMapper> listaTarifaGrupo);

        Boolean SetTarifaGrupo(IEnumerable<TarifaGrupoDtoMapper> otrasTarifasGrupoMapper);

        Boolean DeleteTasaPrima(IEnumerable<TasaPrimaDtoMapper> listaTasaPrima);

        Boolean SetTasaPrima(IEnumerable<TasaPrimaDtoMapper> otrasTasaPrimaMapper);

        Boolean DeleteTasaEspecial(IEnumerable<TasaEspecialDtoMapper> listaTasaEspecial);

        Boolean SetTasaEspecial(IEnumerable<TasaEspecialDtoMapper> otrasTasaEspecialMapper);
    }
}