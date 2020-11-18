using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Dto;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;


namespace EJEMPLO.Services
{
    public interface IMsEjemplo
    {
        List<TipoGlosaDto> listaTipoGlosaBd();

        IEnumerable<ParametricaServicioEstandar> respuestaGetSettingData(ServiciosParametrica servicio);

        Boolean SetDatosPoliza();

        Boolean PruebaUpdate();

        Boolean PruebaDelete();
    }

}