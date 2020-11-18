using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Cobranza.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using System;

namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface ICobranzaService
    {
        CobranzaPestanaDto GetCobranza(CabeceraJsonDto cabeceraDto);

        Boolean SetGuardarPestanaCobranza(CobranzaPestanaDto datosCobranza);

        Boolean SetPeriodicidad(string periodicidad, int nroFormulario);
    }
};
