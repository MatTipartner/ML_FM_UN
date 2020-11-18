using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_TARIFA.RestClients
{
    public interface IMsTarifaClient
    {
        GetSettingDataRespuesta RespuestaCliente(GetSettingDataSolicitud soliRest);
    }
}