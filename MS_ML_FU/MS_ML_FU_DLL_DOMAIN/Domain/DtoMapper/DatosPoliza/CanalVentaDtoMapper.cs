using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza
{
    public class CanalVentaDtoMapper
    {
        [JsonProperty(PropertyName = "idCanalVenta")]
        public int ID_CANALVENTA { get; set; }

        [JsonProperty(PropertyName = "nroCanalVentaSacs")]
        public int NRO_CANALVENTASACS { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string NOMBRE { get; set; }

        [JsonProperty(PropertyName = "vigente")]
        public string VIGENTE { get; set; }

    }
}
