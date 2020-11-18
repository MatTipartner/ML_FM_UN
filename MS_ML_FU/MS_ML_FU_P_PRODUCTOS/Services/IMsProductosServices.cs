using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System;
using System.Collections.Generic;


namespace MS_ML_FU_P_PRODUCTOS.Services
{
    public interface IMsProductosServices
    {
        IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio);

        IEnumerable<ParametricaServicioReferencia> RespuestaGetSettingDataRef(ServiciosParametrica servicio);

        IEnumerable<ParametricasBdEstandar> GetListaTablaEst(BaseDatosParametrica tabla);

        IEnumerable<ParametricasBdReferencia> GetListaTablaRef(BaseDatosParametrica tabla);

        IEnumerable<ParametricasBdEstandar> GetListaTablaPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario);

        IEnumerable<ParametricasBdReferencia> GetListaTablaReferenciaPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario);

        IEnumerable<ParametricasBdPrestacionParametrica> GetListaTablaPrestacionesPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario);

        IEnumerable<ProductoSaludDetalleDtoMapper> GetListaSalud(int GrupoFormulario);

        IEnumerable<ProductoVidaApDetalleDtoMapper> GetListaVidaAp(int GrupoFormulario);

        ProductoVidaApDtoMapper GetVidaAp(int GrupoFormulario);

        IEnumerable<CascadaDtoMapper> GetCascada(int GrupoFormulario);

        Boolean SetVidaAp(ProductoVidaApDtoMapper vidaAp, int grupoFormulario);

        Boolean SetListaSalud(IEnumerable<ProductoSaludDetalleDtoMapper> listaSalud, int grupoFormulario);

        Boolean SetListVidaAp(IEnumerable<ProductoVidaApDetalleDtoMapper> listaCVidaAp, int grupoFormulario);

        Boolean SetListaCascada(IEnumerable<CascadaDtoMapper> listaCascada, int grupoFormulario);
    }
}