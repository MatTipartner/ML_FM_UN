using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.PlanGrilla;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.RestClients.Impl
{
    public class PlanGrillaClient: IPlanGrillaClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();

        public IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUPlanGrilla + FUControllers.CONTROLLER_MS_FU_PLANGRILLA + "/getSettingData/{servicio}");
            var response = client.Execute<IEnumerable<ParametricaServicioEstandar>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public IEnumerable<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUPlanGrilla + FUControllers.CONTROLLER_MS_FU_PLANGRILLA + "/getSettingData/{servicio}");
            var response = client.Execute<IEnumerable<ParametricaServicioReferencia>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public IEnumerable<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUPlanGrilla + FUControllers.CONTROLLER_MS_FU_PLANGRILLA + "/getBaseDatosEst/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        public IEnumerable<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUPlanGrilla + FUControllers.CONTROLLER_MS_FU_PLANGRILLA + "/getBaseDatosRef/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdReferencia>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        public IEnumerable<ParametricasBdEstandar> GetTipoProducto(BaseDatosParametrica tabla, int GrupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getBaseDatosEstPorGrupo/{tabla}/{GrupoFormulario}");
            var response = client.Execute<IEnumerable<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla).AddUrlSegment("GrupoFormulario", GrupoFormulario));
            return response.Data;
        }

        public IEnumerable<ParametricasBdReferencia> GetDetalleProducto(BaseDatosParametrica tabla, int GrupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getBaseDatosRefPorGrupo/{tabla}/{GrupoFormulario}");
            var response = client.Execute<IEnumerable<ParametricasBdReferencia>>(new RestRequest().AddUrlSegment("tabla", tabla).AddUrlSegment("GrupoFormulario", GrupoFormulario));
            return response.Data;
        }

        public IEnumerable<ParametricasBdPrestacionParametrica> GetPrestaciones(BaseDatosParametrica tabla, int GrupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getBaseDatosPrestaciones/{tabla}/{GrupoFormulario}");
            var response = client.Execute<IEnumerable<ParametricasBdPrestacionParametrica>>(new RestRequest().AddUrlSegment("tabla", tabla).AddUrlSegment("GrupoFormulario", GrupoFormulario));
            return response.Data;
        }
    }
}