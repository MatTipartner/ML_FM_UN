using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura
{
    public class PestanaPadre
    {
        [JsonProperty(PropertyName = "cabecera")]
        public CabeceraJsonDto Cabecera { get; set; }

    }
}
