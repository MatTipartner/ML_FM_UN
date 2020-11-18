using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Parametricas;
using System;
using System.Collections.Generic;

namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface ITarifasService
    {
        TarifaPestanaDto GetTarifa(CabeceraJsonDto cabeceraDto);       
        
        ParametricaTarifasDetalle GetParametricasTarifa(int grupoFormulario);
        
        Boolean SetGuardarPestanaTarifa(TarifaPestanaDto detosTarifa);
        
        Boolean SetTarifa(TarifaPestanaDto datosTarifa, int nroFormulario);
        
        Boolean SetTarifaCobertura(TarifaPestanaDto datosTarifaCobertura, int grupoFormualario);

        Boolean SetActualizarTarifaCobertura(int grupoFormulario);
    }
}
