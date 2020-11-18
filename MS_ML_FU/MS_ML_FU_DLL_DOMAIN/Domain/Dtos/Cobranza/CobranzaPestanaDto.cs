using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Cobranza.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Cobranza
{
    public class CobranzaPestanaDto : PestanaPadre
    {
        [JsonProperty(PropertyName = "parametrica")]
        public ParametricasCobranzaDetalle Parametrica { get; set; }

        [JsonProperty(PropertyName = "datosCarga")]
         public CobranzaDto DatosCarga { get; set; }
    }
}
