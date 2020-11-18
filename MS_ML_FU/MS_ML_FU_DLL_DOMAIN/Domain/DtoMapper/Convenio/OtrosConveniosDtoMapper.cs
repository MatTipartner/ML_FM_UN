using Newtonsoft.Json;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio
{
    public class OtrosConveniosDtoMapper
    {
        [JsonProperty(PropertyName = "idOtrosConvenio")] 
        public int ID_OTROSCONVENIOS { get; set; }

        [JsonProperty(PropertyName = "idConvenio")] 
        public int ID_CONVENIO { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")] 
        public int ID_AGRUPACION { get; set; }

        [JsonProperty(PropertyName = "convenio")] 
        public  ConvenioDtoMapper FUWEB_P_CONVENIO { get; set; }
    }
}
