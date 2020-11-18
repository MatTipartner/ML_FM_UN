using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.PlanGrilla.Parametricas
{
    public class ParametricasPlanGrillaDetalle
    {
        [JsonProperty(PropertyName = "tipoProducto")]
        public IEnumerable<ParametricasBdEstandar> TipoProducto { get; set; }

        [JsonProperty(PropertyName = "cobertura")]
        public IEnumerable<ParametricasBdReferencia> Cobertura { get; set; }

        [JsonProperty(PropertyName = "prestacionBasica")]
        public IEnumerable<ParametricasBdReferencia> PrestacionBasica { get; set; }

        [JsonProperty(PropertyName = "prestacion")]
        public IEnumerable<ParametricasBdPrestacionParametrica> Prestacion { get; set; }
               
        [JsonProperty(PropertyName = "nivel")]
        public IEnumerable<ParametricaServicioEstandar> Nivel { get; set; }

        [JsonProperty(PropertyName = "grupoPrestador")]
        public IEnumerable<ParametricasBdEstandar> GrupoPrestador { get; set; }

        [JsonProperty(PropertyName = "grupoPrestadorSacs")]
        public IEnumerable<ParametricasBdReferencia> GrupoPrestadorSacs { get; set; }

        [JsonProperty(PropertyName = "isapre")]
        public IEnumerable<ParametricaServicioEstandar> Isapre { get; set; }

        [JsonProperty(PropertyName = "gruposPoliza")]
        public IEnumerable<GrupoFormularioDto> GruposPoliza { get; set; }
    }
}
