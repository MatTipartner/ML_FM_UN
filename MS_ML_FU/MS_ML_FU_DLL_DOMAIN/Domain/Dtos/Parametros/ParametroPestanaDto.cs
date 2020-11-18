using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Parametros.Parametricas;
using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Parametros
{
    public class ParametroPestanaDto : PestanaPadre
    {
        [JsonProperty(PropertyName = "parametrica")]
        public ParametricaParametroDetalle Parametrica { get; set; }

        [JsonProperty(PropertyName = "datosCarga")]
         public ParametroDto DatosCarga { get; set; }
    }
}
