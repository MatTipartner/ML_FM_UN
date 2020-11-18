using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Parametros;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.RestClients.Impl
{
    public class ParametrosClient: IParametrosClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();
        public ParametroDto GetFormularioTarida(int nroFormulario, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUParametros + FUControllers.CONTROLLER_MS_FU_PARAMETROS + "/formulario/{nroFormulario}{grupoFormulario}");
            var response = client.Execute<ParametroDto>(new RestRequest().AddUrlSegment("nroFormulario", nroFormulario).AddUrlSegment("grupoFormulario", grupoFormulario));
            return response.Data;
        }

        public List<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUParametros + FUControllers.CONTROLLER_MS_FU_PARAMETROS + "/getSettingData/{servicio}");
            var response = client.Execute<List<ParametricaServicioEstandar>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public List<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUParametros + FUControllers.CONTROLLER_MS_FU_PARAMETROS + "/getSettingData/{servicio}");
            var response = client.Execute<List<ParametricaServicioReferencia>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public List<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUParametros + FUControllers.CONTROLLER_MS_FU_PARAMETROS + "/getBaseDatosEst/{tabla}");
            var response = client.Execute<List<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        public List<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUParametros + FUControllers.CONTROLLER_MS_FU_PARAMETROS + "/getBaseDatosRef/{tabla}");
            var response = client.Execute<List<ParametricasBdReferencia>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }
    }
}