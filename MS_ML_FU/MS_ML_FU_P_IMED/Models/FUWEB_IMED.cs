//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MS_ML_FU_P_IMED.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FUWEB_IMED
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUWEB_IMED()
        {
            this.FUWEB_IMEDFRECUENCIA = new HashSet<FUWEB_IMEDFRECUENCIA>();
            this.FUWEB_IMEDPRESTADORES = new HashSet<FUWEB_IMEDPRESTADORES>();
            this.FUWEB_IMEDPRESTADORESEXCEPCION = new HashSet<FUWEB_IMEDPRESTADORESEXCEPCION>();
            this.FUWEB_IMEDTOPEMONTO = new HashSet<FUWEB_IMEDTOPEMONTO>();
        }
    
        public int ID_IMED { get; set; }
        public int ID_TIPOIMED { get; set; }
        public int ID_AGRUPACION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_IMEDFRECUENCIA> FUWEB_IMEDFRECUENCIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_IMEDPRESTADORES> FUWEB_IMEDPRESTADORES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_IMEDPRESTADORESEXCEPCION> FUWEB_IMEDPRESTADORESEXCEPCION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_IMEDTOPEMONTO> FUWEB_IMEDTOPEMONTO { get; set; }
        public virtual FUWEB_P_TIPOIMED FUWEB_P_TIPOIMED { get; set; }
    }
}
