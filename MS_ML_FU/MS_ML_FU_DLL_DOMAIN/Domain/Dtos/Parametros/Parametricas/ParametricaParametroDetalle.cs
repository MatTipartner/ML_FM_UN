using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Parametros.Parametricas
{
    public class ParametricaParametroDetalle
    {
       
            [JsonProperty(PropertyName = "tipoDeducible")]
            public List<ParametricasBdEstandar> TipoDeducible { get; set; }

            [JsonProperty(PropertyName = "aquien")]
            public List<ParametricasBdEstandar> Aquien { get; set; }

            [JsonProperty(PropertyName = "grupoIsapre")]
            public List<ParametricasBdEstandar> GrupoIsapre { get; set; }

            [JsonProperty(PropertyName = "tipoProducto")]
            public List<ParametricasBdEstandar> TipoProducto { get; set; }

            [JsonProperty(PropertyName = "cobertura")]
            public List<ParametricasBdReferencia> cobertura { get; set; }

            [JsonProperty(PropertyName = "prestacionBasica")]
            public List<ParametricasBdReferencia> PrestacionBasica { get; set; }

            [JsonProperty(PropertyName = "prestadores")]
            public List<ParametricasBdEstandar> Prestadores { get; set; }

            [JsonProperty(PropertyName = "tipoComision")]
            public List<ParametricaServicioEstandar> TipoComision { get; set; }

            [JsonProperty(PropertyName = "nombreCorredor")]
            public List<ParametricaServicioEstandar> NombreCorredor { get; set; }

            [JsonProperty(PropertyName = "beneficiarios")]
            public List<ParametricaServicioEstandar> Beneficiarios { get; set; }

            [JsonProperty(PropertyName = "formaPago")]
            public List<ParametricaServicioEstandar> FormaPago { get; set; }

            [JsonProperty(PropertyName = "gruposPoliza")]
            public List<GrupoFormularioDto> GruposPoliza { get; set; }
    }
   
}
