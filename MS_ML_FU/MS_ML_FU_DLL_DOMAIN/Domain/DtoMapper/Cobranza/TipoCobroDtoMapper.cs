using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza
{
    public class TipoCobroDtoMapper
    {
        [JsonProperty(PropertyName = "idTipoCobro")] 
        public int ID_TIPOCOBRO { get; set; }

        [JsonProperty(PropertyName = "nombre")] 
        public string NOMBRE { get; set; }

        [JsonProperty(PropertyName = "vigente")] 
        public string VIGENTE { get; set; }

        [JsonProperty(PropertyName = "siglaSacs")] 
        public string SIGLA_SAC { get; set; }
    }
}
