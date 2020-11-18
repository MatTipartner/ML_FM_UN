using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Credenciales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_ML_FU_CREDENCIALES.Persistence
{
    public interface IMsCredencialesPersistence
    {
        CredencialDto GetCredencialPorUsuario(String usuario);

        List<CredencialDto> GetCredencialesPorBizflow(Nullable<decimal> numeroBizflow);

        Boolean CrearCredencial(CredencialDto credencial);

        Boolean ActualizarCredencial(CredencialDto credencial);

        Boolean EliminarCredencialUsuario(String usuario);

    }
}
