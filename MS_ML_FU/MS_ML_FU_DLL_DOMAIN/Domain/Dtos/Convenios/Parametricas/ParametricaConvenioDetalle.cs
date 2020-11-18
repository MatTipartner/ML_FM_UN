using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios.Parametricas
{
    public class ParametricaConvenioDetalle
    {
        [JsonProperty(PropertyName = "farmacia")]
        public IEnumerable<ParametricasBdReferencia> Farmacia { get; set; }

        [JsonProperty(PropertyName = "vademecum")]
        public IEnumerable<ParametricasBdEstandar> Vademecum { get; set; }

        [JsonProperty(PropertyName = "tipoFacuracion")]
        public IEnumerable<ParametricasBdEstandar> TipoFacuracion { get; set; }

        [JsonProperty(PropertyName = "tipoMoneda")]
        public IEnumerable<ParametricaServicioEstandar> Moneda { get; set; }

        [JsonProperty(PropertyName = "carataResguardo")]
        public IEnumerable<ParametricasBdReferencia> CarataResguardo { get; set; }

        [JsonProperty(PropertyName = "otrosConvenios")]
        public IEnumerable<ParametricasBdReferencia> OtrosConvenios { get; set; }

        [JsonProperty(PropertyName = "ventanillaSantiago")]
        public IEnumerable<ParametricasBdReferencia> VentanillaSantiago { get; set; }

        [JsonProperty(PropertyName = "ventanillaRegiones")]
        public IEnumerable<ParametricasBdReferencia> VentanillaRegiones { get; set; }

       
        [JsonProperty(PropertyName = "gruposPoliza")]
        public IEnumerable<GrupoFormularioDto> GruposPoliza { get; set; }
    }
}
