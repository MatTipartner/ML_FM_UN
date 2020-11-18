using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.CondicionEspecial.Parametricas
{
    public class ParametricasCondEspecDetalle
    {
        [JsonProperty(PropertyName = "tipoDeducible")]
        public IEnumerable<ParametricasBdEstandar> TipoDeducible { get; set; }

        [JsonProperty(PropertyName = "cobertura")]
        public IEnumerable<ParametricasBdReferencia> Cobertura { get; set; }

        [JsonProperty(PropertyName = "grupo")]
        public IEnumerable<ParametricasBdEstandar> Grupo { get; set; }

        [JsonProperty(PropertyName = "gruposPoliza")]
        public IEnumerable<GrupoFormularioDto> GruposPoliza { get; set; }
    }
}
