using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Perfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Redireccion;
using System;

namespace MS_ML_FU_ACCESO_PERFIL.Services
{
    public interface IMsAccesoPerfilServices
    {
        PerfilUsuario GetPerfilAccesoPerfil(string siglaUsuario, int nroBizFlow, int idEstadoBisFlow);

        RedireccionPerfil GetPerfilAccesoDireccion(int nroBizFlow);

        UsuarioDto GetUsuario(String siglaUsuario);

    }
}