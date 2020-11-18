using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_ORQUESTADOR.RestClients;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class MensajeService: IMensajeService
    {
        private IMensajeClient clientMensaje;
        public IEnumerable<MensajeDtoMapper> GetBdMensaje(int grupoPoliza, PestanaParametrica pestana)
        {
            return this.clientMensaje.GetBdMensaje( grupoPoliza,  pestana);
        }

        [Inject]
        public void SetApiParametro(IMensajeClient clientMensaje)
        {
            this.clientMensaje = clientMensaje;
        }
    }
}