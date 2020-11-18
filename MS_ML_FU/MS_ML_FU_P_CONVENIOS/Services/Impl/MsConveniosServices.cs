using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_CONVENIOS.Persistence;
using MS_ML_FU_P_CONVENIOS.RestClients;
using MS_ML_FU_P_CONVENIOS.Utilities;
using Ninject;
using System;
using System.Linq;
using System.Collections.Generic;


namespace MS_ML_FU_P_CONVENIOS.Services.Impl
{
    public class MsConveniosServices:IMsConveniosServices
    {
        private IMsConveniosClient clienteConvenio;
        private IMsConveniosPersistence persistenceConvenio;
        
        public IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio)
        {
            GetSettingDataSolicitud soliRest;
            // Solo implementar el switch cuando exista valores de criterio en la busqueda de datos para el servicio
            /* switch (servicio) {
                 case ServiciosParametrica.MonedaPoliza:*/
            soliRest = new GetSettingDataSolicitud();
            soliRest.Setting = new GetSettingDataSolicitudCuerpo();
            soliRest.Setting.Id = ((int)servicio).ToString();
            soliRest.Setting.Criteria = new List<GetSettingDataSolicitudCriterio>();
            GetSettingDataSolicitudCriterio criteria = new GetSettingDataSolicitudCriterio();
            soliRest.Setting.Criteria.Add(criteria);
            /*       break;
               default:
                   return null;
           }*/
            GetSettingDataRespuesta getRespuesta = this.clienteConvenio.RespuestaCliente(soliRest);
            IEnumerable<ParametricaServicioEstandar> listaParamEstandar = null;
            if (getRespuesta.Code == 0 && getRespuesta.SettingsData != null)
            {
                listaParamEstandar = MapperParametricas.CrearListaParametroEstandarServicio(getRespuesta);
            }
            return listaParamEstandar;
        }
        public IEnumerable<ParametricasBdEstandar> GetListaTabla(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdEstandar> listaRespuesta = null;
            switch (tabla)
            {
                case BaseDatosParametrica.Vademecum:
                    listaRespuesta = this.persistenceConvenio.GetListaVademecum();
                    break;
                case BaseDatosParametrica.TipoFacturacion:
                    listaRespuesta = this.persistenceConvenio.GetListaTipoFacturacion();
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
                case BaseDatosParametrica.Convenio:
                    listaRespuesta = this.persistenceConvenio.GetListaConvenio();
                    break;
                default:
                    break;
            }
            return listaRespuesta;

        }
        public IEnumerable<OtrosConveniosDtoMapper> GetOtrosConveniosMapper(int GrupoFormulario)
        {
            return this.persistenceConvenio.GetConvenioPorGrupo(GrupoFormulario);

        }

        public IEnumerable<OtrosConvenioDto> GetOtrosConvenios(int grupoFormulario)
        {
            IEnumerable<OtrosConveniosDtoMapper> listaConeviosMapper = this.GetOtrosConveniosMapper(grupoFormulario);
            return MapperParametricas.MapperDtoMapperaDtoVistaOtrosConvenios(listaConeviosMapper);
        }

        public IEnumerable<FarmaciaDto> GetFarmacia(int grupoFormulario)
        {
            IEnumerable<FarmaciaDtoMapper> listaFarmaciaMapper = this.GetFarmaciaMapper(grupoFormulario);
            return MapperParametricas.MapperDtoMapperaDtoVistaFarmacia(listaFarmaciaMapper); ;
        }

        public IEnumerable<FarmaciaDtoMapper> GetFarmaciaMapper(int GrupoFormulario)
        {
            return this.persistenceConvenio.GetFarmaciaPorGrupo(GrupoFormulario);

        }

