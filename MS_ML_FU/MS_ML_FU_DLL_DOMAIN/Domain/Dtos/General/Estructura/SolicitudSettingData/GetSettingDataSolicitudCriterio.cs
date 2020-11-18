using Newtonsoft.Json;
using System;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData
{
    public class GetSettingDataSolicitudCriterio
    {
        [JsonProperty(PropertyName = "relationOperate")]
        public String RelationOperate { get; set; }
        [JsonProperty(PropertyName = "field1")]
        public String Field1 { get; set; }
        [JsonProperty(PropertyName = "compareOperate")]
        public String CompareOperate { get; set; }
        [JsonProperty(PropertyName = "dataType")]
        public String DataType { get; set; }
        [JsonProperty(PropertyName = "valueField2")]
        public String ValueField2 { get; set; }

        public GetSettingDataSolicitudCriterio() {

            RelationOperate = "";
            Field1 = "";
            CompareOperate = "";
            DataType = "";
            ValueField2 = "";
        }
    }
}
