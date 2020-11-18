using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Parametricas;
using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas
{
    public class TarifaPestanaDto: PestanaPadre
    {
        [JsonProperty(PropertyName = "parametrica")]
        public ParametricaTarifasDetalle Parametrica { get; set; }

        [JsonProperty(PropertyName = "datosCarga")]
        public TarifaDto DatosCarga { get; set; }
    }
}
