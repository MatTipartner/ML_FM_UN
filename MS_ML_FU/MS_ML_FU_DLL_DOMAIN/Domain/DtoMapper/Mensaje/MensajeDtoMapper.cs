using Newtonsoft.Json;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje
{
    public class MensajeDtoMapper
    {
        [JsonProperty(PropertyName = "idMensaje")] 
        public int ID_MENSAJE { get; set; }

        [JsonProperty(PropertyName = "idAtributoPestana")]
        public int ID_ATRIBUTOPESTANA { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")]
        public int ID_AGRUPACION { get; set; }

        [JsonProperty(PropertyName = "idEstadoAtributo")] 
        public int ID_ESTADOATRIBUTO { get; set; }

        [JsonProperty(PropertyName = "mensaje")] 
        public string MENSAJE { get; set; }

        [JsonProperty(PropertyName = "fecha")] 
        public System.DateTime FECHA { get; set; }

        [JsonProperty(PropertyName = "siglaUsuario")] 
        public string SIGLA_USUARIO { get; set; }
       
        [JsonProperty(PropertyName = "atributoPestana")]
        public AtributoPestanaDtoMapper FUWEB_P_ATRIBUTOPESTANA { get; set; }

        [JsonProperty(PropertyName = "estadoAtributo")]
        public EstadoAtributoDtoMapper FUWEB_P_ESTADOATRIBUTO { get; set; }
    }
}
