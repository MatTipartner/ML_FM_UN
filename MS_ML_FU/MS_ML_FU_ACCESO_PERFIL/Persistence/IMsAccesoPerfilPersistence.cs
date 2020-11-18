using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Perfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Redireccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ACCESO_PERFIL.Persistence
{
    public interface IMsAccesoPerfilPersistence
    {
        int GetExistePoliza(int nroBizFlow);

        RedireccionPerfil GetRedireccion(String existeBizFlow);

        int GetAreaAsociadaNroBizFlow(int estadoBizFlow);

        UsuarioDto GetUsuario(String siglaUsuario);

        PerfilUsuario getPerfilUsuario(String siglaUsuario);

        List<Permisos> GetPermisoFormulario(int estadoFormulario, String siglaUsuario);

        int GetEstadoFomulario(int nroBizFlow);
      

    }
}