using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Broker.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Broker
{
    public class BrokerPestanaDto:PestanaPadre
    {
        [JsonProperty(PropertyName = "parametrica")]
        public ParametricasBrokerDetalle Parametrica { get; set; }

        [JsonProperty(PropertyName = "datosCarga")]
        public BrokerDto DatosCarga { get; set; }
    }
}
