using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje
{
    public class EstadoAtributoDtoMapper
    {
        [JsonProperty(PropertyName = "isEstadoAtributo")] 
        public int ID_ESTADOATRIBUTO { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string NOMBRE { get; set; }

        [JsonProperty(PropertyName = "vigente")]
        public string VIGENTE { get; set; }
    }
}
