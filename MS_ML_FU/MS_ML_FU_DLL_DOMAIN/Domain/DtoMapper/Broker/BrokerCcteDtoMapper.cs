using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Broker
{
    public class BrokerCcteDtoMapper
    {
        [JsonProperty(PropertyName = "idCtte")] 
        public int ID_CCTE { get; set; }

        [JsonProperty(PropertyName = "rutCcte")] 
        public int RUTCCTE { get; set; }

        [JsonProperty(PropertyName = "dvCcte")] 
        public string DVCCTE { get; set; }

        [JsonProperty(PropertyName = "nombreCcte")] 
        public string NOMBRECCTE { get; set; }

        [JsonProperty(PropertyName = "grupoEmpresas")] 
        public string GRUPOEMPRESAS { get; set; }

        [JsonProperty(PropertyName = "telefono")] 
        public Nullable<int> TELEFONO { get; set; }

        [JsonProperty(PropertyName = "direccion")] 
        public string DIRECCION { get; set; }

        [JsonProperty(PropertyName = "comuna")] 
        public string COMUNA { get; set; }

        [JsonProperty(PropertyName = "ciudad")] 
        public string CIUDAD { get; set; }

        [JsonProperty(PropertyName = "giro")]
        public string GIRO { get; set; }

        [JsonProperty(PropertyName = "nombreContacto")] 
        public string NOMBRE_CONTACTO { get; set; }

        [JsonProperty(PropertyName = "email")] 
        public string EMAIL { get; set; }

        [JsonProperty(PropertyName = "nombreMandante")] 
        public string NOMBRE_MANDANTE { get; set; }

        [JsonProperty(PropertyName = "rutMandante")] 
        public string RUT_MANDANTE { get; set; }

        [JsonProperty(PropertyName = "idTipoCcte")] 
        public int ID_TIPOCCTE { get; set; }

        [JsonProperty(PropertyName = "idAgrupacion")] 
        public int ID_AGRUPACION { get; set; }
    }
}
