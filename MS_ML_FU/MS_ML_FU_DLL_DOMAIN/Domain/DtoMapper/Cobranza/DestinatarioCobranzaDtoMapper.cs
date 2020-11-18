using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza
{
    public class DestinatarioCobranzaDtoMapper
    {
        [JsonProperty(PropertyName = "idDestinararioCobranza")] 
        public int ID_DESTINATARIOCOBRANZA { get; set; }

        [JsonProperty(PropertyName = "nombre")] 
        public string NOMBRE { get; set; }

        [JsonProperty(PropertyName = "vigente")] 
        public string VIGENTE { get; set; }

        [JsonProperty(PropertyName = "nroScas")] 
        public int NRO_SAC { get; set; }
    }
}
