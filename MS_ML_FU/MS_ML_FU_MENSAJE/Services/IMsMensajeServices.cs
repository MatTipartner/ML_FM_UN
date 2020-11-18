using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using System.Collections.Generic;

namespace MS_ML_FU_MENSAJE.Services
{
    public interface IMsMensajeServices
    {
        ICollection<MensajeDtoMapper> GetMensajeFormulario(int grupoPoliza, int pestana);
    }
}