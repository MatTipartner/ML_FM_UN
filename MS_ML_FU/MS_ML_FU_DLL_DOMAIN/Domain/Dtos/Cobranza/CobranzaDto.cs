using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Cobranza;
using Newtonsoft.Json;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Cobranza
{
    public class CobranzaDto
    {
        [JsonProperty(PropertyName = "idCobranza")]
        public EstructuraEntera IdCobranza { get; set; }

        [JsonProperty(PropertyName = "tipoFacturacion")]
        public EstructuraEntera TipoFacturacion { get; set; }

        [JsonProperty(PropertyName = "periodicidad")]
        public EstructuraCadena Periodicidad { get; set; }

        [JsonProperty(PropertyName = "destinatarioCobranza")]
        public EstructuraEntera DestinatarioCobranza { get; set; }

        [JsonProperty(PropertyName = "calculoPrima")]
        public EstructuraEntera CalculoPrima { get; set; }

        [JsonProperty(PropertyName = "tipoProceso")]
        public EstructuraEntera TipoProceso { get; set; }

        [JsonProperty(PropertyName = "diaFrontera")]
        public EstructuraEntera DiaFrontera { get; set; }

        [JsonProperty(PropertyName = "hes")]
        public EstructuraCadena HES { get; set; }

        [JsonProperty(PropertyName = "contraPago")]
        public EstructuraCadena ContraPago { get; set; }

        [JsonProperty(PropertyName = "precobranza")]
        public EstructuraCadena Precobranza { get; set; }

        [JsonProperty(PropertyName = "autoCobranza")]
        public EstructuraCadena AutoCobranza { get; set; }
        
        [JsonProperty(PropertyName = "reportaFacturacion")]
        public EstructuraEntera ReportaFacturacion { get; set; }

        [JsonProperty(PropertyName = "contabilizacion")]
        public EstructuraEntera Contabilizacion { get; set; }

        [JsonProperty(PropertyName = "tipoCobro")]
        public EstructuraEntera TipoCobro { get; set; }

        [JsonProperty(PropertyName = "idCobranzaGrupo")]
        public EstructuraEntera IdCobranzaGrupo { get; set; }
        
        [JsonProperty(PropertyName = "contributoriedad")]
        public EstructuraCadena Contributoriedad { get; set; }

        [JsonProperty(PropertyName = "tipoContributoriedad")]
        public EstructuraEntera TipoContributoriedad { get; set; }

        [JsonProperty(PropertyName = "especialContributoriedad")]
        public EstructuraCadena EspecialContributoriedad { get; set; }

        [JsonProperty(PropertyName = "porcentajeContratante")]
        public EstructuraEntera PorcentajeContratante { get; set; }

        [JsonProperty(PropertyName = "porcentajeAsegurado")]
        public EstructuraEntera PorcentajeAsegurado { get; set; }

        [JsonProperty(PropertyName = "aQuienCobranza")]
        public EstructuraEntera AQuienCobranza { get; set; }

        [JsonProperty(PropertyName = "tipoFactura")]
        public EstructuraCadena TipoFactura { get; set; }

        [JsonProperty(PropertyName = "rutFactutacion")]
        public EstructuraEntera RutFactutacion { get; set; }

        [JsonProperty(PropertyName = "dvFacturacion")]
        public EstructuraCadena DvFacturacion { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")]
        public EstructuraEntera IdAgrupacion { get; set; }

        [JsonProperty(PropertyName = "riesgo")]
        public EstructuraRiesgoCobranza Riesgo { get; set; }
    }
}
