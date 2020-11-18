using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones;
using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza
{
    public class UbicacionGeograficaPolizaDto
    {
        [JsonProperty(PropertyName = "idUbicacionGeografica")]
        public EstructuraEntera IdUbicacionGeografica { get; set; }

        [JsonProperty(PropertyName = "nombreUbicacionGeografica")]
        public EstructuraCadena NombreUbicacionGeografica { get; set; }

    }
}
