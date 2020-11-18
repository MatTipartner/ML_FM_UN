using System;
using Newtonsoft.Json;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones
{
    public class EstructuraGeneral
    {
        [JsonProperty(PropertyName = "id")]
        public Int64 IdCampo { get; set; }
        
        [JsonProperty(PropertyName = "observaciones")]
        public String ObservacionesCampo { get; set; }
        
        [JsonProperty(PropertyName = "tipoDato")]
        public String TipoDato { get; set; }

        [JsonProperty(PropertyName = "estado")]
        public String EstadoCampo { get; set; }

    }
}
