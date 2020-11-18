using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza.Parametricas
{
   public  class ParametricaPolizaDetalle
    {
        [JsonProperty(PropertyName = "tipoAddiction")]
        public IEnumerable<ParametricasBdEstandar> TipoAddiction { get; set; }
      
        [JsonProperty(PropertyName = "tipoPoliza")] 
        public IEnumerable<ParametricasBdEstandar> TipoPoliza { get; set; }
        
        [JsonProperty(PropertyName = "tipoRiesgo")] 
        public IEnumerable<ParametricasBdEstandar> Riesgo { get; set; }
      
        [JsonProperty(PropertyName = "tipoCanalVenta")] 
        public IEnumerable<ParametricasBdEstandar> CanalVenta { get; set; }
       
        [JsonProperty(PropertyName = "tipoLineaNegocio")] 
        public IEnumerable<ParametricasBdEstandar> LineaNegocio { get; set; }
       
        [JsonProperty(PropertyName = "tipoMoneda")] 
        public IEnumerable<ParametricaServicioEstandar> Moneda { get; set; }
       
        [JsonProperty(PropertyName = "tipoSucursal")] 
        public IEnumerable<ParametricaServicioEstandar> Sucursal { get; set; }
       
        [JsonProperty(PropertyName = "tipoEstadoCobertura")] 
        public IEnumerable<ParametricaServicioEstandar> EstadoCobertura { get; set; }

        [JsonProperty(PropertyName = "gruposPoliza")]
        public IEnumerable<GrupoFormularioDto> GruposPoliza { get; set; }
    }
}
