using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Perfil;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil.Redireccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface IAccesoPerfilClient
    {
        PerfilUsuario GetPerfilAccesoPerfil(string siglaUsuario, int nroBizFlow, int idEstadoBisFlow);

        RedireccionPerfil GetPerfilAccesoDireccion(int nroBizFlow);
    }
}