using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;


namespace EJEMPLO.RestClients
{
    public interface IMsEjemploRest
    {
        GetSettingDataRespuesta respuesta(GetSettingDataSolicitud soliRest);
    }
}