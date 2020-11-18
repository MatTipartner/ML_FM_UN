using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Cobranza.Parametricas
{
    public class ParametricasCobranzaDetalle
    {
        [JsonProperty(PropertyName = "tipoCobro")]
        public IEnumerable<ParametricasBdEstandar> TipoCobro { get; set; }

        [JsonProperty(PropertyName = "calculoPrima")]
        public IEnumerable<ParametricasBdEstandar> CalculoPrima { get; set; }

        [JsonProperty(PropertyName = "destinatrioCobranza")]
        public IEnumerable<ParametricasBdEstandar> DestinatrioCobranza { get; set; }

        [JsonProperty(PropertyName = "aquien")]
        public IEnumerable<ParametricasBdEstandar> Aquien { get; set; }
 
        [JsonProperty(PropertyName = "tipoFacturacion")]
        public IEnumerable<ParametricasBdEstandar> TipoFacturacion { get; set; }

        [JsonProperty(PropertyName = "riesgoFacturacion")]
        public IEnumerable<ParametricasBdEstandar> RiesgoFacturacion { get; set; }

        [JsonProperty(PropertyName = "tipoContributoriedad")]
        public IEnumerable<ParametricasBdEstandar> TipoContributoriedad { get; set; }

        [JsonProperty(PropertyName = "periodicidad")]
        public IEnumerable<ParametricaServicioEstandar> Periodicidad { get; set; }

        [JsonProperty(PropertyName = "reporteFacturacion")]
        public IEnumerable<ParametricaServicioEstandar> ReporteFacturacion { get; set; }
        
        [JsonProperty(PropertyName = "contabilizacion")]
        public IEnumerable<ParametricaServicioEstandar> Contabilizacion { get; set; }
        
        [JsonProperty(PropertyName = "procesoCobranza")]
        public IEnumerable<ParametricaServicioEstandar> ProcesoCobranza { get; set; }
        
        [JsonProperty(PropertyName = "tipoFactura")]
        public IEnumerable<ParametricaServicioEstandar> TipoFactura { get; set; }

        [JsonProperty(PropertyName = "gruposPoliza")]
        public IEnumerable<GrupoFormularioDto> GruposPoliza { get; set; }

        [JsonProperty(PropertyName = "infoFacturacion")]
        public IEnumerable<ParametricasInfoFacturacion> InfoFacturacion { get; set; }
    }
}
