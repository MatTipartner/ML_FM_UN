using Newtonsoft.Json;


namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData
{
    public class GetSettingDataSolicitud
    {
        [JsonProperty(PropertyName = "setting")]

        public GetSettingDataSolicitudCuerpo Setting { get; set; }
    }
}
