using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Parametros;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Parametros.Parametricas;


namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface IParametrosService
    {
        ParametroPestanaDto GetParametros(CabeceraJsonDto cabeceraDto);

        ParametricaParametroDetalle GetParametricasPärametros(int grupoFormulario);
    }
}
