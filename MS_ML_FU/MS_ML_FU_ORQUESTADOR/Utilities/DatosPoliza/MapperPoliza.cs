using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Domain.Utilidades;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using System.Collections.Generic;

namespace MS_ML_FU_ORQUESTADOR.Utilities.DatosPoliza
{
    public class MapperPoliza
    {
        public static DatosPolizaDto TransformarPolizaDtoMapperEnDTO(DatosPolizaDtoMapper polizaMapper, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            DatosPolizaDto dto = new DatosPolizaDto();
            dto.NroFormulario = MapperEstructurasUtilidades.CrearEnteroDTO(polizaMapper.NRO_POLIZA, (int)AtributoPestanaParametrica.NO_APLICA, null);
            dto.NroBizFlow = MapperEstructurasUtilidades.CrearEnteroDTO(polizaMapper.NRO_BIZFLOW, (int)AtributoPestanaParametrica.NO_APLICA, null);
            dto.TipoPoliza = MapperEstructurasUtilidades.CrearEnteroDTO(polizaMapper.ID_TIPOPOLIZA, (int)AtributoPestanaParametrica.TIPO_POLIZA, listaMensajes);
            dto.VigenciaInicial = MapperEstructurasUtilidades.CrearFechaDTO(polizaMapper.VIGENTE_INICIO, (int)AtributoPestanaParametrica.VIGENCIA_INICIAL, listaMensajes);
            dto.VigenciaFinal = MapperEstructurasUtilidades.CrearFechaDTO(polizaMapper.VIGENTE_FINAL, (int)AtributoPestanaParametrica.VIGENCIA_FINAL, listaMensajes);
            dto.Riesgo = MapperEstructurasUtilidades.CrearEnteroDTO(polizaMapper.ID_RIESGO, (int)AtributoPestanaParametrica.RIESGO, listaMensajes);
            dto.Moneda = MapperEstructurasUtilidades.CrearCadenaDTO(polizaMapper.SIGLA_MONEDA, (int)AtributoPestanaParametrica.MONEDA, listaMensajes);
            dto.Sucursal = MapperEstructurasUtilidades.CrearEnteroDTO(polizaMapper.ID_SUCURSAL, (int)AtributoPestanaParametrica.SUCURSAL, listaMensajes);
            dto.EstadoCobertura = MapperEstructurasUtilidades.CrearEnteroDTO(polizaMapper.ID_ESTADOCOBERTURA, (int)AtributoPestanaParametrica.ESTADO_COBERTURA, listaMensajes);
            dto.CanalVenta = MapperEstructurasUtilidades.CrearEnteroDTO(polizaMapper.ID_CANALVENTA, (int)AtributoPestanaParametrica.CANAL_VENTA, listaMensajes);
            dto.LineaNegocio = MapperEstructurasUtilidades.CrearEnteroDTO(polizaMapper.ID_LINEANEGOCIO, (int)AtributoPestanaParametrica.LINEA_NEGOCIO, listaMensajes);
            dto.NuevoNegocio = MapperEstructurasUtilidades.CrearCadenaDTO(polizaMapper.NUEVONEGOCIO, (int)AtributoPestanaParametrica.NUEVO_NEGOCIO, listaMensajes);
            dto.Addition = MapperEstructurasUtilidades.CrearCadenaDTO(polizaMapper.ADDITION, (int)AtributoPestanaParametrica.ADDITION, listaMensajes);
            dto.TipoAddition = MapperEstructurasUtilidades.CrearEnteroDTO(polizaMapper.ID_TIPOADDITION, (int)AtributoPestanaParametrica.TIPO_ADDITION, listaMensajes);
            dto.Comentario = MapperEstructurasUtilidades.CrearCadenaDTO(polizaMapper.COMENTARIO, (int)AtributoPestanaParametrica.COMENTARIO, listaMensajes);
            dto.IdEstadoBizFlow = MapperEstructurasUtilidades.CrearEnteroDTO(polizaMapper.ID_ESTADOBISFLOW, (int)AtributoPestanaParametrica.NO_APLICA, null);
            dto.IdEstadoFormualrio = MapperEstructurasUtilidades.CrearEnteroDTO(polizaMapper.ID_ESTADOFORMULARIO, (int)AtributoPestanaParametrica.NO_APLICA, null);
            dto.IdFormularioDetalle = MapperEstructurasUtilidades.CrearEnteroDTO(polizaMapper.ID_FORMULARIODETALLE, (int)AtributoPestanaParametrica.NO_APLICA, null);
            dto.NroPolizaSacs = MapperEstructurasUtilidades.CrearDecimalDTO(polizaMapper.ID_TIPOADDITION, (int)AtributoPestanaParametrica.NO_APLICA, null);
            dto.UbicacionesGeograficas = MapperEstructurasUtilidades.CrearListaReferenciaDTO((int)AtributoPestanaParametrica.AGRUPACION_UBICACION, listaMensajes);
            foreach (var ubicacionGeografica in polizaMapper.FUWEB_UBICACION_GEOGRAFICA)
            {
                MapperEstructurasUtilidades.CrearElementoListaReferenciaDTO(
                    dto.UbicacionesGeograficas,
                    ubicacionGeografica.ID_UBICACIONGEOGRAFICA,
                    ubicacionGeografica.NOMBRE_UBICACIONGEOGRAFICA);
            }
            return dto;
        }


