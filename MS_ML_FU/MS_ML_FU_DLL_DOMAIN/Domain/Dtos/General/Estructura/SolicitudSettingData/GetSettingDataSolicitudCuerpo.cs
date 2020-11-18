using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData
{
    public class GetSettingDataSolicitudCuerpo
    {
        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }
        [JsonProperty(PropertyName = "criteria")]
        public List<GetSettingDataSolicitudCriterio> Criteria { get; set; }
        
    }
}
