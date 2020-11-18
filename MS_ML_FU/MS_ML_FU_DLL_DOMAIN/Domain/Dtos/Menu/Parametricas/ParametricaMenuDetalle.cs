using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Menu.Parametricas
{
    public class ParametricaMenuDetalle
    {
        [JsonProperty(PropertyName = "ubicacion")]
        public List<ParametricaServicioEstandar> Ubicacion { get; set; }

        [JsonProperty(PropertyName = "lugarDespacho")]
        public List<ParametricaServicioEstandar> LugarDespacho { get; set; }

        [JsonProperty(PropertyName = "tipoFormulario")]
        public List<ParametricasBdEstandar> TipoFormulario { get; set; }

        [JsonProperty(PropertyName = "tipoFormularioDetalle")]
        public List<ParametricasBdReferencia> TipoFormularioDetalle { get; set; }
      }
}
