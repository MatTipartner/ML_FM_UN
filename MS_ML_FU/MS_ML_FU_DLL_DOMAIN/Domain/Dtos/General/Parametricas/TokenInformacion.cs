using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas
{
    public class TokenInformacion
    {
        [JsonProperty(PropertyName = "tokenAcceso")]
        public String TokenAcceso { get; set; }

        [JsonProperty(PropertyName = "tokenRefresco")]
        public String TokenRefresco { get; set; }

        [JsonProperty(PropertyName = "esRenovacion")]
        [DefaultValue(false)]
        public Boolean EsRenovacion { get; set; }

    }
}
