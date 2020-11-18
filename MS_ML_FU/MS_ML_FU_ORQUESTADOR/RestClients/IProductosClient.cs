using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface IProductosClient
    {
        IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio);

        IEnumerable<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio);

        IEnumerable<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla);

        IEnumerable<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla);

        ProductoVidaApDtoMapper GetProductoVidaAp(int GrupoFormulario);

        IEnumerable<CascadaDtoMapper> GetCascada(int GrupoFormulario);

        IEnumerable<ProductoVidaApDetalleDtoMapper> GetProductoListaVidaAp(int GrupoFormulario);

        IEnumerable<ProductoSaludDetalleDtoMapper> GetProductoListaSalud(int GrupoFormulario);

        IEnumerable<ParametricasBdReferencia> GetCoberturaPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario);

        IEnumerable<ParametricasBdEstandar> GetTipoProductoPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario);

        Boolean SetVidaAp(ProductoVidaApDtoMapper SetVidaAp, int grupoFormulario);

        Boolean SetListaCascada(IEnumerable<CascadaDtoMapper> cascada, int grupoFormulario);

        Boolean SetListaSalud(IEnumerable<ProductoSaludDetalleDtoMapper> listaSalud, int grupoFormulario);

        Boolean SetListaVidaAps(IEnumerable<ProductoVidaApDetalleDtoMapper> listaVidaAp, int grupoFormulario);
    }
}