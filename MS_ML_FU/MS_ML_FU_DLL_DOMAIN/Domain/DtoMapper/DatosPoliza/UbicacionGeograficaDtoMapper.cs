using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza
{
    public class UbicacionGeograficaDtoMapper
    {
        [JsonProperty(PropertyName = "idUbicacionGeografica")]
        public int ID_UBICACIONGEOGRAFICA { get; set; }

        [JsonProperty(PropertyName = "nombreUbicacionGeografica")]
        public string NOMBRE_UBICACIONGEOGRAFICA { get; set; }

        [JsonProperty(PropertyName = "nroPoliza")]
        public Nullable<int> NRO_POLIZA { get; set; }

    }
}
