using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Utilidades
{
    public class MapperEstructurasUtilidades
    {
        public static String ExtraerCadena(EstructuraCadena campo)
        {
            if (TiposDeDatos.TIPO_DATO_CADENA.Equals(campo.TipoDato))
            {
                return campo.Valor;
            }
            return null;
        }

        public static Nullable<Int32> ExtraerEntero(EstructuraEntera campo)
        {
            Nullable<Int32> valor = null;
            if (TiposDeDatos.TIPO_DATO_ENTERO.Equals(campo.TipoDato))
            {
                valor = campo.Valor;
            }
            return valor;
        }

        public static Nullable<decimal> ExtraerDecimal(EstructuraDecimal campo)
        {
            Nullable<decimal> valor = null;
            if (TiposDeDatos.TIPO_DATO_DECIMAL.Equals(campo.TipoDato))
            {
                valor = campo.Valor;
            }
            return valor;
        }

        public static Nullable<DateTime> ExtraerFecha(EstructuraFecha campo)
        {
            Nullable<DateTime> valor = null;
            if (TiposDeDatos.TIPO_DATO_FECHA.Equals(campo.TipoDato))
            {
                valor = campo.Valor;
            }
            return valor;
        }

        public static IEnumerable<UbicacionGeograficaDtoMapper> ExtraerListaUbicacionDTO(EstructuraListaReferencia listaReferencia, int? nroPoliza)
        {
            List<UbicacionGeograficaDtoMapper> valor = new List<UbicacionGeograficaDtoMapper>();
            if (null != listaReferencia)
            {
                foreach (var lis in listaReferencia.Valor)
                {
                    UbicacionGeograficaDtoMapper elemento = new UbicacionGeograficaDtoMapper();                    
                    elemento.ID_UBICACIONGEOGRAFICA = lis.Id;
                    elemento.NOMBRE_UBICACIONGEOGRAFICA = lis.Descripcion;
                    elemento.NRO_POLIZA = nroPoliza;
                    valor.Add(elemento);
                }
            }            
            return valor;
        }

        public static EstructuraCadena CrearCadenaDTO(String cadena, int id, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            EstructuraCadena ec = new EstructuraCadena();
            if (cadena !=null) {
                ec.Valor = cadena.Trim();
                //ec.ValorEspejo = cadena.Trim();
            }
            else {
                ec.Valor = cadena;
                //ec.ValorEspejo =cadena;
            }            
            ec.IdCampo = id;
            MensajeDto mensaje = EstructuraMensaje.BuscarMensajePorAtributo(id, listaMensajes);
            ec.EstadoCampo = mensaje.Estado;
            ec.ObservacionesCampo = mensaje.Observaciones;
            return ec;
        }

        public static EstructuraEntera CrearEnteroDTO(Nullable<Int32> entero, int id, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            EstructuraEntera ec = new EstructuraEntera();
            ec.Valor = entero;
           // ec.ValorEspejo = entero;
            ec.IdCampo = id;
            MensajeDto mensaje  = EstructuraMensaje.BuscarMensajePorAtributo(id, listaMensajes);
            ec.EstadoCampo = mensaje.Estado;
            ec.ObservacionesCampo = mensaje.Observaciones;
            return ec;
        }

        public static EstructuraDecimal CrearDecimalDTO(Nullable<decimal> decimalIn, int id, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            EstructuraDecimal ec = new EstructuraDecimal();
            ec.Valor = decimalIn;
           // ec.ValorEspejo = decimalIn;
            ec.IdCampo = id;
            MensajeDto mensaje = EstructuraMensaje.BuscarMensajePorAtributo(id, listaMensajes);
            ec.EstadoCampo = mensaje.Estado;
            ec.ObservacionesCampo = mensaje.Observaciones;
            return ec;
        }

        public static EstructuraFecha CrearFechaDTO(Nullable<DateTime> datetime, int id, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            EstructuraFecha ec = new EstructuraFecha();
            ec.Valor = datetime;
            //ec.ValorEspejo = datetime;
            ec.IdCampo = id;
            MensajeDto mensaje = EstructuraMensaje.BuscarMensajePorAtributo(id, listaMensajes);
            ec.EstadoCampo = mensaje.Estado;
            ec.ObservacionesCampo = mensaje.Observaciones;
            return ec;
        }

        public static EstructuraListaReferencia CrearListaReferenciaDTO( int id, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            EstructuraListaReferencia ec = new EstructuraListaReferencia();
            ec.IdCampo = id;
            MensajeDto mensaje = EstructuraMensaje.BuscarMensajePorAtributo(id, listaMensajes);
            ec.EstadoCampo = mensaje.Estado;
            ec.ObservacionesCampo = mensaje.Observaciones;
            return ec;
        }

        public static void CrearElementoListaReferenciaDTO(EstructuraListaReferencia lista, Int32 id, String descripcion)
        {
            if(null != lista && null != descripcion)
            {
                ParametricasBdReferencia Elemento = new ParametricasBdReferencia()
                {
                    Id = id,
                    Descripcion = descripcion
                };
                lista.Valor.Add(Elemento);
                //lista.ValorEspejo.Add(Elemento);
            }
        }

      
    }
}
