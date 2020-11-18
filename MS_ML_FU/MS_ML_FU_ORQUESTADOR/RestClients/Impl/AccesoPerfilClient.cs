using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Perfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Redireccion;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using RestSharp;


namespace MS_ML_FU_ORQUESTADOR.RestClients.Impl
{
    public class AccesoPerfilClient: IAccesoPerfilClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();
       
        public PerfilUsuario GetPerfilAccesoPerfil(string siglaUsuario, int nroBizFlow, int idEstadoBisFlow)
        {                     
            var client = new RestClient(values.BaseUrlMSFUAccesoPerifl + FUControllers.CONTROLLER_MS_FU_ACCESOPERFIL + "/redireccion/{siglaUsuario}/{nroBizFlow}/{idEstadoBizFlow}");
            var response = client.Execute<PerfilUsuario>(new RestRequest().AddUrlSegment("siglaUsuario", siglaUsuario).AddUrlSegment("nroBizFlow", nroBizFlow).AddUrlSegment("idEstadoBizFlow", idEstadoBisFlow));
            return response.Data;
         
        }

        public RedireccionPerfil GetPerfilAccesoDireccion(int nroBizFlow)
        {
            var client = new RestClient(values.BaseUrlMSFUAccesoPerifl + FUControllers.CONTROLLER_MS_FU_ACCESOPERFIL + "/redireccion/{nroBizFlow}");
            var response = client.Execute<RedireccionPerfil>(new RestRequest().AddUrlSegment("nroBizFlow", nroBizFlow));
            return response.Data;
        }
    }
}