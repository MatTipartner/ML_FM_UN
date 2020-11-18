using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Producto;
using Newtonsoft.Json;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos
{
    public class ProductoDto
    {
        [JsonProperty(PropertyName = "listProductoSalud")]
        public EstructuraListaProductoSalud ListProductoSalud { get; set; }

        [JsonProperty(PropertyName = "listProductoVidaAp")]
        public EstructuraListaProductoVidaAp ListProductoVidaAp { get; set; }

        [JsonProperty(PropertyName = "idVidaAp")]
        public EstructuraEntera Id_VidaAp { get; set; }

        [JsonProperty(PropertyName = "freecover")]
        public EstructuraCadena Freecover { get; set; }

        [JsonProperty(PropertyName = "capitalMaximo")]
        public EstructuraDecimal CapitalMaximo { get; set; }

        [JsonProperty(PropertyName = "cumulo")]
        public EstructuraCadena Cumulo { get; set; }

        [JsonProperty(PropertyName = "listCascada")]
        public EstructuraCascada ListaCascada { get; set; }
    }
}
