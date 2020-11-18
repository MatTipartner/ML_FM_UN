using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Parametros;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Parametros.Parametricas;
using MS_ML_FU_ORQUESTADOR.RestClients;
using Ninject;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class ParametrosService : IParametrosService
    {
        private IParametrosClient clientParametros;
        public ParametroPestanaDto GetParametros(CabeceraJsonDto cabeceraDto)
        {
            ParametroPestanaDto pParametros = new ParametroPestanaDto();
            pParametros.Cabecera = cabeceraDto;
            pParametros.Parametrica = this.GetParametricasPärametros(cabeceraDto.IdGrupoFormulario);
            return pParametros;
        }

        public ParametricaParametroDetalle GetParametricasPärametros(int grupoFormulario)
        {
            ParametricaParametroDetalle parametros = new ParametricaParametroDetalle();
            parametros.TipoProducto = this.clientParametros.GetSettingBaseDatosEst(BaseDatosParametrica.TipoProducto, grupoFormulario);
            parametros.cobertura = this.clientParametros.GetSettingBaseDatosRef(BaseDatosParametrica.Cobertura, grupoFormulario);
            parametros.PrestacionBasica = this.clientParametros.GetSettingBaseDatosRef(BaseDatosParametrica.PrestacioBasica, grupoFormulario);
            parametros.GrupoIsapre = this.clientParametros.GetSettingBaseDatosEst(BaseDatosParametrica.GrupoIsapre, grupoFormulario);
            parametros.Prestadores = this.clientParametros.GetSettingBaseDatosEst(BaseDatosParametrica.PrestadoresGrupoFU, grupoFormulario);
            parametros.TipoDeducible = this.clientParametros.GetSettingBaseDatosEst(BaseDatosParametrica.TipoDedicule, grupoFormulario);
            parametros.Aquien = this.clientParametros.GetSettingBaseDatosEst(BaseDatosParametrica.AquienParametros, grupoFormulario);
            parametros.FormaPago = this.clientParametros.GetSettingServercioEst(ServiciosParametrica.FormaPago, grupoFormulario);
            parametros.Beneficiarios = this.clientParametros.GetSettingServercioEst(ServiciosParametrica.Beneficiarios, grupoFormulario);
            parametros.TipoComision = this.clientParametros.GetSettingServercioEst(ServiciosParametrica.TipoComision, grupoFormulario);
            parametros.NombreCorredor = this.clientParametros.GetSettingServercioEst(ServiciosParametrica.Corredor, grupoFormulario);
            return parametros;
        }

        [Inject]
        public void SetApiParametro(IParametrosClient clientParametros)
        {
            this.clientParametros = clientParametros;
        }

    }
}