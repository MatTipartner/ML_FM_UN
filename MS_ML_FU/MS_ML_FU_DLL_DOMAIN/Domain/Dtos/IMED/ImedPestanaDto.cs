using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.IMED.Parametricas;
using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.IMED
{
    public class ImedPestanaDto : PestanaPadre
    {
        [JsonProperty(PropertyName = "parametrica")]
        public ParametricaImedDetalle Parametrica { get; set; }

        [JsonProperty(PropertyName = "datosCarga")]
         public ImedDto DatosCarga { get; set; }
    }
}
