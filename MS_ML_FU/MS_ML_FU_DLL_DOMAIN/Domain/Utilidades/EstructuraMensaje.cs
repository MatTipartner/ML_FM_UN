using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Mensaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Utilidades
{
    public class EstructuraMensaje
    {
        public static MensajeDto BuscarMensajePorAtributo(int id, IEnumerable<MensajeDtoMapper> listaMensajes) {
            MensajeDto mensaje = new MensajeDto();
            mensaje.Estado = "INICIAL";
            if (listaMensajes != null && listaMensajes.Count() > 0)
            {
                var l = listaMensajes.Where(x => x.ID_ATRIBUTOPESTANA == id);
                if (l.Count() > 0)
                {
                    mensaje.Estado = l.First().FUWEB_P_ESTADOATRIBUTO.NOMBRE;
                    mensaje.Observaciones = l.First().MENSAJE;
                }

            }
            return mensaje;
        }
    }
}