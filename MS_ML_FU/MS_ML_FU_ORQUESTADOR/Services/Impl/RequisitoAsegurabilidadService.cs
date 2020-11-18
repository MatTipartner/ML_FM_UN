using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.RequisitoAsegurabilidad;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.RequisitoAsegurabilidad.Parametricas;
using MS_ML_FU_ORQUESTADOR.RestClients;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class RequisitoAsegurabilidadService : IRequisitoAsegurabilidadService
    {
        private IRequisitosAsegClient clientRequisitoAseg;
        public ReqAsegPestanaDto GetRequisitoAsegurabilidad(CabeceraJsonDto cabeceraDto) 
        {
            ReqAsegPestanaDto reqAsegPestana = new ReqAsegPestanaDto();
            reqAsegPestana.Cabecera = cabeceraDto;
            reqAsegPestana.Parametrica = this.GetParametricasRequisitoAseg(cabeceraDto.IdGrupoFormulario);
            return reqAsegPestana;
        }

        public ParametricaReqAseguDetalle GetParametricasRequisitoAseg(int grupoFormulario)
        {
            ParametricaReqAseguDetalle requisitoAsed = new ParametricaReqAseguDetalle();
            requisitoAsed.TipoProducto = this.clientRequisitoAseg.GetSettingBaseDatosEst(BaseDatosParametrica.TipoProducto, grupoFormulario);
            requisitoAsed.Cobertura = this.clientRequisitoAseg.GetSettingBaseDatosRef(BaseDatosParametrica.Cobertura, grupoFormulario);
            requisitoAsed.ExclusionAsegurabilidad = this.clientRequisitoAseg.GetSettingBaseDatosEst(BaseDatosParametrica.ExclusionAsegurabilidad, grupoFormulario);
            requisitoAsed.Relacion = this.clientRequisitoAseg.GetSettingServercioEst(ServiciosParametrica.Relacion, grupoFormulario);
            return requisitoAsed;
        }

        [Inject]
        public void SetApiRequisitoAsegurabilidad(IRequisitosAsegClient clientRequisitoAseg)
        {
            this.clientRequisitoAseg = clientRequisitoAseg;
        }
    }
}