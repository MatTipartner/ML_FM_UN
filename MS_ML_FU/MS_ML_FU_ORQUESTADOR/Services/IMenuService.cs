using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Menu.Parametricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.Services
{
    public interface IMenuService
    {
        ParametricaMenu GetParametrosMenu();
    }
}