using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Perfil
{
    public class PerfilUsuario
    {
        [JsonProperty(PropertyName = "siglaUsuario")]
        public String siglaUsuario { get; set; }

        [JsonProperty(PropertyName = "nombreUsuario")]
        public String NombreUsuario { get; set; }

        [JsonProperty(PropertyName = "nroBizflow")]
        public int NroBizflow { get; set; }

        [JsonProperty(PropertyName = "permisoPestana")]
        public List<Permisos> PermisoPestana { get; set; }
    }
}
