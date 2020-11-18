using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;


namespace MS_ML_FU_MENU.RestClients
{
    public interface IMsMenuClient
    {
        GetSettingDataRespuesta RespuestaCliente(GetSettingDataSolicitud soliRest);
    }
}