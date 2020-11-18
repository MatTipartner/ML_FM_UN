using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa
{
    public class TarifaDtoMapper
    {
        [JsonProperty(PropertyName = "idTarifa")]
        public int ID_TARIFA { get; set; }

        [JsonProperty(PropertyName = "siglaCobro")]
        public string SIGLA_COBRO { get; set; }

        [JsonProperty(PropertyName = "adicionTarifa")] 
        public string ADICION_TARIFA { get; set; }

        [JsonProperty(PropertyName = "tarifaVigencia")] 
        public string TARIFA_VIGENCIA { get; set; }

        [JsonProperty(PropertyName = "primaProporcional")] 
        public string PRIMA_PROPORCIONAL { get; set; }

        [JsonProperty(PropertyName = "edadFija")] 
        public string EDAD_FIJA { get; set; }

        [JsonProperty(PropertyName = "nroPoliza")] 
        public int NRO_POLIZA { get; set; }

    }
}
