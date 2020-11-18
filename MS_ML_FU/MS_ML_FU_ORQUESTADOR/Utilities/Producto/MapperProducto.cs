using MS_ML_FU_DLL_DOMAIN.Domain.Constantes.BaseDatos;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Mensaje;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Producto;
using MS_ML_FU_DLL_DOMAIN.Domain.Utilidades;
using System.Collections.Generic;
using System.Linq;

namespace MS_ML_FU_ORQUESTADOR.Utilities.Producto
{
    public class MapperProducto
    {
        public static ProductoDto TransformarProductoDtoMapperEnDTO(IEnumerable<ProductoSaludDetalleDtoMapper> listSalud, IEnumerable<ProductoVidaApDetalleDtoMapper> listVidaAp,
            ProductoVidaApDtoMapper vidaAp, IEnumerable<CascadaDtoMapper> listCascada, IEnumerable<MensajeDtoMapper> listaMensajes) {            
            ProductoDto producto = new ProductoDto();
            producto.Freecover=  MapperEstructurasUtilidades.CrearCadenaDTO(vidaAp.FREECOVER, (int)AtributoPestanaParametrica.FREECOVER, listaMensajes);
            producto.CapitalMaximo = MapperEstructurasUtilidades.CrearDecimalDTO(vidaAp.CAPITALMAXINO, (int)AtributoPestanaParametrica.CAPITAL_MAXIMO, listaMensajes);
            producto.Id_VidaAp = MapperEstructurasUtilidades.CrearEnteroDTO(vidaAp.ID_PRODUCTO_VIDAAP, (int)AtributoPestanaParametrica.IDVIDAAP, listaMensajes);
            producto.Cumulo = MapperEstructurasUtilidades.CrearCadenaDTO(vidaAp.CUMULO, (int)AtributoPestanaParametrica.CUMULO, listaMensajes);
            producto.ListProductoSalud = MapperEstructurasProducto.CrearListaSalud(listSalud, (int)AtributoPestanaParametrica.LISTA_PRODUCTO_SALUD, listaMensajes);
            producto.ListProductoVidaAp = MapperEstructurasProducto.CrearListaVidaAp(listVidaAp, (int)AtributoPestanaParametrica.LISTA_PRODUCTO_VIDAAP, listaMensajes);
            producto.ListaCascada = MapperEstructurasProducto.CrearListaCascada(listCascada, (int)AtributoPestanaParametrica.LISTA_CASCADA, listaMensajes);
            return producto;
        }
   
        public static IEnumerable<ProductoSaludDetalleDtoMapper> TransformarListSaludDTOEnDtoMapper(ProductoDto productoDto)
        {
            return MapperEstructurasProducto.ExtraerListaSalud(productoDto);
        }

        public static IEnumerable<ProductoVidaApDetalleDtoMapper> TransformarListVidaApDTOEnDtoMapper(ProductoDto productoDto)
        {
            return MapperEstructurasProducto.ExtraerListaVidaAp(productoDto);
        }

        public static IEnumerable<CascadaDtoMapper> TransformarCascadaDTOEnDtoMapper(ProductoDto productoDto)
        {
            return MapperEstructurasProducto.ExtraerCascada(productoDto);
        }

        public static ProductoVidaApDtoMapper TransformarVidaApDTOEnDtoMapper(ProductoDto productoDto, int grupoFormualario)
        {
            ProductoVidaApDtoMapper vidaAp = new ProductoVidaApDtoMapper();
            vidaAp.ID_PRODUCTO_VIDAAP = MapperEstructurasUtilidades.ExtraerEntero(productoDto.Id_VidaAp)?? 0;
            vidaAp.FREECOVER = MapperEstructurasUtilidades.ExtraerCadena(productoDto.Freecover);
            vidaAp.CAPITALMAXINO = MapperEstructurasUtilidades.ExtraerDecimal(productoDto.CapitalMaximo) ;
            vidaAp.CUMULO = MapperEstructurasUtilidades.ExtraerCadena(productoDto.Cumulo);
            vidaAp.ID_AGRUPACION = grupoFormualario;
            return vidaAp;
        }

        public static IEnumerable<ParametricasBdReferencia> TransformarAListadoCobertura(ProductoDto producto) {
            IEnumerable<ProductoVidaApDetalleDtoMapper> listProductoVidaAp = TransformarListVidaApDTOEnDtoMapper(producto);
            IEnumerable<ProductoSaludDetalleDtoMapper> listProductoSalud = TransformarListSaludDTOEnDtoMapper(producto); ;
            List<ParametricasBdReferencia> listaCobertura = new List<ParametricasBdReferencia>();
            ParametricasBdReferencia cobertura = null;
            if (listProductoVidaAp != null && listProductoVidaAp.Count() > 0) {
                foreach (var listaVidaAp in listProductoVidaAp)
                {
                    cobertura = new ParametricasBdReferencia();
                    cobertura.Id = listaVidaAp.ID_COBERTURA;
                    listaCobertura.Add(cobertura);
                }
            }
            if (listProductoSalud != null && listProductoSalud.Count() > 0)
            {
                foreach (var listaSalud in listProductoSalud)
                {
                    cobertura = new ParametricasBdReferencia();
                    cobertura.Id = listaSalud.ID_COBERTURA;
                    listaCobertura.Add(cobertura);
                }
            }
           
            return listaCobertura;
        }
    }
}