using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza
{
    public class ContributoriedadDtoMapper
    {
        [JsonProperty(PropertyName = "idContributoriedad")] 
        public int ID_CONTRIBUTORIEDAD { get; set; }

        [JsonProperty(PropertyName = "nombre")] 
        public string NOMBRE { get; set; }

        [JsonProperty(PropertyName = "vigente")] 
        public string VIGENTE { get; set; }

        [JsonProperty(PropertyName = "visible")]
        public string VISIBLE { get; set; }
    }
}
