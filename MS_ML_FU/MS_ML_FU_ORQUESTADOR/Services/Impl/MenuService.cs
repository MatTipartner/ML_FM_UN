using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Menu.Parametricas;
using MS_ML_FU_ORQUESTADOR.RestClients;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.Services.Impl
{
    public class MenuService: IMenuService
    {
        private IMenuClient clienteMenu;
        public ParametricaMenu GetParametrosMenu() {
            ParametricaMenu parametricaMenu = new ParametricaMenu();
            parametricaMenu.parametrica = new ParametricaMenuDetalle();
            parametricaMenu.parametrica.LugarDespacho = this.clienteMenu.GetParametrosMenuServicio(ServiciosParametrica.LugarDespacho);
            parametricaMenu.parametrica.Ubicacion = this.clienteMenu.GetParametrosMenuServicio(ServiciosParametrica.Ubicacion);
            parametricaMenu.parametrica.TipoFormulario = this.clienteMenu.GetParametrosMenuBd(BaseDatosParametrica.TipoFormulario);
            parametricaMenu.parametrica.TipoFormularioDetalle = this.clienteMenu.GetParametrosMenuBdRef(BaseDatosParametrica.TipoFormularioDetalle);
            return parametricaMenu;
        }

        [Inject]
        public void SetClientMenu(IMenuClient clienteMenu)
        {
            this.clienteMenu = clienteMenu;
        }
    }
}