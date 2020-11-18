
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_DATOSPOLIZA.Persistence;
using MS_ML_FU_P_DATOSPOLIZA.RestClients;
using MS_ML_FU_P_DATOSPOLIZA.Utilities;
using Ninject;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MS_ML_FU_P_DATOSPOLIZA.Services.Impl
{
    public class MsDatosPolizaServices : IMsDatosPolizaServices
    {
        private IMsDatosPolizaPersistence persistenceDatosPoliza;
        private IMsDatosPolizaClients clientDatosPoliza;

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
            GetSettingDataRespuesta getRespuesta = this.clientDatosPoliza.RespuestaCliente(soliRest);
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
                case BaseDatosParametrica.CanalVenta:
                    listaRespuesta = this.persistenceDatosPoliza.GetListaCanalVenta();
                    break;
                case BaseDatosParametrica.LineaNegocio:
                    listaRespuesta = this.persistenceDatosPoliza.GetListaLineaNegocio();
                    break;
                case BaseDatosParametrica.Riesgo:
                    listaRespuesta = this.persistenceDatosPoliza.GetListaRiesgo();
                    break;
                case BaseDatosParametrica.TipoAdittion:
                    listaRespuesta = this.persistenceDatosPoliza.GetListaTipoAdicion();
                    break;
                case BaseDatosParametrica.TipoPoliza:
                    listaRespuesta = this.persistenceDatosPoliza.GetListaPoliza();
                    break;
                default:
                    break;
            }
            return listaRespuesta;
        }

        public DatosPolizaDtoMapper GetFormularioPoliza(int NroPoliza)
        {
            return this.persistenceDatosPoliza.GetFormularioPoliza(NroPoliza);
        }

        public IEnumerable<UbicacionGeograficaDtoMapper> GetUbicacionesGeograficaPorPoliza(int nroPoliza)
        {
            return this.persistenceDatosPoliza.GetUbicacionesGeograficaPorPoliza(nroPoliza);
        }

        public Boolean SetDatosPoliza(DatosPolizaDtoMapper datosPoliza)
        {
            Boolean cambiosPoliza = this.persistenceDatosPoliza.SetDatosPoliza(datosPoliza);
            if (cambiosPoliza) {
                IEnumerable<UbicacionGeograficaDtoMapper> listaUbicacionGeograficaBd = this.GetUbicacionesGeograficaPorPoliza(datosPoliza.NRO_POLIZA ?? 0);
                IEnumerable<UbicacionGeograficaDtoMapper> listaUbicacionGeograficaFront = datosPoliza.FUWEB_UBICACION_GEOGRAFICA;
                if (listaUbicacionGeograficaBd != null  && listaUbicacionGeograficaFront != null && listaUbicacionGeograficaBd.Count() > 0) {
                    var insertUpdate = (from tt in listaUbicacionGeograficaFront
                                        where !listaUbicacionGeograficaBd.Any(x => x.ID_UBICACIONGEOGRAFICA == tt.ID_UBICACIONGEOGRAFICA
                                                                                    && x.NOMBRE_UBICACIONGEOGRAFICA.ToUpper() == tt.NOMBRE_UBICACIONGEOGRAFICA.ToUpper()
                                                                                    && x.NRO_POLIZA == tt.NRO_POLIZA)
                                        select tt).ToList();

                    var noExisteEnFront = (from t in listaUbicacionGeograficaBd
                                           where !listaUbicacionGeograficaFront.Any(x => x.ID_UBICACIONGEOGRAFICA == t.ID_UBICACIONGEOGRAFICA
                                                                                      && x.NRO_POLIZA == t.NRO_POLIZA)
                                           select t).ToList();

                    if (noExisteEnFront != null && noExisteEnFront.Count() > 0)
                    {
                        cambiosPoliza = this.persistenceDatosPoliza.SetDeletebicacionGeografica(noExisteEnFront);
                    }
                    if (insertUpdate != null && insertUpdate.Count() > 0 && cambiosPoliza)
                    {
                        cambiosPoliza = this.persistenceDatosPoliza.SetUbicacionGeografica(insertUpdate);
                    }
                }
                else if (listaUbicacionGeograficaBd == null && listaUbicacionGeograficaFront != null && listaUbicacionGeograficaFront.Count() > 0)
                {
                    cambiosPoliza = this.persistenceDatosPoliza.SetUbicacionGeografica(listaUbicacionGeograficaFront);
                }
                else if (listaUbicacionGeograficaFront == null && listaUbicacionGeograficaBd != null && listaUbicacionGeograficaBd.Count() > 0)
                {
                    cambiosPoliza = this.persistenceDatosPoliza.SetDeletebicacionGeografica(listaUbicacionGeograficaBd);
                }

            }
            return cambiosPoliza;
        }

            /****************************************************************************/
            [Inject]
        public void SetClientConvenio(IMsDatosPolizaClients clientDatosPoliza)
        {
            this.clientDatosPoliza = clientDatosPoliza;
        }

        [Inject]
        public void SetPersistenceConvenio(IMsDatosPolizaPersistence persistenceDatosPoliza)
        {
            this.persistenceDatosPoliza = persistenceDatosPoliza;
        }
    }
}