using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_BMI.Persistence;
using MS_ML_FU_P_BMI.RestClients;
using MS_ML_FU_P_BMI.Utilities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_BMI.Services.Impl
{
    public class MsParametrosServices:IMsParametrosServices
    {
        private IMsParametrosPersistence persistenceParametros;
        private IMsParametrosClient clientParametros;
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
            GetSettingDataRespuesta getRespuesta = this.clientParametros.RespuestaCliente(soliRest);
            IEnumerable<ParametricaServicioEstandar> listaParamEstandar = null;
            if (getRespuesta.Code == 0 && getRespuesta.SettingsData != null)
            {
                listaParamEstandar = MapperParametricas.CrearListaParametroEstandarServicio(getRespuesta);
            }
            return listaParamEstandar;
        }

        public List<ParametricasBdEstandar> GetListaTabla(BaseDatosParametrica tabla)
        {
            List<ParametricasBdEstandar> listaRespuesta = null;
            switch (tabla)
            {
                case BaseDatosParametrica.AquienParametros:
                    listaRespuesta = this.persistenceParametros.GetListaAquienParametros();
                    break;
                case BaseDatosParametrica.GrupoIsapre:
                    listaRespuesta = this.persistenceParametros.GetListaGrupoIsapre();
                    break;
                case BaseDatosParametrica.PrestacioBasica:
                    listaRespuesta = this.persistenceParametros.GetListaPrestacionBasica();
                    break;
                default:
                    break;
            }
            return listaRespuesta;
        }

        [Inject]
        public void SetClientConvenio(IMsParametrosClient clientParametros)
        {
            this.clientParametros = clientParametros;
        }

        [Inject]
        public void SetPersistenceConvenio(IMsParametrosPersistence persistenceParametros)
        {
            this.persistenceParametros = persistenceParametros;
        }
    }
}