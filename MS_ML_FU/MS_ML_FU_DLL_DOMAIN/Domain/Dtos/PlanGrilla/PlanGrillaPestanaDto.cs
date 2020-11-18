using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.PlanGrilla.Parametricas;
using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.PlanGrilla
{
    public class PlanGrillaPestanaDto : PestanaPadre
    {
        [JsonProperty(PropertyName = "parametrica")]
        public ParametricasPlanGrillaDetalle Parametrica { get; set; }

        [JsonProperty(PropertyName = "datosCarga")]
         public PlanGrillaDto DatosCarga { get; set; }
    }
}
