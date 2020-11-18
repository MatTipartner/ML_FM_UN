using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_IMED.Persistence;
using MS_ML_FU_P_IMED.RestClients;
using MS_ML_FU_P_IMED.Utilities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_P_IMED.Services.Impl
{
    public class MsImedServices:IMsImedServices
    {
        private IMsImedClient clientImed;
        private IMsImedPersistence persistenceImed;
        public IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio)
        {
            GetSettingDataSolicitud soliRest;
            soliRest = new GetSettingDataSolicitud();
            soliRest.Setting = new GetSettingDataSolicitudCuerpo();
            soliRest.Setting.Id = ((int)servicio).ToString();
            soliRest.Setting.Criteria = new List<GetSettingDataSolicitudCriterio>();
            GetSettingDataSolicitudCriterio criteria = new GetSettingDataSolicitudCriterio();
            soliRest.Setting.Criteria.Add(criteria);
            GetSettingDataRespuesta getRespuesta = this.clientImed.RespuestaCliente(soliRest);
            IEnumerable<ParametricaServicioEstandar> listaParamEstandar = null;
            if (getRespuesta.Code == 0 && getRespuesta.SettingsData != null)
            {
                listaParamEstandar = MapperParametricas.CrearListaParametroEstandarServicio(getRespuesta);
            }
            switch (servicio)
            {
                case ServiciosParametrica.TopeMonto:
                    //esto solo es un ejemplo, pero recordar realizar el filtro a esta lista
                    //listaParamEstandar = listaParamEstandar.Where(x => x.Hasta != null.ToList();
                    break;
                default:
                    break;
            }
            return listaParamEstandar;
        }

        public IEnumerable<ParametricasBdEstandar> GetListaTablaEstandar(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdEstandar> listaRespuesta = null;
            switch (tabla)
            {
                case BaseDatosParametrica.TipoImed:
                    listaRespuesta = this.persistenceImed.GetListaTipoImed();
                    break;
                case BaseDatosParametrica.GrupoPrestadores:
                    listaRespuesta = this.persistenceImed.GetListaGrupoPrestador();
                    break;
                case BaseDatosParametrica.Frecuencia:
                    listaRespuesta = this.persistenceImed.GetListaFrecuencia();
                    break;                
                default:
                    break;
            }
            return listaRespuesta;
        }
        public IEnumerable<ParametricasBdReferencia> GetListaTablaReferencial(BaseDatosParametrica tabla)
        {
            IEnumerable<ParametricasBdReferencia> listaRespuesta = null;
            switch (tabla)
            {               
                case BaseDatosParametrica.GrupoPrestadorSacs:
                    listaRespuesta = this.persistenceImed.GetListaGrupoPrestadorSacs();
                    break;
                
                default:
                    break;
            }
            return listaRespuesta;
        }

        [Inject]
        public void SetClientConvenio(IMsImedClient clientImed)
        {
            this.clientImed = clientImed;
        }

        [Inject]
        public void SetPersistenceConvenio(IMsImedPersistence persistenceImed)
        {
            this.persistenceImed = persistenceImed;
        }
    }
}