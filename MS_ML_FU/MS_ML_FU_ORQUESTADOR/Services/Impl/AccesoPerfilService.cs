
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using MS_ML_FU_ORQUESTADOR.RestClients;
using Ninject;


namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class AccesoPerfilService: IAccesoPerfilService
    {
        private IAccesoPerfilClient clienteAccesoPerfil;
        public AccesoPerfilDto GetPerfilAcceso(string siglaUsuario, int nroBizFlow, int idEstadoBisFlow) {
            AccesoPerfilDto accPerfil = new AccesoPerfilDto();
            accPerfil.Direccion = clienteAccesoPerfil.GetPerfilAccesoDireccion(nroBizFlow);
            accPerfil.PerfilUsuario = clienteAccesoPerfil.GetPerfilAccesoPerfil(siglaUsuario, nroBizFlow, idEstadoBisFlow);
            return accPerfil;
        }

        [Inject]
        public void SetClientControlAcceso(IAccesoPerfilClient clienteAccesoPerfil)
        {
            this.clienteAccesoPerfil = clienteAccesoPerfil;
        }
    }
}