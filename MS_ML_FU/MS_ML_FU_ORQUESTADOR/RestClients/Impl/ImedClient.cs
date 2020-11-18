using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using RestSharp;
using System.Collections.Generic;


namespace MS_ML_FU_ORQUESTADOR.RestClients.Impl
{
    public class ImedClient: IImedClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();
        public IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUImed + FUControllers.CONTROLLER_MS_FU_IMED + "/getSettingData/{servicio}");
            var response = client.Execute<IEnumerable<ParametricaServicioEstandar>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public IEnumerable<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUImed + FUControllers.CONTROLLER_MS_FU_IMED + "/getSettingData/{servicio}");
            var response = client.Execute<IEnumerable<ParametricaServicioReferencia>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public IEnumerable<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUImed + FUControllers.CONTROLLER_MS_FU_IMED + "/getBaseDatosEstandar/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        public IEnumerable<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUImed + FUControllers.CONTROLLER_MS_FU_IMED + "/getBaseDatosReferencia/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdReferencia>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        public IEnumerable<ParametricasBdEstandar> GetProducto(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getBaseDatosEst/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        public IEnumerable<ParametricasBdEstandar> GetTipoProductoPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getBaseDatosEstPorGrupo/{tabla}/{GrupoFormulario}");
            var response = client.Execute<IEnumerable<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla).AddUrlSegment("GrupoFormulario", GrupoFormulario));
            return response.Data;
        }

        public IEnumerable<ParametricasBdReferencia> GetDetalleProductoPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getBaseDatosRefPorGrupo/{tabla}/{GrupoFormulario}");
            var response = client.Execute<IEnumerable<ParametricasBdReferencia>>(new RestRequest().AddUrlSegment("tabla", tabla).AddUrlSegment("GrupoFormulario", GrupoFormulario));
            return response.Data;
        }

        public IEnumerable<ParametricasBdPrestacionParametrica> GetPrestacionesPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getBaseDatosPrestaciones/{tabla}/{GrupoFormulario}");
            var response = client.Execute<IEnumerable<ParametricasBdPrestacionParametrica>>(new RestRequest().AddUrlSegment("tabla", tabla).AddUrlSegment("GrupoFormulario", GrupoFormulario));
            return response.Data;
        }
    }
}