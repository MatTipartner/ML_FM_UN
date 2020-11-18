
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio
{
    public class TipoConvenioDtoMapper
    {
        [JsonProperty(PropertyName = "idtipoConvenio")] 
        public int ID_TIPOCONVENIO { get; set; }
        
        [JsonProperty(PropertyName = "nombre")] 
        public string NOMBRE { get; set; }
        
        [JsonProperty(PropertyName = "vigente")] 
        public string VIGENTE { get; set; }
    }
}
