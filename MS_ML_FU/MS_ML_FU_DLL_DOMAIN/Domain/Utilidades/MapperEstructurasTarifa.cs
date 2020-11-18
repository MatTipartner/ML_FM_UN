using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Vista;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using System.Collections.Generic;
using System.Linq;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Utilidades
{
    public class MapperEstructurasTarifa
    {
        public static EstructuraTarifaCobertura CrearTarifaCobertura(IEnumerable<TarifaGrupoDto> tarifaCobertura, int id, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            EstructuraTarifaCobertura ec = new EstructuraTarifaCobertura();
            ec.IdCampo = id;
            if (null != tarifaCobertura)
            {
                ec.Valor = tarifaCobertura;
            }
            MensajeDto mensaje = EstructuraMensaje.BuscarMensajePorAtributo(id, listaMensajes);
            ec.EstadoCampo = mensaje.Estado;
            ec.ObservacionesCampo = mensaje.Observaciones;
            return ec;
        }


        public static IEnumerable<TarifaGrupoDto> ExtraerTariaCobertura(EstructuraTarifaCobertura tarifaGrupo)
        {
            IEnumerable<TarifaGrupoDto> valor = null;
            if (null != tarifaGrupo)
            {
                valor = tarifaGrupo.Valor.ToList();
            }
            return valor;
        }
    }
}
