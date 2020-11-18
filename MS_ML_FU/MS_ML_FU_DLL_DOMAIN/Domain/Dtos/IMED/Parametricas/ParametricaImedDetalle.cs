using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.IMED.Parametricas
{
    public class ParametricaImedDetalle
    {
        [JsonProperty(PropertyName = "tipoImed")]
        public IEnumerable<ParametricasBdEstandar> TipoImed { get; set; }

        [JsonProperty(PropertyName = "frecuencia")]
        public IEnumerable<ParametricasBdEstandar> Frecuencia { get; set; }

        [JsonProperty(PropertyName = "cobertura")]
        public IEnumerable<ParametricasBdReferencia> Cobertura { get; set; }

        [JsonProperty(PropertyName = "prestacionGenerica")]
        public IEnumerable<ParametricasBdReferencia> PrestacionGenerica { get; set; }

        [JsonProperty(PropertyName = "subgrupo")]
        public IEnumerable<ParametricasBdEstandar> Subgrupo { get; set; }

        [JsonProperty(PropertyName = "prestaciones")]
        public IEnumerable<ParametricasBdPrestacionParametrica> Prestaciones { get; set; }

        [JsonProperty(PropertyName = "prestadoresFu")]
        public IEnumerable<ParametricasBdEstandar> PrestadoresFu { get; set; }

        [JsonProperty(PropertyName = "prestadoresSacs")]
        public IEnumerable<ParametricasBdReferencia> PrestadoresSacs { get; set; }

        [JsonProperty(PropertyName = "topeMonto")]
        public IEnumerable<ParametricaServicioEstandar> TopeMonto { get; set; }

        [JsonProperty(PropertyName = "gruposPoliza")]
        public IEnumerable<GrupoFormularioDto> GruposPoliza { get; set; }
    }
}
