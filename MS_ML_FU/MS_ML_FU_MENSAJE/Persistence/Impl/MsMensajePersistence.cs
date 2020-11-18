
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_MENSAJE.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Core;
using MS_ML_FU_MENSAJE.Utilities;

namespace MS_ML_FU_MENSAJE.Persistence.Impl
{
    public class MsMensajePersistence: IMsMensajePersistence
    {
        public ICollection<MensajeDtoMapper> GetMensajePoliza (int grupoPoliza, int pestana)
        {
            ICollection< MensajeDtoMapper> mensajeMapeada = null;
            try
            {
                using (Entities db = new Entities())
                {
                    var datos = (from m in db.FUWEB_MENSAJES
                                 join a in db.FUWEB_P_ATRIBUTOPESTANA on m.ID_ATRIBUTOPESTANA equals a.ID_ATRIBUTOPESTANA  
                                 where m.ID_AGRUPACION == grupoPoliza && a.ID_PESTANA == pestana
                                 select m);


                    if (datos.Count() > 0)
                    {
                        mensajeMapeada = new List<MensajeDtoMapper>();
                        foreach (var list in datos) {
                            mensajeMapeada.Add(MapperWrapper.Mapper.Map<MensajeDtoMapper>(list));

                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return mensajeMapeada;
        }
    }
}