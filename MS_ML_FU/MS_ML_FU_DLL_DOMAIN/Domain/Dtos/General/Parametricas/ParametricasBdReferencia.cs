using Newtonsoft.Json;
using System;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas
{
    public class ParametricasBdReferencia
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        
        [JsonProperty(PropertyName = "descripcion")]
        public String Descripcion { get; set; }

        [JsonProperty(PropertyName = "idReferencia")]
        public int IdReferencia { get; set; }
    }
}
