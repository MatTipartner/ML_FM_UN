//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MS_ML_FU_ACCESO_PERFIL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FUWEB_P_TIPOFORMULARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUWEB_P_TIPOFORMULARIO()
        {
            this.FUWEB_P_TIPOFORMULARIODETALLE = new HashSet<FUWEB_P_TIPOFORMULARIODETALLE>();
            this.FUWEB_PERMISOESTADO = new HashSet<FUWEB_PERMISOESTADO>();
        }
    
        public int ID_TIPOFORMULARIO { get; set; }
        public string NOMBRE { get; set; }
        public string VIGENTE { get; set; }
        public string VISIBLE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_P_TIPOFORMULARIODETALLE> FUWEB_P_TIPOFORMULARIODETALLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_PERMISOESTADO> FUWEB_PERMISOESTADO { get; set; }
    }
}
