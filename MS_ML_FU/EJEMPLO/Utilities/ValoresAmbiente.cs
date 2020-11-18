using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EJEMPLO.Utilities
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