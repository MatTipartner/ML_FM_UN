using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto
{
    public class CascadaDtoMapper
    {
        [JsonProperty(PropertyName = "idCascada")]
        public int ID_CASCADA { get; set; }

        [JsonProperty(PropertyName = "idProducto")]
        public int ID_PRODUCTO { get; set; }

        [JsonProperty(PropertyName = "idCobertura")]
        public int ID_COBERTURA { get; set; }

        [JsonProperty(PropertyName = "edad")]
        public Nullable<int> EDAD_HASTA { get; set; }

        [JsonProperty(PropertyName = "siglaSexo")]
        public string SIGLA_SEXO { get; set; }

        [JsonProperty(PropertyName = "siglaRelacion")] 
        public string SIGLA_RELACION { get; set; }

        [JsonProperty(PropertyName = "codigoPlan")]
        public string CODIGO_PLAN { get; set; }

        [JsonProperty(PropertyName = "cantidad")]
        public Nullable<int> CANTIDAD { get; set; }

        [JsonProperty(PropertyName = "monto")]
        public Nullable<decimal> MONTO { get; set; }

        [JsonProperty(PropertyName = "incluye")]
        public string INCLUYE { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")]
        public int ID_AGRUPACION { get; set; }

        //public  CoberturaDtoMapper FUWEB_P_COBERTURA { get; set; }
        //public  TipoProductoDtoMapper FUWEB_P_TIPOPRODUCTO { get; set; }
    }
}
