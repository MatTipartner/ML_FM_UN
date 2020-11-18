using Newtonsoft.Json;
using System;


namespace MS_ML_FU_DLL_DOMAIN.Terceros.General
{
    public class ParametricaServicioReferencia
    {
        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public String Descripcion { get; set; }

        [JsonProperty(PropertyName = "idReferencia")]
        public String IdReferencia { get; set; }
    }
}
