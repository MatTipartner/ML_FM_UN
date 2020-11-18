using Newtonsoft.Json;
using System;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Redireccion
{
    public class RedireccionPerfil
    {
        [JsonProperty(PropertyName = "idDireccion")]
        public int IdDireccion { get; set; }

        [JsonProperty(PropertyName = "nombreDireccion")]
        public String NombreDireccion { get; set; }
    }
}
