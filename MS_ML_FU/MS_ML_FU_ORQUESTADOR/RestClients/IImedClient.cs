using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.IMED;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using System.Collections.Generic;

namespace MS_ML_FU_ORQUESTADOR.RestClients
{
    public interface IImedClient
    {

        IEnumerable<ParametricaServicioEstandar> GetSettingServercioEst(ServiciosParametrica servicio);

        IEnumerable<ParametricaServicioReferencia> GetSettingServercioRef(ServiciosParametrica servicio);

        IEnumerable<ParametricasBdEstandar> GetSettingBaseDatosEst(BaseDatosParametrica tabla);

        IEnumerable<ParametricasBdReferencia> GetSettingBaseDatosRef(BaseDatosParametrica tabla);

        IEnumerable<ParametricasBdEstandar> GetTipoProductoPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario);

        IEnumerable<ParametricasBdReferencia> GetDetalleProductoPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario);

        IEnumerable<ParametricasBdPrestacionParametrica> GetPrestacionesPorGrupo(BaseDatosParametrica tabla, int GrupoFormulario);

        IEnumerable<ParametricasBdEstandar> GetProducto(BaseDatosParametrica tabla);
    }
}