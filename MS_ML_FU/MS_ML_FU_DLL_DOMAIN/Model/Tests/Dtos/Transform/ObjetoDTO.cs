using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones;
using Newtonsoft.Json;

namespace MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Transform
{
    public class ObjetoDTO
    {
        [JsonProperty(PropertyName = "nombres")]
        public EstructuraCadena Nombres { get; set; }
        [JsonProperty(PropertyName = "apellidos")]
        public EstructuraCadena Apellidos { get; set; }
        [JsonProperty(PropertyName = "rut")]
        public EstructuraEntera Rut { get; set; }
        [JsonProperty(PropertyName = "fechaNacimiento")]
        public EstructuraFecha FechaNacimiento { get; set; }

    }
}
