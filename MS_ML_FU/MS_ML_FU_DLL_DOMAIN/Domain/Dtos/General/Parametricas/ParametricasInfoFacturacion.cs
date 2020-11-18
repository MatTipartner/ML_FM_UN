using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas
{
    public class ParametricasInfoFacturacion
    {
        [JsonProperty(PropertyName = "rut")]
        public int Rut { get; set; }

        [JsonProperty(PropertyName = "dv")]
        public String Dv { get; set; }

        [JsonProperty(PropertyName = "idReferencia")]
        public int IdReferencia { get; set; }
    }
}
