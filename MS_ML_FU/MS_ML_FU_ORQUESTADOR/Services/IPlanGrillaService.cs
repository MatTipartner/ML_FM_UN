using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.PlanGrilla;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.PlanGrilla.Parametricas;


namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface IPlanGrillaService
    {
        PlanGrillaPestanaDto GetPlanGrilla(CabeceraJsonDto cabeceraDto);

        ParametricasPlanGrillaDetalle GetParametricasPlanGrilla(int grupoFormulario);
    }
}
