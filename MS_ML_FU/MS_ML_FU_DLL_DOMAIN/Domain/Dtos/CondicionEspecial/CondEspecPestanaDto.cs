using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.CondicionEspecial.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.CondicionEspecial
{
    public class CondEspecPestanaDto : PestanaPadre
    {
        [JsonProperty(PropertyName = "parametrica")]
        public ParametricasCondEspecDetalle Parametrica { get; set; }

        [JsonProperty(PropertyName = "datosCarga")]
         public CondEspecDto DatosCarga { get; set; }
    }
}
