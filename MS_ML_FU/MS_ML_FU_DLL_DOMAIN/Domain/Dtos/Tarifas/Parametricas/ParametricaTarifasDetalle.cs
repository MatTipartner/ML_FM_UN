using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Parametricas
{
    public class ParametricaTarifasDetalle
    {
        [JsonProperty(PropertyName = "defTributaria")]
        public IEnumerable<ParametricasBdEstandar> DefinicionTributaria { get; set; }

        [JsonProperty(PropertyName = "tipoProducto")]
        public IEnumerable<ParametricasBdEstandar> TipoProducto { get; set; }

        [JsonProperty(PropertyName = "cobertura")]
        public IEnumerable<ParametricasBdReferencia> Cobertura { get; set; }

        [JsonProperty(PropertyName = "cobroPrima")]
        public IEnumerable<ParametricaServicioEstandar> CobroPrima { get; set; }

        [JsonProperty(PropertyName = "relacion")]
        public IEnumerable<ParametricaServicioEstandar> Relacion { get; set; }

        [JsonProperty(PropertyName = "gruposPoliza")]
        public IEnumerable<GrupoFormularioDto> GruposPoliza { get; set; }
    }
}
