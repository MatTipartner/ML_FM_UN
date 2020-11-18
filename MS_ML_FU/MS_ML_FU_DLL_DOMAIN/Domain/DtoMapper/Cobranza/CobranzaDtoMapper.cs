using Newtonsoft.Json;
using System;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza
{
    public class CobranzaDtoMapper
    {
        [JsonProperty(PropertyName = "idCobranza")]
        public int ID_COBRANZA { get; set; }

        [JsonProperty(PropertyName = "idTipoFacturacion")]
        public Nullable<int> ID_TIPOFACTURACION { get; set; }

        [JsonProperty(PropertyName = "siglaCobranza")] 
        public string SIGLA_COBROPRIMA { get; set; }

        [JsonProperty(PropertyName = "idDestinatarioCobranza")] 
        public Nullable<int> ID_DESTINATARIOCOBRANZA { get; set; }

        [JsonProperty(PropertyName = "idCalculoPrima")] 
        public Nullable<int> ID_CALCULOPRIMA { get; set; }

        [JsonProperty(PropertyName = "idTipoProcesiCobranza")] 
        public Nullable<int> ID_TIPOPROCESOCOBRANZA { get; set; }

        [JsonProperty(PropertyName = "diaFrontera")] 
        public Nullable<int> DIAFRONTERA { get; set; }

        [JsonProperty(PropertyName = "hes")] 
        public string HES { get; set; }

        [JsonProperty(PropertyName = "compraPago")] 
        public string CONTRAPAGO { get; set; }
        
        [JsonProperty(PropertyName = "precobranza")] 
        public string PRECOBRANZA { get; set; }

        [JsonProperty(PropertyName = "autoCobranza")] 
        public string AUTOCOBRANZA { get; set; }

        [JsonProperty(PropertyName = "idReporteFacturacion")] 
        public Nullable<int> ID_REPORTEFACTUACION { get; set; }

        [JsonProperty(PropertyName = "idContabilizacion")] 
        public Nullable<int> ID_CONTABILIZACION { get; set; }

        [JsonProperty(PropertyName = "idTipoCobro")] 
        public Nullable<int> ID_TIPOCOBRO { get; set; }

        [JsonProperty(PropertyName = "diaCobro")] 
        public Nullable<int> DIACOBRO { get; set; }

        [JsonProperty(PropertyName = "mesCobro")] 
        public Nullable<int> MESCOBRO { get; set; }

        [JsonProperty(PropertyName = "mesConversion")] 
        public Nullable<int> MESCONVERSION { get; set; }

        [JsonProperty(PropertyName = "diaConversion")] 
        public Nullable<int> DIACONVERSION { get; set; }

        [JsonProperty(PropertyName = "nroPoliza")] 
        public Nullable<int> NRO_POLIZA { get; set; }

        [JsonProperty(PropertyName = "calculoPrima")]
        public CalculoPrimaDtoMapper FUWEB_P_CALCULOPRIMA { get; set; }

        [JsonProperty(PropertyName = "destinatarioCobranza")] 
        public DestinatarioCobranzaDtoMapper FUWEB_P_DESTINATARIOCOBRANZA { get; set; }

        [JsonProperty(PropertyName = "tipoCobro")] 
        public TipoCobroDtoMapper FUWEB_P_TIPOCOBRO { get; set; }

        [JsonProperty(PropertyName = "tipoFacturacionCobranza")] 
        public TipoFactutacionCobranzaDtoMapper FUWEB_P_TIPOFACTURACIONCOBR { get; set; }
    }

}
