using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_PRODUCTOS.Persistence
{
    public interface IMsProductosPersistence
    {
        IEnumerable<ParametricasBdEstandar> GetListaTipoProducto();

        IEnumerable<ParametricasBdEstandar> GetListaTipoProductoPorGrupo(int GrupoFormulario);

        IEnumerable<ParametricasBdReferencia> GetListaCoberturaPorGrupo(int GrupoFormulario);

        IEnumerable<ParametricasBdReferencia> GetListaCoberturaPrestacionBasicaPorGrupo(int GrupoFormulario);

        IEnumerable<ParametricasBdReferencia> GetListaCoberturaPrestacionGenericaPorGrupo(int GrupoFormulario);

        IEnumerable<ParametricasBdPrestacionParametrica> GetListaCoberturaPrestacionesPorGrupo(int GrupoFormulario);

        IEnumerable<ParametricasBdReferencia> GetListaCobertura();

        IEnumerable<ProductoSaludDetalleDtoMapper> GetListaProductoSalud(int GrupoPoliza);

        IEnumerable<ProductoVidaApDetalleDtoMapper> GetListaProductoVidaAp(int GrupoPoliza);

        ProductoVidaApDtoMapper GetProductoVidaAp(int GrupoPoliza);

        IEnumerable<ParametricasBdEstandar> GetListaSubGrupo();

        IEnumerable<CascadaDtoMapper> GetCascada(int GrupoPoliza);

        Boolean SetVidaAp(ProductoVidaApDtoMapper vidaAp);

        Boolean SetListaCascada(IEnumerable<CascadaDtoMapper> listacascada);

        Boolean SetListaSalud(IEnumerable<ProductoSaludDetalleDtoMapper> listaSalud);

        Boolean SetListaVidaAp(IEnumerable<ProductoVidaApDetalleDtoMapper> listaVidaAp);

        Boolean SetDeleteVidaAp(ProductoVidaApDtoMapper productovidaAp);

        Boolean SetDeleteCascada(IEnumerable<CascadaDtoMapper> liscaCascada);

        Boolean SetDeleteListaVidaAp(IEnumerable<ProductoVidaApDetalleDtoMapper> listaProductoVidaAp);

        Boolean SetDeleteListaSalud(IEnumerable<ProductoSaludDetalleDtoMapper> listaProductoSalud);

        IEnumerable<CoberturaDtoMapper> GetCOberturaMapper();

    }
}