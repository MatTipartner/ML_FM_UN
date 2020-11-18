using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza
{
    public class LineaNegocioDtoMapper
    {
        [JsonProperty(PropertyName = "nroPoliza")]
        public int ID_LINEANEGOCIO { get; set; }

        [JsonProperty(PropertyName = "nroLineaNegocioSacs")]
        public int NRO_LENANEGOCIOSACS { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string NOMBRE { get; set; }

        [JsonProperty(PropertyName = "vigente")]
        public string VIGENTE { get; set; }

    }
}
