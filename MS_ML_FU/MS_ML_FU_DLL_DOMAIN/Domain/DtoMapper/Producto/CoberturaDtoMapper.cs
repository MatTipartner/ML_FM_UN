using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto
{
    public class CoberturaDtoMapper
    {
        [JsonProperty(PropertyName = "idCobertura")] 
        public int ID_COBERTURA { get; set; }

        [JsonProperty(PropertyName = "nombre")] 
        public string NOMBRE { get; set; }

        [JsonProperty(PropertyName = "vigente")] 
        public string VIGENTE { get; set; }

        [JsonProperty(PropertyName = "nroSacs")] 
        public int NRO_SACS { get; set; }

        [JsonProperty(PropertyName = "idTipoProducto")] 
        public int ID_TIPOPRODUCTO { get; set; }

        [JsonProperty(PropertyName = "Ordenar")] 
        public Nullable<short> ORDENAR { get; set; }

    }
}
