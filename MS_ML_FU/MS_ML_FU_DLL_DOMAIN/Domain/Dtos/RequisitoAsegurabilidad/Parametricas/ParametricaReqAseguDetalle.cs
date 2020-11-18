using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.RequisitoAsegurabilidad.Parametricas
{
    public class ParametricaReqAseguDetalle
    {
        [JsonProperty(PropertyName = "exclusionAsegurabilidad")]
        public List<ParametricasBdEstandar> ExclusionAsegurabilidad { get; set; }

        [JsonProperty(PropertyName = "tipoProductos")]
        public List<ParametricasBdEstandar> TipoProducto { get; set; }

        [JsonProperty(PropertyName = "Cobertura")]
        public List<ParametricasBdReferencia> Cobertura { get; set; }

        [JsonProperty(PropertyName = "relacion")]
        public List<ParametricaServicioEstandar> Relacion { get; set; }

        [JsonProperty(PropertyName = "gruposPoliza")]
        public List<GrupoFormularioDto> GruposPoliza { get; set; }
    }
}