        public Boolean SetConvenio(IEnumerable<OtrosConvenioDto> listaConvenioDto, int grupoFormulario) {
            Boolean cambioConvenio = true;
            try { 
            IEnumerable<OtrosConvenioDto> listaOtrosConveniosBd = this.GetOtrosConvenios(grupoFormulario);
            
                if (listaConvenioDto != null)
                {
                    var insertUpdateConvenio = (from t in listaConvenioDto
                                                where !listaOtrosConveniosBd.Any(x => x.ID_OTROSCONVENIOS == t.ID_OTROSCONVENIOS
                                                                                && x.ID_CONVENIO == x.ID_CONVENIO)
                                                select t).ToList();

                    var noExisteEnFronConvenio = (from t in listaOtrosConveniosBd
                                                  where !listaConvenioDto.Any(x => x.ID_OTROSCONVENIOS == t.ID_OTROSCONVENIOS
                                                                                && x.ID_CONVENIO == x.ID_CONVENIO)
                                                  select t).ToList();
                    IEnumerable<OtrosConveniosDtoMapper> OtrosconveioMapper = null;
                    if (noExisteEnFronConvenio != null && noExisteEnFronConvenio.Count() > 0)
                    {
                        OtrosconveioMapper = MapperParametricas.MapperDtoVistaADtoMapperaOtrosConvenios(noExisteEnFronConvenio);
                        cambioConvenio = this.persistenceConvenio.SetDeleteOtrosConvenios(OtrosconveioMapper);
                    }
                    Boolean cambioConvenio1 = true;
                    if (insertUpdateConvenio != null && insertUpdateConvenio.Count() > 0)
                    {
                        OtrosconveioMapper = MapperParametricas.MapperDtoVistaADtoMapperaOtrosConvenios(insertUpdateConvenio);
                        cambioConvenio1 = this.persistenceConvenio.SetOtrosConvenios(OtrosconveioMapper);
                    }
                    if (cambioConvenio && cambioConvenio1)
                    {
                        cambioConvenio = true;
                    }
                }
            }
            catch (Exception )
            {
                cambioConvenio = false;
            }
            return cambioConvenio;        
        }

        public Boolean SetFarmacia(IEnumerable<FarmaciaDto> listaFarmaciaDto, int grupoFormulario)
        {
            Boolean cambioConvenio = true;
            try {
                IEnumerable<FarmaciaDto> listaFarmaciaBd = this.GetFarmacia(grupoFormulario);
                
                if (listaFarmaciaDto != null)
                {
                    var insertUpdateFarmacia = (from tt in listaFarmaciaDto
                                                where !listaFarmaciaBd.Any(x => x.ID_LISTAFARMACIA == tt.ID_LISTAFARMACIA
                                                                                && x.ID_FARMACIA == tt.ID_FARMACIA
                                                                                && x.ID_TIPOFACTURACION == tt.ID_TIPOFACTURACION
                                                                                && x.ID_VADEMECUM == tt.ID_VADEMECUM
                                                                                && x.MODOOPERACION == tt.MODOOPERACION
                                                                                && x.MONTOASEGURADO == tt.MONTOASEGURADO
                                                                                && x.OPS == tt.OPS
                                                                                && x.SIGLAMONEDA == tt.SIGLAMONEDA)
                                                select tt).ToList();

                    var noExisteEnFronFarmacia = (from tt in listaFarmaciaBd
                                                  where !listaFarmaciaDto.Any(x => x.ID_LISTAFARMACIA == tt.ID_LISTAFARMACIA)
                                                  select tt).ToList();

                    IEnumerable<FarmaciaDtoMapper> OtrosconveioMapper = null;
                    if (noExisteEnFronFarmacia != null && noExisteEnFronFarmacia.Count() > 0)
                    {
                        OtrosconveioMapper = MapperParametricas.MapperDtoVistaADtoMapperaFarmacia(noExisteEnFronFarmacia);
                        cambioConvenio = this.persistenceConvenio.SetDeleteFarmacia(OtrosconveioMapper);
                    }
                    Boolean cambioConvenio1 = true;
                    if (insertUpdateFarmacia != null && insertUpdateFarmacia.Count() > 0)
                    {
                        OtrosconveioMapper = MapperParametricas.MapperDtoVistaADtoMapperaFarmacia(insertUpdateFarmacia);
                        cambioConvenio1 = this.persistenceConvenio.SetsFarmacia(OtrosconveioMapper);
                    }
                    if (cambioConvenio && cambioConvenio1) {
                        cambioConvenio = true;
                    }

                } 
            } catch (Exception )
            {
                cambioConvenio = false;
            }
            return cambioConvenio;
        }

        /*****************************************************************/
        [Inject]
        public void SetClientConvenio(IMsConveniosClient clienteConvenio)
        {
            this.clienteConvenio = clienteConvenio;
        }

        [Inject]
        public void SetPersistenceConvenio(IMsConveniosPersistence persistenceConvenio)
        {
            this.persistenceConvenio = persistenceConvenio;
        }
    }
}