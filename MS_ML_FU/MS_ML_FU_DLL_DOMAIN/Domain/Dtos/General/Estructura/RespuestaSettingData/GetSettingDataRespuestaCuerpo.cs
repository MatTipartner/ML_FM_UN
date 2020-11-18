using Newtonsoft.Json;
using System;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData
{
    public class GetSettingDataRespuestaCuerpo
    {
        [JsonProperty(PropertyName = "columnReturn1")]
        public String ColumnReturn1 { get; set; }
        
        [JsonProperty(PropertyName = "valueReturn1")]
        public String ValueReturn1 { get; set; }
       
        [JsonProperty(PropertyName = "columnReturn2")]
        public String ColumnReturn2 { get; set; }
                
        [JsonProperty(PropertyName = "valueReturn2")]
        public String ValueReturn2 { get; set; }
        
        [JsonProperty(PropertyName = "columnReturn3")]
        public String ColumnReturn3 { get; set; }
        
        [JsonProperty(PropertyName = "valueReturn3")]
        public String ValueReturn3 { get; set; }
        
        [JsonProperty(PropertyName = "columnReturn4")]
        public String ColumnReturn4 { get; set; }
        
        [JsonProperty(PropertyName = "valueReturn4")]
         public String ValueReturn4 { get; set; }
        
        [JsonProperty(PropertyName = "columnReturn5")]
        public String ColumnReturn5 { get; set; }
       
        [JsonProperty(PropertyName = "valueReturn5")]
        public String ValueReturn5 { get; set; }
        


    }
}

