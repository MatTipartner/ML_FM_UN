using EJEMPLO.Persistence;
using EJEMPLO.RestClients;
using EJEMPLO.Utilities;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.DatosPoliza;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.RespuestaSettingData;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Estructura.SolicitudSettingData;
using MS_ML_FU_DLL_DOMAIN.Model.Tests.Dtos.Dto;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using Ninject;
using System;
using System.Collections.Generic;

namespace EJEMPLO.Services.Impl
{

    public class MsEjemplo : IMsEjemplo
    {
        private IMsEjemploPersistence servicePersis;
        private IMsEjemploRest serviceRest;

        public List<TipoGlosaDto> listaTipoGlosaBd() {
            return this.servicePersis.setListaGlosa();
        }

        public IEnumerable<ParametricaServicioEstandar> respuestaGetSettingData(ServiciosParametrica servicio) {
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
            GetSettingDataRespuesta getRespuesta = this.serviceRest.respuesta(soliRest);
            IEnumerable<ParametricaServicioEstandar> listaParamEstandar = null;
            if (getRespuesta.Code == 0 && getRespuesta.SettingsData != null) {
                listaParamEstandar = MapperParametricas.CrearListaParametroEstandarServicio(getRespuesta);
            }

            return listaParamEstandar;
        }

        public Boolean SetDatosPoliza() {
            DatosPolizaDtoMapper datosPolizaDtoMapper = new DatosPolizaDtoMapper();
            datosPolizaDtoMapper.NRO_POLIZA = 3;
            datosPolizaDtoMapper.NRO_BIZFLOW = 1;
            datosPolizaDtoMapper.ID_RIESGO = 1;
            datosPolizaDtoMapper.SIGLA_MONEDA = "UF";
            datosPolizaDtoMapper.ID_SUCURSAL = 2;
            datosPolizaDtoMapper.ID_ESTADOCOBERTURA = 0;
            datosPolizaDtoMapper.ID_CANALVENTA = 0;
            datosPolizaDtoMapper.ID_LINEANEGOCIO = 0;
            datosPolizaDtoMapper.ADDITION = "S";
            datosPolizaDtoMapper.COMENTARIO = "Algo de comentarios";
            datosPolizaDtoMapper.ID_ESTADOCOBERTURA = 1;
            datosPolizaDtoMapper.NUEVONEGOCIO = "N";
            datosPolizaDtoMapper.VIGENTE_FINAL = DateTime.Now;
            datosPolizaDtoMapper.VIGENTE_INICIO = DateTime.Now;
            datosPolizaDtoMapper.FUWEB_UBICACION_GEOGRAFICA = null;
            datosPolizaDtoMapper.ID_TIPOADDITION = 1;
            datosPolizaDtoMapper.ID_FORMULARIODETALLE = 1;
            datosPolizaDtoMapper.ID_TIPOPOLIZA = 1;
            datosPolizaDtoMapper.ID_ESTADOBISFLOW = null;
            datosPolizaDtoMapper.ID_ESTADOCOBERTURA = null;
            datosPolizaDtoMapper.NRO_POLIZA_SACS = null;
            return this.servicePersis.SetDatosPoliza(datosPolizaDtoMapper);

        }

        public Boolean PruebaUpdate()
        {
            DatosPolizaDtoMapper datosPolizaDtoMapper = new DatosPolizaDtoMapper();
            datosPolizaDtoMapper.NRO_POLIZA = 3;
            datosPolizaDtoMapper.NRO_BIZFLOW = 2;
            datosPolizaDtoMapper.ID_RIESGO = 2;
            datosPolizaDtoMapper.SIGLA_MONEDA = "US";
            datosPolizaDtoMapper.ID_SUCURSAL = 2;
            datosPolizaDtoMapper.ID_ESTADOCOBERTURA = 0;
            datosPolizaDtoMapper.ID_CANALVENTA = 0;
            datosPolizaDtoMapper.ID_LINEANEGOCIO = 0;
            datosPolizaDtoMapper.ADDITION = "S";
            datosPolizaDtoMapper.COMENTARIO = "Nuevo Comentario originalmente ";
            datosPolizaDtoMapper.ID_ESTADOCOBERTURA = 1;
            datosPolizaDtoMapper.NUEVONEGOCIO = "F";
            datosPolizaDtoMapper.VIGENTE_FINAL = DateTime.Now;
            datosPolizaDtoMapper.VIGENTE_INICIO = DateTime.Now;
            datosPolizaDtoMapper.FUWEB_UBICACION_GEOGRAFICA = null;
            datosPolizaDtoMapper.ID_TIPOADDITION = 1;
            datosPolizaDtoMapper.ID_FORMULARIODETALLE = 2;
            datosPolizaDtoMapper.ID_TIPOPOLIZA = 2;
            datosPolizaDtoMapper.ID_ESTADOBISFLOW = null;
            datosPolizaDtoMapper.ID_ESTADOCOBERTURA = null;
            datosPolizaDtoMapper.NRO_POLIZA_SACS = null;
            return this.servicePersis.PruebaUpdate(datosPolizaDtoMapper);
        }

        public Boolean PruebaDelete()
        {
            DatosPolizaDtoMapper datosPolizaDtoMapper = new DatosPolizaDtoMapper();
            datosPolizaDtoMapper.NRO_POLIZA = 3;
            return this.servicePersis.PruebaDelete(datosPolizaDtoMapper);
        }


        [Inject]
        public void SetPersistenceBd(IMsEjemploPersistence servicePersis)
        {
            this.servicePersis = servicePersis;
        }

        [Inject]
        public void SetRest(IMsEjemploRest serviceRest)
        {
            this.serviceRest = serviceRest;
        }
    }


    
}