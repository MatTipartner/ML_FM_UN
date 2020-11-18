using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza
{
    public class DatosPolizaPestanaDto : PestanaPadre     {     
        
        [JsonProperty(PropertyName = "parametrica")]
        public ParametricaPolizaDetalle ParameticasPoliza { get; set; }
       
        [JsonProperty(PropertyName = "datosCarga")]
        public DatosPolizaDto DatosCarga { get; set; }
    }
}
