using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.DtoMapper.Producto;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Productos;
using MS_ML_FU_DLL_DOMAIN.Domain.Utilidades.Serializacion;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;


namespace MS_ML_FU_ORQUESTADOR.RestClients.Impl
{
    public class ProductosClient: IProductosClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();
       

        public IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getSettingData/{servicio}");
            var response = client.Execute<IEnumerable<ParametricaServicioEstandar>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public IEnumerable<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getSettingDataRef/{servicio}");
            var response = client.Execute<IEnumerable<ParametricaServicioReferencia>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public IEnumerable<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getBaseDatosEst/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        public IEnumerable<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getBaseDatosRef/{tabla}");
            var response = client.Execute<IEnumerable<ParametricasBdReferencia>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }
        public IEnumerable<ParametricasBdEstandar> GetTipoProductoPorGrupo(BaseDatosParametrica tabla, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getBaseDatosEstPorGrupo/{tabla}/{GrupoFormulario}");
            var response = client.Execute<IEnumerable<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla).AddUrlSegment("GrupoFormulario", grupoFormulario));
            return response.Data;
        }

        public IEnumerable<ParametricasBdReferencia> GetCoberturaPorGrupo(BaseDatosParametrica tabla, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getBaseDatosRefPorGrupo/{tabla}/{GrupoFormulario}");
            var response = client.Execute<IEnumerable<ParametricasBdReferencia>>(new RestRequest().AddUrlSegment("tabla", tabla).AddUrlSegment("GrupoFormulario", grupoFormulario));
            return response.Data;
        }
        /*
      * Ver comentario en la clase JsonNetSerializer en DOMAIN
      */
        [System.Obsolete]
        public ProductoVidaApDtoMapper GetProductoVidaAp(int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getProductoVidaAp/{grupoFormulario}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<ProductoVidaApDtoMapper>(new RestRequest().AddUrlSegment("grupoFormulario", grupoFormulario));
            return response.Data;
        }
        /*
       * Ver comentario en la clase JsonNetSerializer en DOMAIN
       */
        [System.Obsolete]
        public IEnumerable<CascadaDtoMapper> GetCascada(int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getCascada/{GrupoFormulario}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<IEnumerable<CascadaDtoMapper>>(new RestRequest().AddUrlSegment("GrupoFormulario", grupoFormulario));
            return response.Data;
        }
        /*
          * Ver comentario en la clase JsonNetSerializer en DOMAIN
          */
        [System.Obsolete]
        public IEnumerable<ProductoVidaApDetalleDtoMapper> GetProductoListaVidaAp(int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getProductoListaVidaAp/{GrupoFormulario}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<IEnumerable<ProductoVidaApDetalleDtoMapper>>(new RestRequest().AddUrlSegment("GrupoFormulario", grupoFormulario));
            return response.Data;
        }
        /*
       * Ver comentario en la clase JsonNetSerializer en DOMAIN
       */
        [System.Obsolete]
        public IEnumerable<ProductoSaludDetalleDtoMapper> GetProductoListaSalud(int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/getProductoListaSalud/{GrupoFormulario}").UseSerializer(new JsonNetSerializer());
            var response = client.Execute<IEnumerable<ProductoSaludDetalleDtoMapper>>(new RestRequest().AddUrlSegment("GrupoFormulario", grupoFormulario));
            return response.Data;
        }

        public Boolean SetListaVidaAps(IEnumerable<ProductoVidaApDetalleDtoMapper> listaVidaAp, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/setListaVidaAp/{GrupoFormulario}");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(listaVidaAp);
            request.AddJsonBody(json);
            request.AddUrlSegment("GrupoFormulario", grupoFormulario);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }


        public Boolean SetListaSalud(IEnumerable<ProductoSaludDetalleDtoMapper> listaSalud, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/setListaSalud/{GrupoFormulario}");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(listaSalud);
            request.AddJsonBody(json);
            request.AddUrlSegment("GrupoFormulario", grupoFormulario);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }

        public Boolean SetListaCascada(IEnumerable<CascadaDtoMapper> cascada, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/setListaCascada/{GrupoFormulario}");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(cascada);
            request.AddJsonBody(json);
            request.AddUrlSegment("GrupoFormulario", grupoFormulario);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }

        public Boolean SetVidaAp(ProductoVidaApDtoMapper vidaAp, int grupoFormulario)
        {
            var client = new RestClient(values.BaseUrlMSFUProductos + FUControllers.CONTROLLER_MS_FU_PRODUCTO + "/setVidaAp/{GrupoFormulario}");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            string json = JsonConvert.SerializeObject(vidaAp);
            request.AddJsonBody(json);
            request.AddUrlSegment("GrupoFormulario", grupoFormulario);
            var response = client.Execute<Boolean>(request);
            return response.Data;
        }
    }
}