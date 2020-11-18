using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.PlanGrilla;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.PlanGrilla.Parametricas;
using MS_ML_FU_ORQUESTADOR.RestClients;
using Ninject;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class PlanGrillaService : IPlanGrillaService
    {
        private IPlanGrillaClient clientPlanGrilla;
        public PlanGrillaPestanaDto GetPlanGrilla(CabeceraJsonDto cabeceraDto)
        {
            PlanGrillaPestanaDto planGrillaPestana = new PlanGrillaPestanaDto();
            planGrillaPestana.Cabecera = cabeceraDto;
            planGrillaPestana.Parametrica = this.GetParametricasPlanGrilla(cabeceraDto.IdGrupoFormulario);
            return planGrillaPestana;
        }

        public ParametricasPlanGrillaDetalle GetParametricasPlanGrilla(int grupoFormulario)
        {
            ParametricasPlanGrillaDetalle planGrilla = new ParametricasPlanGrillaDetalle();
            planGrilla.TipoProducto = this.clientPlanGrilla.GetTipoProducto(BaseDatosParametrica.TipoProducto, grupoFormulario);
            planGrilla.Cobertura = this.clientPlanGrilla.GetDetalleProducto(BaseDatosParametrica.Cobertura, grupoFormulario);
            planGrilla.PrestacionBasica = this.clientPlanGrilla.GetDetalleProducto(BaseDatosParametrica.PrestacioBasica, grupoFormulario);
            planGrilla.Prestacion = this.clientPlanGrilla.GetPrestaciones(BaseDatosParametrica.Prestaciones, grupoFormulario);
            planGrilla.Nivel = this.clientPlanGrilla.GetSettingServercioEst(ServiciosParametrica.TipoAcumulacion);
            planGrilla.Isapre = this.clientPlanGrilla.GetSettingServercioEst(ServiciosParametrica.Isapre);
            planGrilla.GrupoPrestador = this.clientPlanGrilla.GetSettingBaseDatosEst(BaseDatosParametrica.PrestadoresGrupoFU);
            planGrilla.GrupoPrestadorSacs = this.clientPlanGrilla.GetSettingBaseDatosRef(BaseDatosParametrica.PrestadoresGrupoSacs);
            return planGrilla;
        }

        [Inject]
        public void SetApiProducto(IPlanGrillaClient clientPlanGrilla)
        {
            this.clientPlanGrilla = clientPlanGrilla;
        }
    }
}