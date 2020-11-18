using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_REQ_ASEG.Persistence;
using MS_ML_FU_P_REQ_ASEG.RestClients;
using MS_ML_FU_P_REQ_ASEG.Utilities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_REQ_ASEG.Services.Impl
{
    public class MsReqAsegServices:IMsReqAsegServices
    {
        private IMsReqAsegPersistence persistenceReqAseg;
        private IMsReqAsegClient clientResAseg;

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
            GetSettingDataRespuesta getRespuesta = this.clientResAseg.RespuestaCliente(soliRest);
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
                case BaseDatosParametrica.ExclusionAsegurabilidad:
                    listaRespuesta = this.persistenceReqAseg.GetExclusionAsegurabilidad();
                    break;
                default:
                    break;
            }
            return listaRespuesta;
        }

        [Inject]
        public void SetClientConvenio(IMsReqAsegClient clientResAseg)
        {
            this.clientResAseg = clientResAseg;
        }

        [Inject]
        public void SetPersistenceConvenio(IMsReqAsegPersistence persistenceReqAseg)
        {
            this.persistenceReqAseg = persistenceReqAseg;
        }
    }
}
