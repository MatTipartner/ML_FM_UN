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
    
    public partial class FUWEB_P_PRESTACIONBASICA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUWEB_P_PRESTACIONBASICA()
        {
            this.FUWEB_P_PRESTACIONBASICGENERIC = new HashSet<FUWEB_P_PRESTACIONBASICGENERIC>();
            this.FUWEB_P_COBERTURA_PRESTBASICA = new HashSet<FUWEB_P_COBERTURA_PRESTBASICA>();
        }
    
        public int ID_PRESTACIONBASICA { get; set; }
        public string NOMBRE { get; set; }
        public string VIGENTE { get; set; }
        public string SIGLA_SACS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_P_PRESTACIONBASICGENERIC> FUWEB_P_PRESTACIONBASICGENERIC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_P_COBERTURA_PRESTBASICA> FUWEB_P_COBERTURA_PRESTBASICA { get; set; }
    }
}
