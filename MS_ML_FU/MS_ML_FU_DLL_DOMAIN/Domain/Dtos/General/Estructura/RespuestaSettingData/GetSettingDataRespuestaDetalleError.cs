using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData
{
    public class GetSettingDataRespuestaDetalleError
    {
        [JsonProperty(PropertyName = "reason")] 
        public String Reason { get; set; }

        [JsonProperty(PropertyName = "fieldList")] 
        public List<ErrorField> FieldList { get; set; }
    }
}
