
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_PRODUCTOS.Persistence;
using MS_ML_FU_P_PRODUCTOS.RestClients;
using MS_ML_FU_P_PRODUCTOS.Utilities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_PRODUCTOS.Services.Impl
{
    public class MsProductosServices : IMsProductosServices
    {
        private IMsProductosPersistence persistenceProductos;
        private IMsProductosClient clientProductos;
        
        public IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio)
        {
            GetSettingDataSolicitud soliRest;
            soliRest = new GetSettingDataSolicitud();
            soliRest.Setting = new GetSettingDataSolicitudCuerpo();
            soliRest.Setting.Id = ((int)servicio).ToString();
            soliRest.Setting.Criteria = new List<GetSettingDataSolicitudCriterio>();
            GetSettingDataSolicitudCriterio criteria = new GetSettingDataSolicitudCriterio();
            soliRest.Setting.Criteria.Add(criteria);
            GetSettingDataRespuesta getRespuesta = this.clientProductos.RespuestaCliente(soliRest);
            IEnumerable<ParametricaServicioEstandar> listaParamEstandar = null;
            if (getRespuesta.Code == 0 && getRespuesta.SettingsData != null)
            {            
                listaParamEstandar = MapperParametricas.CrearListaParametroEstandarServicio(getRespuesta);
            }            
            return listaParamEstandar;
        }


        public IEnumerable<ParametricaServicioReferencia> RespuestaGetSettingDataRef(ServiciosParametrica servicio)
        {
            GetSettingDataSolicitud soliRest;
            soliRest = new GetSettingDataSolicitud();
            soliRest.Setting = new GetSettingDataSolicitudCuerpo();
            soliRest.Setting.Id = ((int)servicio).ToString();
            soliRest.Setting.Criteria = new List<GetSettingDataSolicitudCriterio>();
            GetSettingDataSolicitudCriterio criteria = new GetSettingDataSolicitudCriterio();
            soliRest.Setting.Criteria.Add(criteria);
            GetSettingDataRespuesta getRespuesta = this.clientProductos.RespuestaCliente(soliRest);
            IEnumerable<ParametricaServicioReferencia> listaParamEstandar = null;
            if (getRespuesta.Code == 0 && getRespuesta.SettingsData != null)
            {

                switch (servicio)
                {
                    case ServiciosParametrica.PolCad:
                        listaParamEstandar = MapperParametricas.CrearListaParametroCobertura(getRespuesta, this.persistenceProductos.GetCOberturaMapper());
                        break;
                    default:
                        listaParamEstandar = MapperParametricas.CrearListaParametroEstandarServicioReferencia(getRespuesta);
                        break;
                }
            }
            return listaParamEstandar;
        }
           

        public IEnumerable<ParametricasBdEstandar> GetListaTablaEst(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdEstandar> listaRespuesta = null;
            switch (tabla)
            {
                case BaseDatosParametrica.TipoProducto:
                    listaRespuesta = this.persistenceProductos.GetListaTipoProducto();
                    break;
                case BaseDatosParametrica.SubGrupo:
                    listaRespuesta = this.persistenceProductos.GetListaSubGrupo();
                    break;
                default:
                    break;
            }
            return listaRespuesta;

        }
        
        public IEnumerable<ParametricasBdReferencia> GetListaTablaRef(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdReferencia> listaRespuesta = null;
            switch (tabla)
            {
                case BaseDatosParametrica.Cobertura:
                    listaRespuesta = this.persistenceProductos.GetListaCobertura();
                    break;
                default:
                    break;
            }
            return listaRespuesta;

        }

        public IEnumerable<ParametricasBdEstandar> GetListaTablaPorGrupo(BaseDatosParametrica tabla, int grupoFormulario)
        {
            IEnumerable<ParametricasBdEstandar> listaRespuesta = null;
            switch (tabla)
            {
                case BaseDatosParametrica.TipoProducto:
                    listaRespuesta = this.persistenceProductos.GetListaTipoProductoPorGrupo(grupoFormulario);
                    break;
                default:
                    break;
            }
            return listaRespuesta;

        }

        public IEnumerable<ParametricasBdReferencia> GetListaTablaReferenciaPorGrupo(BaseDatosParametrica tabla, int grupoFormulario)
        {
            IEnumerable<ParametricasBdReferencia> listaRespuesta = null;
            switch (tabla)
            {
                case BaseDatosParametrica.Cobertura:
                    listaRespuesta = this.persistenceProductos.GetListaCoberturaPorGrupo(grupoFormulario);
                    break;
                case BaseDatosParametrica.PrestacioBasica:
                    listaRespuesta = this.persistenceProductos.GetListaCoberturaPrestacionBasicaPorGrupo(grupoFormulario);
                    break;
                case BaseDatosParametrica.PrestacionGenerica:
                    listaRespuesta = this.persistenceProductos.GetListaCoberturaPrestacionGenericaPorGrupo(grupoFormulario);
                    break;
                default:
                    break;
            }
            return listaRespuesta;

        }
        public IEnumerable<ParametricasBdPrestacionParametrica> GetListaTablaPrestacionesPorGrupo(BaseDatosParametrica tabla, int grupoFormulario)
        {
            IEnumerable<ParametricasBdPrestacionParametrica> listaRespuesta = null;
            switch (tabla)
            {
                case BaseDatosParametrica.Prestaciones:
                    listaRespuesta = this.persistenceProductos.GetListaCoberturaPrestacionesPorGrupo(grupoFormulario);
                    break;
                default:
                    break;
            }
            return listaRespuesta;

        }

        public IEnumerable<ProductoSaludDetalleDtoMapper> GetListaSalud( int grupoFormulario)
        {
            return this.persistenceProductos.GetListaProductoSalud(grupoFormulario);

        }

        public IEnumerable<ProductoVidaApDetalleDtoMapper> GetListaVidaAp(int grupoFormulario)
        {
            return this.persistenceProductos.GetListaProductoVidaAp(grupoFormulario);

        }

        public ProductoVidaApDtoMapper GetVidaAp(int grupoFormulario)
        {
            return this.persistenceProductos.GetProductoVidaAp(grupoFormulario);

        }

        public IEnumerable<CascadaDtoMapper> GetCascada(int grupoFormulario)
        {
            return this.persistenceProductos.GetCascada(grupoFormulario);

        }

        public Boolean SetListaCascada(IEnumerable<CascadaDtoMapper> listaCascada, int grupoFormulario)
        {
            Boolean cambioCascada = true;
            try
            {
                IEnumerable<CascadaDtoMapper> listacascadaBd = this.GetCascada(grupoFormulario);

                if (listacascadaBd != null && listaCascada != null && listacascadaBd.Count()>0)
                {
                    var insertUpdateCascasa = (from t in listaCascada
                                                where !listacascadaBd.Any(x => x.ID_CASCADA == t.ID_CASCADA
                                                                                && x.ID_COBERTURA == t.ID_COBERTURA
                                                                                && x.ID_PRODUCTO == t.ID_PRODUCTO
                                                                                && x.SIGLA_SEXO == t.SIGLA_SEXO
                                                                                && x.ID_AGRUPACION == t.ID_AGRUPACION
                                                                                && x.EDAD_HASTA == t.EDAD_HASTA
                                                                                && x.CANTIDAD == t.CANTIDAD
                                                                                && x.CODIGO_PLAN == t.CODIGO_PLAN
                                                                                && x.INCLUYE == t.INCLUYE
                                                                                && x.MONTO == t.MONTO)
                                                select t).ToList();

                    var deleteCascada = (from t in listacascadaBd
                                                  where !listaCascada.Any(x => x.ID_CASCADA == t.ID_CASCADA)
                                                  select t).ToList();

                    if (insertUpdateCascasa != null && insertUpdateCascasa.Count() > 0)
                    {
                        cambioCascada = this.persistenceProductos.SetListaCascada(insertUpdateCascasa);
                    }
                    Boolean cambioCascafa1 = true;
                    if (deleteCascada != null && deleteCascada.Count() > 0)
                    {
                        cambioCascafa1 = this.persistenceProductos.SetDeleteCascada(deleteCascada);
                    }
                    if (cambioCascada && cambioCascafa1)
                    {
                        cambioCascada = true;
                    }
                }
                else if ((listacascadaBd == null || listacascadaBd.Count() ==0) && listaCascada != null && listaCascada.Count() > 0)
                {
                    cambioCascada = this.persistenceProductos.SetListaCascada(listaCascada);
                }
                else if ((listaCascada == null || listaCascada.Count() == 0) && listacascadaBd != null && listacascadaBd.Count() > 0)
                {
                    cambioCascada = this.persistenceProductos.SetDeleteCascada(listacascadaBd);
                }
            }
            catch (Exception )
            {
                cambioCascada = false;
            }
            return cambioCascada;

        }

        public Boolean SetListVidaAp(IEnumerable<ProductoVidaApDetalleDtoMapper> listaVidaAp, int grupoFormulario)
        {
            Boolean cambioVidaAp = true;
            try
            {
                IEnumerable<ProductoVidaApDetalleDtoMapper> listaVidaApdaBd = this.GetListaVidaAp(grupoFormulario);

                if (listaVidaApdaBd != null && listaVidaAp != null && listaVidaApdaBd.Count() > 0)
                {
                    var insertUpdateVidaAp = (from t in listaVidaAp
                                               where !listaVidaApdaBd.Any(x => x.ID_PRODUCTOLIST_VIDAAP == t.ID_PRODUCTOLIST_VIDAAP
                                                                                && x.ID_COBERTURA == t.ID_COBERTURA
                                                                                && x.ID_AGRUPACION == t.ID_AGRUPACION
                                                                                && x.CANTIDAD_RENTA == t.CANTIDAD_RENTA
                                                                                && x.CAPITAL_FIJO == t.CAPITAL_FIJO
                                                                                && x.CAPITAL_MAXIMO_UF == t.CAPITAL_MAXIMO_UF
                                                                                && x.CAPITAL_MINIMO_PESO == t.CAPITAL_MINIMO_PESO)
                                               select t).ToList();

                    var deleteVidaAp = (from t in listaVidaApdaBd
                                         where !listaVidaAp.Any(x => x.ID_PRODUCTOLIST_VIDAAP == t.ID_PRODUCTOLIST_VIDAAP)
                                         select t).ToList();

                    if (insertUpdateVidaAp != null && insertUpdateVidaAp.Count() > 0)
                    {
                        cambioVidaAp = this.persistenceProductos.SetListaVidaAp(insertUpdateVidaAp);
                    }
                    Boolean cambioCascafa1 = true;
                    if (deleteVidaAp != null && deleteVidaAp.Count() > 0)
                    {
                        cambioCascafa1 = this.persistenceProductos.SetDeleteListaVidaAp(deleteVidaAp);
                    }
                    if (cambioVidaAp && cambioCascafa1)
                    {
                        cambioVidaAp = true;
                    }
                }
                else if ((listaVidaApdaBd == null || listaVidaApdaBd.Count() == 0) && listaVidaAp != null && listaVidaAp.Count() >0)
                {
                    cambioVidaAp = this.persistenceProductos.SetListaVidaAp(listaVidaAp);
                }
                else if ((listaVidaAp == null || listaVidaAp.Count() ==0) && listaVidaApdaBd != null && listaVidaApdaBd.Count() > 0)
                {
                    cambioVidaAp = this.persistenceProductos.SetDeleteListaVidaAp(listaVidaApdaBd);
                }

            }
            catch (Exception )
            {
                cambioVidaAp = false;
            }
            return cambioVidaAp;

        }

        public Boolean SetListaSalud(IEnumerable<ProductoSaludDetalleDtoMapper> listaSalud, int grupoFormulario)
        {
            Boolean cambioSalud = true;
            try
            {
                IEnumerable<ProductoSaludDetalleDtoMapper> listaSaluddaBd = this.GetListaSalud(grupoFormulario);

                if (listaSaluddaBd != null && listaSalud != null && listaSaluddaBd.Count() > 0)
                {
                    var insertUpdateSalud = (from t in listaSalud
                                             where !listaSaluddaBd.Any(x => x.ID_PRODUCTO_SALUD == t.ID_PRODUCTO_SALUD
                                                                              && x.MONTO_ASEGURADO == t.MONTO_ASEGURADO
                                                                              && x.POL_CAD == t.POL_CAD
                                                                              && x.ID_COBERTURA == t.ID_COBERTURA
                                                                              && x.ID_AGRUPACION == t.ID_AGRUPACION)
                                             select t).ToList();

                    var deletesalud = (from t in listaSaluddaBd
                                       where !listaSalud.Any(x => x.ID_PRODUCTO_SALUD == t.ID_PRODUCTO_SALUD)
                                       select t).ToList();

                    if (insertUpdateSalud != null && insertUpdateSalud.Count() > 0)
                    {
                        cambioSalud = this.persistenceProductos.SetListaSalud(insertUpdateSalud);
                    }
                    Boolean cambioSalud1 = true;
                    if (deletesalud != null && deletesalud.Count() > 0)
                    {
                        cambioSalud1 = this.persistenceProductos.SetDeleteListaSalud(deletesalud);
                    }
                    if (cambioSalud && cambioSalud1)
                    {
                        cambioSalud = true;
                    }
                }
                else if ((listaSaluddaBd == null || listaSaluddaBd.Count() == 0) && listaSalud != null && listaSalud.Count() > 0)
                {
                    cambioSalud = this.persistenceProductos.SetListaSalud(listaSalud);
                }
                else if ((listaSalud == null || listaSalud.Count()== 0) && listaSaluddaBd != null && listaSaluddaBd.Count() > 0)
                {
                    cambioSalud = this.persistenceProductos.SetDeleteListaSalud(listaSaluddaBd);
                }
            }
            catch (Exception )
            {
                cambioSalud = false;
            }
            return cambioSalud;

        }

        public Boolean SetVidaAp(ProductoVidaApDtoMapper vidaAp, int grupoFormulario)
        {
            return this.persistenceProductos.SetVidaAp(vidaAp);

        }

        /************************************************************************/
        [Inject]
        public void SetClientConvenio(IMsProductosClient clientProductos)
        {
            this.clientProductos = clientProductos;
        }

        [Inject]
        public void SetPersistenceConvenio(IMsProductosPersistence persistenceProductos)
        {
            this.persistenceProductos = persistenceProductos;
        }

    }
}