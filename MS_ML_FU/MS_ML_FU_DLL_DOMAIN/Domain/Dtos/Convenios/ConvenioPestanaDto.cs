using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using Newtonsoft.Json;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios
{
    public class ConvenioPestanaDto : PestanaPadre
    {
        [JsonProperty(PropertyName = "parametrica")]
        public ParametricaConvenioDetalle Parametrica { get; set; }

        [JsonProperty(PropertyName = "datosCarga")]
         public ConvenioDto DatosCarga { get; set; }
    }
}
