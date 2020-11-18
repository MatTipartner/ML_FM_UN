using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_IMED.RestClients
{
    public interface IMsImedClient
    {
        GetSettingDataRespuesta RespuestaCliente(GetSettingDataSolicitud soliRest);
    }
}