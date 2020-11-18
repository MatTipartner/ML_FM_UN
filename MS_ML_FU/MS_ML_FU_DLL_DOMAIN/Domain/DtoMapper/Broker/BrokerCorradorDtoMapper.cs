using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Broker
{
    public class BrokerCorradorDtoMapper
    {
        [JsonProperty(PropertyName = "idCorredor")] 
        public int ID_CORREDOR { get; set; }
        
        [JsonProperty(PropertyName = "rutCorredor")]
        public int RUT_CORREDOR { get; set; }

        [JsonProperty(PropertyName = "dvCorredor")] 
        public string DV_CORREDOR { get; set; }

        [JsonProperty(PropertyName = "nombreCorredor")] 
        public string NOMBRE_CORREDOR { get; set; }

        [JsonProperty(PropertyName = "telefono")] 
        public Nullable<int> TELEFONO { get; set; }

        [JsonProperty(PropertyName = "giro")] 
        public string GIRO { get; set; }
        
        [JsonProperty(PropertyName = "direccion")] 
        public string DIRECCION { get; set; }

        [JsonProperty(PropertyName = "ciudad")] 
        public string CIUDAD { get; set; }

        [JsonProperty(PropertyName = "comuna")] 
        public string COMUNA { get; set; }

        [JsonProperty(PropertyName = "polizaGarantiaVigente")] 
        public string POLIZA_GARANTIA_VIGENTE { get; set; }

        [JsonProperty(PropertyName = "nombreContacto")] 
        public string NOMBRE_CONTACTO { get; set; }

        [JsonProperty(PropertyName = "email")] 
        public string EMAIL { get; set; }

        [JsonProperty(PropertyName = "formaPago")] 
        public Nullable<int> FORMA_PAGO { get; set; }

        [JsonProperty(PropertyName = "tipoCuneta")] 
        public Nullable<int> TIPO_CUENTA { get; set; }

        [JsonProperty(PropertyName = "nroCuenta")] 
        public Nullable<int> NRO_CUENTA { get; set; }

        [JsonProperty(PropertyName = "banco")] 
        public Nullable<int> BANCO { get; set; }
        
        [JsonProperty(PropertyName = "idHolding")] 
        public int ID_HOLDING { get; set; }

        [JsonProperty(PropertyName = "idAdministrador")] 
        public string ID_ADMINISTRADOR { get; set; }

        [JsonProperty(PropertyName = "idEjecutivoCobranza")] 
        public string ID_EJECUTIVO_COBRANZA { get; set; }

        [JsonProperty(PropertyName = "idEjecutivoComercial")] 
        public string ID_EJECUTIVO_COMERCIAL { get; set; }

        [JsonProperty(PropertyName = "idEjecutivoMovimiento")] 
        public string ID_EJECUTIVO_MOVIMIENTO { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")] 
        public int ID_AGRUPACION { get; set; }
    }
}
