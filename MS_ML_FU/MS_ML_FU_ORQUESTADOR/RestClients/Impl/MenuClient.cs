﻿using MS_ML_FU_DLL_DOMAIN.Domain.Constantes;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General.Parametricas;
using MS_ML_FU_DLL_DOMAIN.Domain.Dtos.Menu;
using MS_ML_FU_DLL_DOMAIN.Terceros.General;
using MS_ML_FU_ORQUESTADOR.Models.Environment;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MS_ML_FU_ORQUESTADOR.RestClients.Impl
{
    public class MenuClient:IMenuClient
    {
        private readonly EnvironmentValues values = new EnvironmentValues();
        public List<ParametricaServicioEstandar> GetParametrosMenuServicio(ServiciosParametrica servicio)
        {
            var client = new RestClient(values.BaseUrlMSFUMenu + FUControllers.CONTROLLER_MS_FU_MENU + "/getSettingDataEstandar/{servicio}");
            var response = client.Execute<List<ParametricaServicioEstandar>>(new RestRequest().AddUrlSegment("servicio", servicio));
            return response.Data;
        }

        public List<ParametricasBdEstandar> GetParametrosMenuBd(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUMenu + FUControllers.CONTROLLER_MS_FU_MENU + "/getBdEstandar/{tabla}");
            var response = client.Execute<List<ParametricasBdEstandar>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }

        public List<ParametricasBdReferencia> GetParametrosMenuBdRef(BaseDatosParametrica tabla)
        {
            var client = new RestClient(values.BaseUrlMSFUMenu + FUControllers.CONTROLLER_MS_FU_MENU + "/getBdReferencia/{tabla}");
            var response = client.Execute<List<ParametricasBdReferencia>>(new RestRequest().AddUrlSegment("tabla", tabla));
            return response.Data;
        }
        
    }
}