using Newtonsoft.Json;
using System;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza
{
    public class CobranzaRiesgoDtoMapper
    {
        [JsonProperty(PropertyName = "idTipoRiesgo")]
        public int ID_TIPORIESGO { get; set; }

        [JsonProperty(PropertyName = "idCobranzaGrupo")]
        public int ID_COBRANZAGRUPO { get; set; }

        [JsonProperty(PropertyName = "riesgoTxt")]
        public string TEXTO { get; set; }
       
       // [JsonProperty(PropertyName = "riesgoFacturacion")]
       // public  RiesgoFacturacionDtoMapper FUWEB_P_RIESGOFACTURACION { get; set; }
    }
}
