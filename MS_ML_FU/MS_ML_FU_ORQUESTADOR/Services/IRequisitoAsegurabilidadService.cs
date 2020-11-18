using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.RequisitoAsegurabilidad;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.RequisitoAsegurabilidad.Parametricas;


namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface IRequisitoAsegurabilidadService
    { 

        ReqAsegPestanaDto GetRequisitoAsegurabilidad(CabeceraJsonDto cabeceraDto);

        ParametricaReqAseguDetalle GetParametricasRequisitoAseg(int grupoFormulario);
    }
}
