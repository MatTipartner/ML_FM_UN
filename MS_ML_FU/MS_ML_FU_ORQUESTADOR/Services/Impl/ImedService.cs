
using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.IMED;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.IMED.Parametricas;
using MS_ML_FU_ORQUESTADOR.RestClients;
using Ninject;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class ImedService : IImedService
    {
        private IImedClient clientImed;
        public ImedPestanaDto GetImed(CabeceraJsonDto cabeceraDto)
        {
            ImedPestanaDto imedPestana = new ImedPestanaDto();
            imedPestana.Cabecera = cabeceraDto;
            imedPestana.Parametrica = this.GetParametricasImed(cabeceraDto.IdGrupoFormulario);
            return imedPestana;
        }

        public ParametricaImedDetalle GetParametricasImed( int grupoFormulario)
        {
            ParametricaImedDetalle parametrica = new ParametricaImedDetalle();
            parametrica.TipoImed = this.clientImed.GetSettingBaseDatosEst(BaseDatosParametrica.TipoImed);
            parametrica.Frecuencia = this.clientImed.GetSettingBaseDatosEst(BaseDatosParametrica.Frecuencia);
            parametrica.PrestadoresFu = this.clientImed.GetSettingBaseDatosEst(BaseDatosParametrica.PrestadoresGrupoFU);
            parametrica.Cobertura = this.clientImed.GetDetalleProductoPorGrupo(BaseDatosParametrica.Cobertura, grupoFormulario);
            parametrica.PrestacionGenerica = this.clientImed.GetDetalleProductoPorGrupo(BaseDatosParametrica.PrestacionGenerica, grupoFormulario);
            parametrica.Prestaciones = this.clientImed.GetPrestacionesPorGrupo(BaseDatosParametrica.Prestaciones, grupoFormulario);            
            parametrica.PrestadoresSacs = this.clientImed.GetSettingBaseDatosRef(BaseDatosParametrica.PrestadoresGrupoSacs);            
            parametrica.TopeMonto = this.clientImed.GetSettingServercioEst(ServiciosParametrica.TopeMonto);
            parametrica.Subgrupo = this.clientImed.GetProducto(BaseDatosParametrica.SubGrupo);
            return parametrica;
        }

        [Inject]
        public void SetApiImed(IImedClient clientImed)
        {
            this.clientImed = clientImed;
        }
    }
}