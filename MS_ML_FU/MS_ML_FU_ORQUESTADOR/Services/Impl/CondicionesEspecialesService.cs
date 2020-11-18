using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.CondicionEspecial;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.CondicionEspecial.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Convenios;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_ORQUESTADOR.RestClients;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class CondicionesEspecialesService : ICondicionesEspecialesService
    {
        private ICondicionesEspecialesClient clientCondicionEspecial;
        public CondEspecPestanaDto GetCondicionEspecial(CabeceraJsonDto cabeceraDto)
        {
            CondEspecPestanaDto condEspecialPestana = new CondEspecPestanaDto();
            condEspecialPestana.Cabecera = cabeceraDto;
            condEspecialPestana.Parametrica = this.GetParametricasCondicionEspecial();
            return condEspecialPestana;
        }

        public ParametricasCondEspecDetalle GetParametricasCondicionEspecial()
        {
            ParametricasCondEspecDetalle condicionEspecial = new ParametricasCondEspecDetalle();

            return condicionEspecial;
        }

        [Inject]
        public void SetApiCondicionEspecial(ICondicionesEspecialesClient clientCondicionEspecial)
        {
            this.clientCondicionEspecial = clientCondicionEspecial;
        }
    }
}