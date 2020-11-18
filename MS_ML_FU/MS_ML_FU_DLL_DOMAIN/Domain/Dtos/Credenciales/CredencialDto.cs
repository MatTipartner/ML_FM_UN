using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales
{
    public class CredencialDto
    {
        [JsonProperty(PropertyName = "usuario")]
        public string Usuario { get; set; }

        [JsonProperty(PropertyName = "nroBizflow")]
        public Nullable<decimal> NroBizflow { get; set; }

        [JsonProperty(PropertyName = "modoAcceso")]
        public Nullable<decimal> ModoAcceso { get; set; }

        [JsonProperty(PropertyName = "fechaMovimiento")]
        public Nullable<System.DateTime> FechaMovimiento { get; set; }

        [JsonProperty(PropertyName = "tokenAcceso")]
        public string TokenAcceso { get; set; }

        [JsonProperty(PropertyName = "tokenRefresco")]
        public string TokenRefresco { get; set; }

        [JsonProperty(PropertyName = "tiempoExpiracionAcceso")]
        public Nullable<decimal> TiempoExpiracionAcceso { get; set; }

        [JsonProperty(PropertyName = "tiempoExpiracionRefresco")]
        public Nullable<decimal> TiempoExpiracionRefresco { get; set; }

    }
}
