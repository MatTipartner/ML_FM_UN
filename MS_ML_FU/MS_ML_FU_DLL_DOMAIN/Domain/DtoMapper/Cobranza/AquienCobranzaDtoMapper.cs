using Newtonsoft.Json;
using System;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza
{
    public class AquienCobranzaDtoMapper
    {
        [JsonProperty(PropertyName = "idAQuienConbranza")]
        public int ID_AQUIENCOBRANZA { get; set; }

        [JsonProperty(PropertyName = "nombre")] 
        public string NOMBRE { get; set; }

        [JsonProperty(PropertyName = "vigente")] 
        public string VIGENTE { get; set; }

        [JsonProperty(PropertyName = "siglaSacs")] 
        public string SIGLA_SAC { get; set; }
    }
}
