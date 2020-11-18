using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using System.Collections.Generic;


namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface IMensajeService
    {
        IEnumerable<MensajeDtoMapper> GetBdMensaje(int grupoPoliza, PestanaParametrica pestana);
    }
}