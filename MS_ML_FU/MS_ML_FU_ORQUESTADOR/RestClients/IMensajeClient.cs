using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using System.Collections.Generic;


namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface IMensajeClient
    {
        IEnumerable<MensajeDtoMapper> GetBdMensaje(int grupoPoliza, PestanaParametrica pestana);
    }
}