using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.AccesoPerfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_CREDENCIALES.RestClients
{
    public interface IMsCredencialesClient
    {
        UsuarioDto GetUsuario(String siglaUsuario);
    }
}
