//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MS_ML_FU_P_COBRANZA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FUWEB_P_RIESGOFACTURACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUWEB_P_RIESGOFACTURACION()
        {
            this.FUWEB_COBRANZARIESGO = new HashSet<FUWEB_COBRANZARIESGO>();
        }
    
        public int ID_RIESGOFACTURACION { get; set; }
        public string NOMBRE { get; set; }
        public string VIGENTE { get; set; }
        public string SIGLA_SAC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_COBRANZARIESGO> FUWEB_COBRANZARIESGO { get; set; }
    }
}
