using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_MENU.Persistence;
using MS_ML_FU_MENU.RestClients;
using MS_ML_FU_MENU.Utilities;
using Ninject;
using System.Collections.Generic;

namespace MS_ML_FU_MENU.Services.Impl
{
    public class MsMenuServices: IMsMenuServices
    {
        private IMsMenuPersistence persistenceMenu;
        private IMsMenuClient clientMenu;
        public IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio)
        {
            GetSettingDataSolicitud soliRest;
            soliRest = new GetSettingDataSolicitud();
            soliRest.Setting = new GetSettingDataSolicitudCuerpo();
            soliRest.Setting.Id = ((int)servicio).ToString();
            soliRest.Setting.Criteria = new List<GetSettingDataSolicitudCriterio>();
            GetSettingDataSolicitudCriterio criteria = new GetSettingDataSolicitudCriterio();
            soliRest.Setting.Criteria.Add(criteria);
            GetSettingDataRespuesta getRespuesta = this.clientMenu.RespuestaCliente(soliRest);
            IEnumerable<ParametricaServicioEstandar> listaParamEstandar = null;
            if (getRespuesta.Code == 0 && getRespuesta.SettingsData != null)
            {
                listaParamEstandar = MapperParametricas.CrearListaParametroEstandarServicio(getRespuesta);
            }
            return listaParamEstandar;
        }
        
        public IEnumerable<ParametricaServicioReferencia> RespuestaGetSettingDataParam(ServiciosParametrica servicio, int datoEntrada)
        {
            GetSettingDataSolicitud soliRest;
            soliRest = new GetSettingDataSolicitud();
            soliRest.Setting = new GetSettingDataSolicitudCuerpo();
            soliRest.Setting.Id = ((int)servicio).ToString();
            soliRest.Setting.Criteria = new List<GetSettingDataSolicitudCriterio>();
            GetSettingDataSolicitudCriterio criteria = new GetSettingDataSolicitudCriterio();
            criteria.Field1 = AtributoCriterioBd.CORREDOR;
            criteria.CompareOperate = AtributoCriterioBd.IGUAL;
            criteria.DataType = AtributoCriterioBd.ENTERO;
            criteria.ValueField2 = datoEntrada.ToString();
            soliRest.Setting.Criteria.Add(criteria);
            GetSettingDataRespuesta getRespuesta = this.clientMenu.RespuestaCliente(soliRest);
            IEnumerable<ParametricaServicioReferencia> listaParamEstandar = null;
            if (getRespuesta.Code == 0 && getRespuesta != null)
            {
                listaParamEstandar = MapperParametricas.CrearListaParametroReferenciaServicio(getRespuesta);
            }
            return listaParamEstandar;
        }

        public List<ParametricasBdEstandar> GetListaTablaEstandar(BaseDatosParametrica tabla)
        {
            List<ParametricasBdEstandar> listaRespuesta = null;
            switch (tabla){
                case BaseDatosParametrica.TipoFormulario:
                    listaRespuesta = this.persistenceMenu.GetListaTipoFormulario();
                    break;
                default:
                    break;
            }
            return listaRespuesta;
        }

        public List<ParametricasBdReferencia> GetListaTablaReferencia(BaseDatosParametrica tabla)
        {
            List<ParametricasBdReferencia> listaRespuesta = null;
            switch (tabla){
                case BaseDatosParametrica.TipoFormularioDetalle:
                    listaRespuesta = this.persistenceMenu.GetListaTipoFormularioDetalle();
                    break;
                default:
                    break;
            }
            return listaRespuesta;
        }



        [Inject]
        public void SetClientConvenio(IMsMenuClient clientMenu)
        {
            this.clientMenu = clientMenu;
        }

        [Inject]
        public void SetPersistenceConvenio(IMsMenuPersistence persistenceMenu)
        {
            this.persistenceMenu = persistenceMenu;
        }
    }
}