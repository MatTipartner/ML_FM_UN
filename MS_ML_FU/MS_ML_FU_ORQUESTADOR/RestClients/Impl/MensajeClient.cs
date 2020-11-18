using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Utilidades.Serializacion;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using RestSharp;
using System.Collections.Generic;

namespace MS_ML_FU_ORQUESTADOR.RestClients.Impl
{
    public class MensajeClient: IMensajeClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();
        /*
         * Ver comentario en la clase JsonNetSerializer en DOMAIN
         */
        [System.Obsolete]
        public IEnumerable<MensajeDtoMapper> GetBdMensaje(int grupoPoliza, PestanaParametrica pestana)
        {
            var client = new RestClient(values.BaseUrlMsFUMensajes + FUControllers.CONTROLLER_MS_FU_MENSAJES + "/getMensajeFormulario/{grupoPoliza}/{pestana}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<IEnumerable<MensajeDtoMapper>>(new RestRequest().AddUrlSegment("grupoPoliza", grupoPoliza).AddUrlSegment("pestana", pestana));
            return response.Data;
        }
    }
}