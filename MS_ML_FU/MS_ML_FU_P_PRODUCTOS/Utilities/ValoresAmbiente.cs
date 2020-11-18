using System;
using System.Configuration;

namespace MS_ML_FU_P_PRODUCTOS.Utilities
{
    public class ValoresAmbiente
    {
        public String ServicioMetLife { get; set; }
        public String ClaveServicioMetLife { get; set; }
        public String UsuarioServicioMetLife { get; set; }

        public ValoresAmbiente()
        {
            var appSettings = ConfigurationManager.AppSettings;
            this.ServicioMetLife = appSettings["ServicioRestMetLife"];
            this.ClaveServicioMetLife = appSettings["ClaveServicioMetLife"];
            this.UsuarioServicioMetLife = appSettings["UsuarioServicioMetLife"];
        }
    }
}