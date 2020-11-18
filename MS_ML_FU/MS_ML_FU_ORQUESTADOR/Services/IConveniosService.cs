using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using System;

namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface IConveniosService
    {
        ConvenioPestanaDto GetConvenio(CabeceraJsonDto cabeceraDto);

        ParametricaConvenioDetalle GetParametricasConvenio();

        Boolean SetGuardarPestanaConvenio(ConvenioPestanaDto datosConenio);
    }
}
