using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.IMED;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.IMED.Parametricas;


namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface IImedService
    {
        ImedPestanaDto GetImed(CabeceraJsonDto cabeceraDto);

        ParametricaImedDetalle GetParametricasImed(int grupoFormulario);
    }
}
