using Newtonsoft.Json;
using System;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio
{
    public class ConvenioDtoMapper
    {
        [JsonProperty(PropertyName = "idConvenio")] 
        public int ID_CONVENIO { get; set; }
        
        [JsonProperty(PropertyName = "nombre")] 
        public string NOMBRE { get; set; }
        
        [JsonProperty(PropertyName = "vigente")] 
        public string VIGENTE { get; set; }
        
        [JsonProperty(PropertyName = "idTipoConvenio")] 
        public int ID_TIPOCONVENIO { get; set; }
        
        [JsonProperty(PropertyName = "nroSacs")] 
        public Nullable<int> NRO_SACS { get; set; }
        
        [JsonProperty(PropertyName = "tipoConvenio")]
        public TipoConvenioDtoMapper FUWEB_P_TIPOCONVENIO { get; set; }

        [JsonProperty(PropertyName = "orden")]
        public Nullable<int> ORDEN { get; set; }

    }
}
