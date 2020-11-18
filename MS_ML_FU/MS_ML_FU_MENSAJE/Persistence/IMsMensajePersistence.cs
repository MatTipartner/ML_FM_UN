

using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using System.Collections.Generic;

namespace MS_ML_FU_MENSAJE.Persistence
{
    public interface IMsMensajePersistence
    {
        ICollection<MensajeDtoMapper> GetMensajePoliza(int grupoPoliza, int pestana);
    }
}