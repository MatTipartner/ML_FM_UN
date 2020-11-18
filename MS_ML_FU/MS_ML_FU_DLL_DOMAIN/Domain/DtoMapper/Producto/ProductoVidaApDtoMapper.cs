using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto
{
    public class ProductoVidaApDtoMapper
    {
        [JsonProperty(PropertyName = "idProductoVidaAp")] 
        public int ID_PRODUCTO_VIDAAP { get; set; }

        [JsonProperty(PropertyName = "freecover")]
        public string FREECOVER { get; set; }

        [JsonProperty(PropertyName = "captalMaximo")]
        public Nullable<decimal> CAPITALMAXINO { get; set; }

        [JsonProperty(PropertyName = "cumulo")]
        public string CUMULO { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")] 
        public int ID_AGRUPACION { get; set; }
    }
}
