using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza
{
    public class CalculoPrimaDtoMapper
    {
        [JsonProperty(PropertyName = "idCalculoPrima")] 
        public int ID_CALCULOPRIMA { get; set; }

        [JsonProperty(PropertyName = "nombre")] 
        public string NOMBRE { get; set; }

        [JsonProperty(PropertyName = "vigente")] 
        public string VIGENTE { get; set; }

        [JsonProperty(PropertyName = "siglaSacs")] 
        public string SIGLA_SAC { get; set; }
    }
}
