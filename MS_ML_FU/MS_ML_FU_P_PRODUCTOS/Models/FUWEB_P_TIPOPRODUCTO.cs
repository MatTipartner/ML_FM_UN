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
    
    public partial class FUWEB_P_TIPOPRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUWEB_P_TIPOPRODUCTO()
        {
            this.FUWEB_P_COBERTURA = new HashSet<FUWEB_P_COBERTURA>();
            this.FUWEB_PRODUCTOCASCADA = new HashSet<FUWEB_PRODUCTOCASCADA>();
        }
    
        public int ID_TIPOPRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public string VIGENTE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_P_COBERTURA> FUWEB_P_COBERTURA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_PRODUCTOCASCADA> FUWEB_PRODUCTOCASCADA { get; set; }
    }
}
