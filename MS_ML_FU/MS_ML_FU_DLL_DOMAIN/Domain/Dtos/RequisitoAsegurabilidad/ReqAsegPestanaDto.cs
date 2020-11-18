using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.RequisitoAsegurabilidad.Parametricas;
using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.RequisitoAsegurabilidad
{
    public class ReqAsegPestanaDto : PestanaPadre
    {
        [JsonProperty(PropertyName = "parametrica")]
        public ParametricaReqAseguDetalle Parametrica { get; set; }

        [JsonProperty(PropertyName = "datosCarga")]
         public ReqAsegDto DatosCarga { get; set; }
    }
}
