using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MS_ML_FU_CREDENCIALES.Models.Environment
{
    public class EnvironmentValues
    {
        public string BaseUrlMSFUAccesoPerfil { get; set; }
        public string BizflowUserGeneralKey { get; set; }
        public Int16 ExpiracionTokenAcceso { get; set; }
        public Int16 ExpiracionTokenRefresco { get; set; }

        public EnvironmentValues()
        {
            var appSettings = ConfigurationManager.AppSettings;
            this.BaseUrlMSFUAccesoPerfil = appSettings["BASE_URL_MS_FU_ACCESOPERFIL"];
            this.BizflowUserGeneralKey = appSettings["BIZFLOW_USER_GENERAL_KEY"];
            this.ExpiracionTokenAcceso = Int16.Parse(appSettings["EXPIRACION_TOKEN_ACCESO"]);
            this.ExpiracionTokenRefresco = Int16.Parse(appSettings["EXPIRACION_TOKEN_REFRESCO"]);
        }

    }
}