using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using Newtonsoft.Json;
using System;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas
{
    public class CabeceraJsonDto
    {
        [JsonProperty(PropertyName = "nroFormulario")]
        public int NroFormulario { get; set; }

        [JsonProperty(PropertyName = "nroBizflow")] 
        public int NroBizflow { get; set; }

        [JsonProperty(PropertyName = "idPestana")] 
        public PestanaParametrica IdPestana { get; set; }

        [JsonProperty(PropertyName = "siglaPermisoPestana")]
        public String SiglaPermisoPestana { get; set; }

        [JsonProperty(PropertyName = "IdGrupoFormulario")] 
        public int IdGrupoFormulario { get; set; }

        [JsonProperty(PropertyName = "siglaUsario")]
        public String SiglaUsuario { get; set; }

        [JsonProperty(PropertyName = "token_informacion")]
        public TokenInformacion TokenInformacion { get; set; }

    }
}
