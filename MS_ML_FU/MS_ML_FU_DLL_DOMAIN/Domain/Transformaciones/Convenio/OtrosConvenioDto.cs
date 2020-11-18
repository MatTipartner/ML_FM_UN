using Newtonsoft.Json;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio
{
    public class OtrosConvenioDto
    {
        [JsonProperty(PropertyName = "idOtrosConvenios")]
        public int ID_OTROSCONVENIOS { get; set; }

        [JsonProperty(PropertyName = "idConvenio")]
        public int ID_CONVENIO { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")]
        public int ID_AGRUPACION { get; set; }

        [JsonProperty(PropertyName = "idTipoConvenio")]
        public int ID_TIPO_CONVENIO { get; set; }
    }
}
