using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_MENSAJE.Persistence;
using Ninject;
using System.Collections.Generic;


namespace MS_ML_FU_MENSAJE.Services.Impl
{
    public class MsMensajeServices: IMsMensajeServices
    {
        private IMsMensajePersistence persistenceMensaje;


        public ICollection<MensajeDtoMapper> GetMensajeFormulario(int grupoPoliza, int pestana)
        {
            return this.persistenceMensaje.GetMensajePoliza(grupoPoliza, pestana);
        }

        [Inject]
        public void SetPersistenceConvenio(IMsMensajePersistence persistenceMensaje)
        {
            this.persistenceMensaje = persistenceMensaje;
        }
    }
}