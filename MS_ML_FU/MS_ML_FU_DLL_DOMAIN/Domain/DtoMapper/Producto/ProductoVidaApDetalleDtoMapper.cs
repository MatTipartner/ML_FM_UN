using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto
{
    public class ProductoVidaApDetalleDtoMapper
    {
        [JsonProperty(PropertyName = "idProductoListVidaAp")] 
        public int ID_PRODUCTOLIST_VIDAAP { get; set; }

        [JsonProperty(PropertyName = "idCobertura")]
        public int ID_COBERTURA { get; set; }

        [JsonProperty(PropertyName = "capitalFijo")]
        public string CAPITAL_FIJO { get; set; }

        [JsonProperty(PropertyName = "cantidadRenta")]
        public Nullable<decimal> CANTIDAD_RENTA { get; set; }

        [JsonProperty(PropertyName = "capitalMinimo")]
        public Nullable<decimal> CAPITAL_MINIMO_PESO { get; set; }

        [JsonProperty(PropertyName = "capitalMaximo")]
        public Nullable<decimal> CAPITAL_MAXIMO_UF { get; set; }              

        [JsonProperty(PropertyName = "idAgrupacion")]
        public int ID_AGRUPACION { get; set; }

        //public CoberturaDtoMapper FUWEB_P_COBERTURA { get; set; }
    }
}
