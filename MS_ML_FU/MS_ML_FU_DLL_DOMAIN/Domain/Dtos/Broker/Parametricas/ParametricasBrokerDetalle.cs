using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Broker.Parametricas
{
    public class ParametricasBrokerDetalle
    {
        [JsonProperty(PropertyName = "holding")]
        public IEnumerable<ParametricaServicioEstandar> Holding { get; set; }

        [JsonProperty(PropertyName = "administrador")]
        public IEnumerable<ParametricaServicioReferencia> Administrador { get; set; }

        [JsonProperty(PropertyName = "ejecutivoCobranza")]
        public IEnumerable<ParametricaServicioReferencia> EjecutivoCobranza { get; set; }

        [JsonProperty(PropertyName = "ejecutivoComercial")]
        public IEnumerable<ParametricaServicioReferencia> EjecutivoComercial { get; set; }

        [JsonProperty(PropertyName = "ejecutivoMovimiento")]
        public IEnumerable<ParametricaServicioReferencia> EjecutivoMovimiento { get; set; }
    }
}
