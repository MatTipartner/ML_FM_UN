using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Vista;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_TARIFA.Services
{
    public interface IMsTarifaServices
    {
        Boolean SetTarifa(TarifaDtoMapper Tarifa);
        
        Boolean DeleteTarifa(TarifaDtoMapper tarifa);
        
        Boolean DeleteTarifaCobertura(IEnumerable<TarifaGrupoDtoMapper> tarifaCobertura);

        Boolean SetTarifaCobertura(IEnumerable<TarifaGrupoDtoMapper> TarifaGrupo, int grupoFormulario);                
        
        IEnumerable<TarifaGrupoDtoMapper> GetTarifaCoberturaGrupo(int GrupoFormulario);
        
        IEnumerable<TasaEspecialDtoMapper> GetListaEspecial(int GrupoFormulario);
        
        IEnumerable<TasaPrimaDtoMapper> GetTasaPrima(int GrupoFormulario);
        
        IEnumerable<TarifaGrupoDto> GetTarifaCoberturaGrupoDto(int grupoFormulario);
        
        TarifaDtoMapper GetTarifa(int nroFormulario);
        
        IEnumerable<ParametricasBdEstandar> GetListaTabla(BaseDatosParametrica tabla);
        
        IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio);

        Boolean SetTarifaCoberturaFull(IEnumerable<TarifaGrupoDtoMapper> tarifaCobertura, int grupoFormulario);
    }
}