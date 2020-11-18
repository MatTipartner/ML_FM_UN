using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza
{
    public class RiesgoDtoMapper
    {
        [JsonProperty(PropertyName = "idRiesgo")]
        public int ID_RIESGO { get; set; }

        [JsonProperty(PropertyName = "riesgoSacs")]
        public string S_RIESGOSACS { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string NOMBRE { get; set; }

        [JsonProperty(PropertyName = "vigente")]
        public string VIGENTE { get; set; }

    }
}