        public static DatosPolizaDtoMapper TransformarPolizaDTOEnDtoMapper(DatosPolizaDto dto)
        {
            DatosPolizaDtoMapper entity = new DatosPolizaDtoMapper();
            entity.NRO_POLIZA = MapperEstructurasUtilidades.ExtraerEntero(dto.NroFormulario);
            entity.NRO_BIZFLOW = MapperEstructurasUtilidades.ExtraerEntero(dto.NroBizFlow);
            entity.ID_TIPOPOLIZA = MapperEstructurasUtilidades.ExtraerEntero(dto.TipoPoliza);
            entity.VIGENTE_INICIO = MapperEstructurasUtilidades.ExtraerFecha(dto.VigenciaInicial);
            entity.VIGENTE_FINAL = MapperEstructurasUtilidades.ExtraerFecha(dto.VigenciaFinal);
            entity.ID_RIESGO = MapperEstructurasUtilidades.ExtraerEntero(dto.Riesgo);
            entity.SIGLA_MONEDA = MapperEstructurasUtilidades.ExtraerCadena(dto.Moneda);
            entity.ID_SUCURSAL = MapperEstructurasUtilidades.ExtraerEntero(dto.Sucursal);
            entity.ID_ESTADOCOBERTURA = MapperEstructurasUtilidades.ExtraerEntero(dto.EstadoCobertura);
            entity.ID_CANALVENTA = MapperEstructurasUtilidades.ExtraerEntero(dto.CanalVenta);
            entity.ID_LINEANEGOCIO = MapperEstructurasUtilidades.ExtraerEntero(dto.LineaNegocio);
            entity.NUEVONEGOCIO = MapperEstructurasUtilidades.ExtraerCadena(dto.NuevoNegocio);
            entity.ADDITION = MapperEstructurasUtilidades.ExtraerCadena(dto.Addition);
            entity.ID_TIPOADDITION = MapperEstructurasUtilidades.ExtraerEntero(dto.TipoAddition);
            entity.COMENTARIO = MapperEstructurasUtilidades.ExtraerCadena(dto.Comentario);
            entity.ID_ESTADOBISFLOW = MapperEstructurasUtilidades.ExtraerEntero(dto.IdEstadoBizFlow);
            entity.ID_FORMULARIODETALLE = MapperEstructurasUtilidades.ExtraerEntero(dto.IdFormularioDetalle);
            entity.ID_ESTADOFORMULARIO = MapperEstructurasUtilidades.ExtraerEntero(dto.IdEstadoFormualrio);
            entity.NRO_POLIZA_SACS = MapperEstructurasUtilidades.ExtraerDecimal(dto.NroPolizaSacs);
            entity.FUWEB_UBICACION_GEOGRAFICA = MapperEstructurasUtilidades.ExtraerListaUbicacionDTO(dto.UbicacionesGeograficas, entity.NRO_POLIZA);            
            return entity;
        }
    }
}