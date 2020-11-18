using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData
{
    public class GetSettingDataRespuestaError
    {
        [JsonProperty(PropertyName = "code")] 
        public int Code { get; set; }
        [JsonProperty(PropertyName = "message")]
        public String Message { get; set; }
        [JsonProperty(PropertyName = "MessageText")] 
        public String MessageText { get; set; }

        [JsonProperty(PropertyName = "errors")] 
        public List<GetSettingDataRespuestaDetalleError> Errors { get; set; }

    }
}
