using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Cobranza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using System.Collections.Generic;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Cobranza;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Utilidades
{
    public class MapperEstructuraRiesgoCobranza
    {
        public static EstructuraRiesgoCobranza CrearListaRiesgo(IEnumerable<CobranzaRiesgoDtoMapper> listRiesgo, int id, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            EstructuraRiesgoCobranza ec = new EstructuraRiesgoCobranza();
            ec.IdCampo = id;
            if (null != listRiesgo)
            {
                ec.Valor = listRiesgo;
            }
            MensajeDto mensaje = EstructuraMensaje.BuscarMensajePorAtributo(id, listaMensajes);
            ec.EstadoCampo = mensaje.Estado;
            ec.ObservacionesCampo = mensaje.Observaciones;
            return ec;
        }
        public static IEnumerable<CobranzaRiesgoDtoMapper> ExtraerCobranzaRiesgo(CobranzaDto cobranzaDto)
        {
            IEnumerable<CobranzaRiesgoDtoMapper> valor = null;
            if (null != cobranzaDto)
            {
                valor = cobranzaDto.Riesgo.Valor;
            }
            return valor;
        }
    }
}