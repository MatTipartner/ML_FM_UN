using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Tarifas.Vista;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Tarifa;
using MS_ML_FU_DLL_DOMAIN.Domain.Utilidades.Serializacion;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.RestClients.Impl
{
    public class TarifasClient: ITarifasClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();
        public IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUTarifas + FUControllers.CONTROLLER_MS_FU_TARIFAS + "/getSettingData/{servicio}");
            var response = client.Execute<IEnumerable<ParametricaServicioEstandar>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public IEnumerable<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUTarifas + FUControllers.CONTROLLER_MS_FU_TARIFAS + "/getBaseDatos/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        
        /*
        * Ver comentario en la clase JsonNetSerializer en DOMAIN
        */
        [System.Obsolete]        
        public IEnumerable<TarifaGrupoDto> GetTarifaCoberturaGrupo(int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUTarifas + FUControllers.CONTROLLER_MS_FU_TARIFAS + "/tarifaGrupoDto/{grupoFormulario}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<IEnumerable<TarifaGrupoDto>>(new RestRequest().AddUrlSegment("grupoFormulario", grupoFormulario));
            return response.Data;
        }
        
        public TarifaDtoMapper GetTarifaPoliza(int nroFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUTarifas + FUControllers.CONTROLLER_MS_FU_TARIFAS + "/tarifaPoliza/{nroFormulario}");
            var response = client.Execute<TarifaDtoMapper>(new RestRequest().AddUrlSegment("nroFormulario", nroFormulario));
            return response.Data;
        }

        public Boolean SetTarifa(TarifaDtoMapper listaVidaAp)
        {
            var client = new RestClient(values.BaseUrlMSFUTarifas + FUControllers.CONTROLLER_MS_FU_TARIFAS + "/setTarifa/{nroFormulario}");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(listaVidaAp);
            request.AddJsonBody(json);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }

        public Boolean SetListaTariafaCobertura(IEnumerable<TarifaGrupoDtoMapper> listaTariafaCobertura, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUTarifas + FUControllers.CONTROLLER_MS_FU_TARIFAS + "/setListaTarifaCobertura/{GrupoFormulario}");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(listaTariafaCobertura);
            request.AddJsonBody(json);
            request.AddUrlSegment("GrupoFormulario", grupoFormulario);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }

        public Boolean SetListaTariafaCoberturaFull(IEnumerable<TarifaGrupoDtoMapper> listaTariafaCobertura, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUTarifas + FUControllers.CONTROLLER_MS_FU_TARIFAS + "/setListaTarifaCoberturaFull/{GrupoFormulario}");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(listaTariafaCobertura);
            request.AddJsonBody(json);
            request.AddUrlSegment("GrupoFormulario", grupoFormulario);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }
    }
}