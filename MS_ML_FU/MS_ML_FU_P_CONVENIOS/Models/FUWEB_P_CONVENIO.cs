//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MS_ML_FU_P_CONVENIOS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FUWEB_P_CONVENIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUWEB_P_CONVENIO()
        {
            this.FUWEB_CONVENIOOTROS = new HashSet<FUWEB_CONVENIOOTROS>();
            this.FUWEB_CONVENIOFARMACIA = new HashSet<FUWEB_CONVENIOFARMACIA>();
        }
    
        public int ID_CONVENIO { get; set; }
        public string NOMBRE { get; set; }
        public string VIGENTE { get; set; }
        public int ID_TIPOCONVENIO { get; set; }
        public Nullable<int> NRO_SACS { get; set; }
        public Nullable<int> ORDEN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_CONVENIOOTROS> FUWEB_CONVENIOOTROS { get; set; }
        public virtual FUWEB_P_TIPOCONVENIO FUWEB_P_TIPOCONVENIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_CONVENIOFARMACIA> FUWEB_CONVENIOFARMACIA { get; set; }
    }
}
