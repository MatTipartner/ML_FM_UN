using Newtonsoft.Json;
using System;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Perfil
{
    public class Permisos
    {
        [JsonProperty(PropertyName = "idPestana")]
        public int IdPestana { get; set; }

        [JsonProperty(PropertyName = "nombrePestana")]
        public String NombrePestana { get; set; }
        
        [JsonProperty(PropertyName = "idPermiso")]
        public int IdPermiso { get; set; }

        [JsonProperty(PropertyName = "nombrePermiso")]
        public String NombrePermiso { get; set; }
    }
}
