using MS_ML_FU_ACCESO_PERFIL.Persistence;
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Perfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Redireccion;
using Ninject;
using System;

namespace MS_ML_FU_ACCESO_PERFIL.Services.Impl
{
    public class MsAccesoPerfilServices:IMsAccesoPerfilServices
    {
        private IMsAccesoPerfilPersistence persistenceAccesoPerfil;

        public PerfilUsuario GetPerfilAccesoPerfil(string siglaUsuario, int nroBizFlow, int idEstadoBisFlow)
        {
            PerfilUsuario perUsuario = new PerfilUsuario();
            var estadoFormulario = 0;
            var areaAsocBizFlow = this.persistenceAccesoPerfil.GetAreaAsociadaNroBizFlow(idEstadoBisFlow);
            UsuarioDto usuario = this.persistenceAccesoPerfil.GetUsuario(siglaUsuario);
            var areaPorUsuario = usuario.ID_AREA;

            if (areaPorUsuario < areaAsocBizFlow) {
                estadoFormulario = (int)ServiciosParametrica.Ocupado;
            } else if (areaPorUsuario == areaAsocBizFlow) {
                var existePoliza = this.persistenceAccesoPerfil.GetExistePoliza(nroBizFlow);
                if (existePoliza == 0){
                    estadoFormulario = (int)ServiciosParametrica.Disponible;
                }else{
                    estadoFormulario = this.persistenceAccesoPerfil.GetEstadoFomulario(nroBizFlow);
                }
            }

            if (estadoFormulario > 0) {
                perUsuario.PermisoPestana = this.persistenceAccesoPerfil.GetPermisoFormulario(estadoFormulario, siglaUsuario);
                perUsuario.siglaUsuario = usuario.SIGLA_USUARIO;
                perUsuario.NombreUsuario = usuario.NOMBRE;
                perUsuario.NroBizflow = nroBizFlow;
                

            }            
            return perUsuario;
        }

        public RedireccionPerfil GetPerfilAccesoDireccion(int nroBizFlow)
        {           
            return this.persistenceAccesoPerfil.GetRedireccion(this.persistenceAccesoPerfil.GetExistePoliza(nroBizFlow).ToString());
        }

        public UsuarioDto GetUsuario(String siglaUsuario)
        {
            return this.persistenceAccesoPerfil.GetUsuario(siglaUsuario);
        }

        /*************************************************/

        [Inject]
        public void SetPercistenciaAccesoPerfil(IMsAccesoPerfilPersistence persistenceAccesoPerfil)
        {
            this.persistenceAccesoPerfil = persistenceAccesoPerfil;
        }

    }
}