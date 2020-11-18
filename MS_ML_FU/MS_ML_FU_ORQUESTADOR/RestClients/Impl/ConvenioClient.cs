using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Convenio;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Transformaciones.Convenio;
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
    public class ConvenioClient: IConvenioClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();

        public IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUConvenios + FUControllers.CONTROLLER_MS_FU_CONVENIO + "/getSettingData/{servicio}");
            var response = client.Execute<IEnumerable<ParametricaServicioEstandar>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public IEnumerable<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUConvenios + FUControllers.CONTROLLER_MS_FU_CONVENIO + "/getSettingData/{servicio}");
            var response = client.Execute<IEnumerable<ParametricaServicioReferencia>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public IEnumerable<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUConvenios + FUControllers.CONTROLLER_MS_FU_CONVENIO + "/getBaseDatosEst/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        public IEnumerable<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUConvenios + FUControllers.CONTROLLER_MS_FU_CONVENIO + "/getBaseDatosRef/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdReferencia>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }
        /*
         * Ver comentario en la clase JsonNetSerializer en DOMAIN
         */
        [System.Obsolete]        
        public IEnumerable<FarmaciaDto> GetFarmacia(int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUConvenios + FUControllers.CONTROLLER_MS_FU_CONVENIO + "/getFarmacia/{GrupoFormulario}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<IEnumerable<FarmaciaDto>>(new RestRequest().AddUrlSegment("GrupoFormulario", grupoFormulario));
            return response.Data;
        }
        /*
         * Ver comentario en la clase JsonNetSerializer en DOMAIN
         */
        [System.Obsolete]
        public IEnumerable<OtrosConvenioDto> GetOtrosConvenios(int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUConvenios + FUControllers.CONTROLLER_MS_FU_CONVENIO + "/getOtrosConvenios/{GrupoFormulario}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<IEnumerable<OtrosConvenioDto>>(new RestRequest().AddUrlSegment("GrupoFormulario", grupoFormulario));
            return response.Data;
        }

        public Boolean SetOtrosConvenios(IEnumerable<OtrosConvenioDto> otrosConvenioDto, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUConvenios + FUControllers.CONTROLLER_MS_FU_CONVENIO + "/setOtrosConvenios/{GrupoFormulario}");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(otrosConvenioDto);
            request.AddJsonBody(json);
            request.AddUrlSegment("GrupoFormulario", grupoFormulario);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }

        public Boolean SetFarmacia(IEnumerable<FarmaciaDto> farmaciaDto, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUConvenios + FUControllers.CONTROLLER_MS_FU_CONVENIO + "/setFarmacia/{GrupoFormulario}");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(farmaciaDto);
            request.AddJsonBody(json);
            request.AddUrlSegment("GrupoFormulario", grupoFormulario);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }
    }
}