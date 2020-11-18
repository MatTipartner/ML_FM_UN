using System;
using System.Configuration;

namespace MS_ML_FU_DLL_DOMAIN.Domain.Dtos.General
{
    public class AppSettingsLectura
    {
        public  String rescatarValorAppSetting(String nombre) {
            return ConfigurationManager.AppSettings[nombre]; 
        }
    }
}
