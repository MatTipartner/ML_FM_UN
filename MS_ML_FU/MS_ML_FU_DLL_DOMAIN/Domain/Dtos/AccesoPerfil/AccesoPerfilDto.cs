using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Perfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Redireccion;
using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil
{
    public class AccesoPerfilDto
    {
        [JsonProperty(PropertyName = "perfilUsuario")]
        public PerfilUsuario PerfilUsuario { get; set; }

        [JsonProperty(PropertyName = "direccion")]
        public RedireccionPerfil Direccion { get; set; }
    }
}
