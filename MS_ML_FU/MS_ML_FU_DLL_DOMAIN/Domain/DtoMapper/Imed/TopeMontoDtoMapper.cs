
using Newtonsoft.Json;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Imed
{
    public class TopeMontoDtoMapper
    {
        [JsonProperty(PropertyName = "idImedTopeMonto")]
        public int ID_IMEDTOPEMONTO { get; set; }

        [JsonProperty(PropertyName = "idTipoTopeMonto")] 
        public int ID_TIPOTOPEMONTO { get; set; }

        [JsonProperty(PropertyName = "minimoPesos")] 
        public int MINIMO_PESOS { get; set; }

        [JsonProperty(PropertyName = "maximoUD")] 
        public int MAXIMO_UF { get; set; }
    }
}
