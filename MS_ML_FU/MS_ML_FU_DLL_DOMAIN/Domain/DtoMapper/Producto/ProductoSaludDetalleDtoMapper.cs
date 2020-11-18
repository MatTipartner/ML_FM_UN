using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto
{
    public class ProductoSaludDetalleDtoMapper
    {
        [JsonProperty(PropertyName = "idProductoSalud")]
        public int ID_PRODUCTO_SALUD { get; set; }

        [JsonProperty(PropertyName = "idCobertura")]
        public int ID_COBERTURA { get; set; }

        [JsonProperty(PropertyName = "montoAsegurado")]
        public Nullable<decimal> MONTO_ASEGURADO { get; set; }      

        [JsonProperty(PropertyName = "polCad")]
        public string POL_CAD { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")]
        public int ID_AGRUPACION { get; set; }

       // public CoberturaDtoMapper FUWEB_P_COBERTURA { get; set; }
    }
}
