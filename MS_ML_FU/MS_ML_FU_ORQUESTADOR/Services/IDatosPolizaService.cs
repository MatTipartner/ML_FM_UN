using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using System;
using System.Collections.Generic;

namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface IDatosPolizaService
    {
        DatosPolizaPestanaDto GetDatosPoliza(CabeceraJsonDto cabecera);

        Boolean SetGuardarPestanaPoliza(DatosPolizaPestanaDto datosPolizaPestana);

    }
}
