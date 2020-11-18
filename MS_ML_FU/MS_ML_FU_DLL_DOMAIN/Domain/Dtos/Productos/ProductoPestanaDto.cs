using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos.Parametricas;
using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos
{
    public class ProductoPestanaDto : PestanaPadre
    {
        [JsonProperty(PropertyName = "parametrica")]
        public ParametricaProductoDetalle Parametrica { get; set; }

        [JsonProperty(PropertyName = "datosCarga")]
         public ProductoDto DatosCarga { get; set; }
       
    }
}
