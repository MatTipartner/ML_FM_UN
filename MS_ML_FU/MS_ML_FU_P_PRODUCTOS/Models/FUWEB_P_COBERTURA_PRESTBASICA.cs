//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MS_ML_FU_P_PRODUCTOS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FUWEB_P_COBERTURA_PRESTBASICA
    {
        public int ID_COBERTURA_PRESTBASICA { get; set; }
        public int ID_COBERTURA { get; set; }
        public int ID_PRESTACIONBASICA { get; set; }
        public string VIGENTE { get; set; }
    
        public virtual FUWEB_P_COBERTURA FUWEB_P_COBERTURA { get; set; }
        public virtual FUWEB_P_PRESTACIONBASICA FUWEB_P_PRESTACIONBASICA { get; set; }
    }
}
