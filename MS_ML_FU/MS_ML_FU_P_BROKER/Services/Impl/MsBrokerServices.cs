using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Broker;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_P_BROKER.Persistence;
using MS_ML_FU_P_BROKER.RestClients;
using MS_ML_FU_P_BROKER.Utilities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;

namespace MS_ML_FU_P_BROKER.Services.Impl
{
    public class MsBrokerServices : IMsBrokerServices
    {
        private IMsBrokerClient clientBroker;
        private IMsBrokerPersistence persistenceBroker;

        public IEnumerable<ParametricaServicioEstandar> RespuestaGetSettingData(ServiciosParametrica servicio, int runCorredor)
        {
            GetSettingDataSolicitud soliRest;
            // Solo implementar el switch cuando exista valores de criterio en la busqueda de datos para el servicio
            switch (servicio)
            {
                case ServiciosParametrica.Holding:
                    soliRest = new GetSettingDataSolicitud();
                    soliRest.Setting = new GetSettingDataSolicitudCuerpo();
                    soliRest.Setting.Id = ((int)servicio).ToString();
                    soliRest.Setting.Criteria = new List<GetSettingDataSolicitudCriterio>();
                    GetSettingDataSolicitudCriterio criteria = new GetSettingDataSolicitudCriterio();
                    criteria.Field1 = "CORREDOR";
                    criteria.CompareOperate = "=";
                    criteria.DataType = "INTEGER";
                    criteria.ValueField2 = runCorredor.ToString();
                    soliRest.Setting.Criteria.Add(criteria);
                    break;
                default:
                    return null;
            }
           GetSettingDataRespuesta getRespuesta = this.clientBroker.RespuestaCliente(soliRest);
            IEnumerable<ParametricaServicioEstandar> listaParamEstandar = null;

            if (getRespuesta.Code == 0 && getRespuesta.SettingsData != null)
            {
                listaParamEstandar = MapperParametricas.CrearListaParametroEstandarServicio(getRespuesta);
            }

            /*Codigo porque no esta el servicio el linea */
            /* List<ParametricaServicioEstandar> listaParamEstandar = null;
            ParametricaServicioEstandar prueba = new ParametricaServicioEstandar();
            prueba.Id = "1";
            prueba.Descripcion = "TELEFONICA CHILE";
            listaParamEstandar.Add(prueba);
            prueba = new ParametricaServicioEstandar();
            prueba.Id = "2";
            prueba.Descripcion = "TELEFONICA VIDA";
            listaParamEstandar.Add(prueba);
            prueba = new ParametricaServicioEstandar();
            prueba.Id = "3";
            prueba.Descripcion = "TELEFONICA AP";
            listaParamEstandar.Add(prueba);
            prueba = new ParametricaServicioEstandar();
            prueba.Id = "0";
            prueba.Descripcion = "Sin Holding";
            listaParamEstandar.Add(prueba);*/
            /*Fin codigo */


            return listaParamEstandar;
        }


        public IEnumerable<ParametricaServicioReferencia> GetListaEjecutivosPorCorredor(int runCorredor)
        {

            List<ParametricaServicioReferencia> listaParamEstandar = new List<ParametricaServicioReferencia>();
            ParametricaServicioReferencia prueba = new ParametricaServicioReferencia();
            prueba.Id = "162012789";
            prueba.Descripcion = "RUN PRUBA 1";
            prueba.IdReferencia = "1";
            listaParamEstandar.Add(prueba);
            prueba = new ParametricaServicioReferencia();
            prueba.Id = "16666666";
            prueba.Descripcion = "RUN PRUBA 2";
            prueba.IdReferencia = "1";
            listaParamEstandar.Add(prueba);
            prueba = new ParametricaServicioReferencia();
            prueba.Id = "162012789";
            prueba.Descripcion = "RUN PRUBA 1";
            prueba.IdReferencia = "2";
            listaParamEstandar.Add(prueba);
            prueba = new ParametricaServicioReferencia();
            prueba.Id = "16666666";
            prueba.Descripcion = "RUN PRUBA 2";
            prueba.IdReferencia = "2";
            listaParamEstandar.Add(prueba);
            prueba = new ParametricaServicioReferencia();
            prueba.Id = "162012789";
            prueba.Descripcion = "RUN PRUBA 1";
            prueba.IdReferencia = "3";
            listaParamEstandar.Add(prueba);
            prueba = new ParametricaServicioReferencia();
            prueba.Id = "16666666";
            prueba.Descripcion = "RUN PRUBA 2";
            prueba.IdReferencia = "3";
            listaParamEstandar.Add(prueba);
            prueba = new ParametricaServicioReferencia();
            prueba.Id = "162012789";
            prueba.Descripcion = "RUN PRUBA 1";
            prueba.IdReferencia = "4";
            listaParamEstandar.Add(prueba);
            prueba = new ParametricaServicioReferencia();
            prueba.Id = "16666666";
            prueba.Descripcion = "RUN PRUBA 5";
            prueba.IdReferencia = "4";
            listaParamEstandar.Add(prueba);
            return listaParamEstandar;
        }


        public Boolean SetBrokerCcte(IEnumerable<BrokerCcteDtoMapper> listaBrokerCcte)
        {
            if (listaBrokerCcte != null && listaBrokerCcte.Count() > 0 )
            {
                return this.persistenceBroker.SetBrokerCcte(listaBrokerCcte);
            }
            else {
                return false;
            }
        }

        public Boolean SetBrokerCorredor(BrokerCorradorDtoMapper brokerCorredor)
        {
            if (brokerCorredor != null)
            {
                return this.persistenceBroker.SetBrokerCorredor(brokerCorredor);
            }
            else
            {
                return false;
            }

        }

        public BrokerCorradorDtoMapper GetFormularioCorredor(int grupoFormulario)
        {
            return this.persistenceBroker.GetFormularioCorredor(grupoFormulario);
        }

        public IEnumerable<BrokerCcteDtoMapper> GetFormularioCcte(int grupoFormulario)
        {
            return this.persistenceBroker.GetFormularioCcte(grupoFormulario);

        }

        public IEnumerable<ParametricasInfoFacturacion> GetInforFacturacion(int grupoFormulario) {
            IEnumerable<BrokerCcteDtoMapper> listaCcte = GetFormularioCcte(grupoFormulario);
            List<ParametricasInfoFacturacion> listInfoFacturacion = new List<ParametricasInfoFacturacion> ();
            
            if (listaCcte != null && listaCcte.Count() > 0) {
                ParametricasInfoFacturacion infoFacturacion = null;
                foreach (var lista in listaCcte) {
                    infoFacturacion = new ParametricasInfoFacturacion();
                    infoFacturacion.Rut = lista.RUTCCTE;
                    infoFacturacion.Dv = lista.DVCCTE;
                    infoFacturacion.IdReferencia = lista.ID_TIPOCCTE;
                    listInfoFacturacion.Add(infoFacturacion);
                }
            }
            return listInfoFacturacion;
        }

        /************************************************************************/
        [Inject]
        public void SetRestClientBroker(IMsBrokerClient clientBroker)
        {
            this.clientBroker = clientBroker;
        }

        [Inject]
        public void SetPersistenceBroker(IMsBrokerPersistence persistenceBroker)
        {
            this.persistenceBroker = persistenceBroker;
        }
    }
      
}