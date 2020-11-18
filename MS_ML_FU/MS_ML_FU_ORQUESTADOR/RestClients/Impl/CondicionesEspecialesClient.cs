using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.CondicionEspecial;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.RestClients.Impl
{
    public class CondicionesEspecialesClient: ICondicionesEspecialesClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();
        public CondEspecDto GetFormularioTarida(int nroFormulario, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUCondiciones + FUControllers.CONTROLLER_MS_FU_CONDCIONESESPECIALES + "/formulario/{nroFormulario}{grupoFormulario}");
            var response = client.Execute<CondEspecDto>(new RestRequest().AddUrlSegment("nroFormulario", nroFormulario).AddUrlSegment("grupoFormulario", grupoFormulario));
            return response.Data;
        }

        public List<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUCondiciones + FUControllers.CONTROLLER_MS_FU_CONDCIONESESPECIALES + "/getSettingData/{servicio}");
            var response = client.Execute<List<ParametricaServicioEstandar>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public List<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUCondiciones + FUControllers.CONTROLLER_MS_FU_CONDCIONESESPECIALES + "/getSettingData/{servicio}");
            var response = client.Execute<List<ParametricaServicioReferencia>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public List<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUCondiciones + FUControllers.CONTROLLER_MS_FU_CONDCIONESESPECIALES + "/getBaseDatosEst/{tabla}");
            var response = client.Execute<List<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        public List<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUCondiciones + FUControllers.CONTROLLER_MS_FU_CONDCIONESESPECIALES + "/getBaseDatosRef/{tabla}");
            var response = client.Execute<List<ParametricasBdReferencia>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }
    }
}