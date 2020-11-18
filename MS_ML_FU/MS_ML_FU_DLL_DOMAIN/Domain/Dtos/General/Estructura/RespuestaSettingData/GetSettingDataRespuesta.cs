using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData
{
    public class GetSettingDataRespuesta
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }
       
        [JsonProperty(PropertyName = "message")]
        public String Message { get; set; }
        
        [JsonProperty(PropertyName = "settingsData")]
        public List<GetSettingDataRespuestaCuerpo> SettingsData { get; set; }
       
        [JsonProperty(PropertyName = "error")]
        public GetSettingDataRespuestaError Error { get; set; }

    }
}
