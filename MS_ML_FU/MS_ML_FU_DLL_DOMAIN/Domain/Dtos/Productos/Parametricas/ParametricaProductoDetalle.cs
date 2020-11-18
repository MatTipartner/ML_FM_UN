using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos.Parametricas
{
    public class ParametricaProductoDetalle
    {
        [JsonProperty(PropertyName = "tipoProducto")]
        public IEnumerable<ParametricasBdEstandar> TipoProducto { get; set; }

        [JsonProperty(PropertyName = "cobertura")]
        public IEnumerable<ParametricasBdReferencia> Cobertura { get; set; }

        [JsonProperty(PropertyName = "PolCad")]
        public IEnumerable<ParametricaServicioReferencia> PolCal { get; set; }

        [JsonProperty(PropertyName = "relacion")]
        public IEnumerable<ParametricaServicioEstandar> Relacion { get; set; }

        [JsonProperty(PropertyName = "sexo")]
        public IEnumerable<ParametricaServicioEstandar> Sexo { get; set; }

        [JsonProperty(PropertyName = "gruposPoliza")]
        public IEnumerable<GrupoFormularioDto> GruposPoliza { get; set; }
    }
}
