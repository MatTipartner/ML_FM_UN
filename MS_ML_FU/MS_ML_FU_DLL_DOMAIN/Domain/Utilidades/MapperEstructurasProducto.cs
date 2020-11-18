using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Utilidades
{
    public class MapperEstructurasProducto
    {
        public static EstructuraListaProductoSalud CrearListaSalud(IEnumerable<ProductoSaludDetalleDtoMapper> listSalud, int id, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            EstructuraListaProductoSalud ec = new EstructuraListaProductoSalud();
            ec.IdCampo = id;
            if (null != listSalud)
            {
                ec.Valor=listSalud.ToList();
            }
            MensajeDto mensaje = EstructuraMensaje.BuscarMensajePorAtributo(id, listaMensajes);
            ec.EstadoCampo = mensaje.Estado;
            ec.ObservacionesCampo = mensaje.Observaciones;
            return ec;
        }

        public static EstructuraListaProductoVidaAp CrearListaVidaAp(IEnumerable<ProductoVidaApDetalleDtoMapper> listSVidaAp, int id, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            EstructuraListaProductoVidaAp ec = new EstructuraListaProductoVidaAp();
            ec.IdCampo = id;
            if (null != listSVidaAp)
            {
                ec.Valor = listSVidaAp.ToList();
            }
            MensajeDto mensaje = EstructuraMensaje.BuscarMensajePorAtributo(id, listaMensajes);
            ec.EstadoCampo = mensaje.Estado;
            ec.ObservacionesCampo = mensaje.Observaciones;
            return ec;
        }

        public static EstructuraCascada CrearListaCascada(IEnumerable<CascadaDtoMapper> listCascada, int id, IEnumerable<MensajeDtoMapper> listaMensajes)
        {
            EstructuraCascada ec = new EstructuraCascada();
            ec.IdCampo = id;
            if (null != listCascada)
            {
                ec.Valor = listCascada.ToList();
            }
            MensajeDto mensaje = EstructuraMensaje.BuscarMensajePorAtributo(id, listaMensajes);
            ec.EstadoCampo = mensaje.Estado;
            ec.ObservacionesCampo = mensaje.Observaciones;
            return ec;
        }

        public static IEnumerable<ProductoVidaApDetalleDtoMapper> ExtraerListaVidaAp(ProductoDto productoDto)
        {
            IEnumerable<ProductoVidaApDetalleDtoMapper> valor = null;
            if (null != productoDto)
            {
                valor = productoDto.ListProductoVidaAp.Valor;
            }
            return valor;
        }
        public static IEnumerable<ProductoSaludDetalleDtoMapper> ExtraerListaSalud(ProductoDto productoDto)
        {
            IEnumerable<ProductoSaludDetalleDtoMapper> valor = null;
            if (null != productoDto)
            {
                valor = productoDto.ListProductoSalud.Valor;
            }
            return valor;
        }
        public static IEnumerable<CascadaDtoMapper> ExtraerCascada(ProductoDto productoDto)
        {
            IEnumerable<CascadaDtoMapper> valor = null;
            if (null != productoDto)
            {
                valor = productoDto.ListaCascada.Valor;
            }
            return valor;
        }

    }
}
