using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje
{
    public class AtributoPestanaDtoMapper
    {
        [JsonProperty(PropertyName = "idAtributoPestana")] 
        public int ID_ATRIBUTOPESTANA { get; set; }

        [JsonProperty(PropertyName = "nombre")] 
        public string NOMBRE { get; set; }

        [JsonProperty(PropertyName = "vigente")] 
        public string VIGENTE { get; set; }

        [JsonProperty(PropertyName = "idPestana")] 
        public int ID_PESTANA { get; set; }
    }
}
