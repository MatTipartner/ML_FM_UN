using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.CondicionEspecial;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.CondicionEspecial.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;

namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface ICondicionesEspecialesService
    {
        CondEspecPestanaDto GetCondicionEspecial(CabeceraJsonDto cabeceraDto);

        ParametricasCondEspecDetalle GetParametricasCondicionEspecial();
    }
}
