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
    
    public partial class FUWEB_P_DESTINATARIOCOBRANZA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUWEB_P_DESTINATARIOCOBRANZA()
        {
            this.FUWEB_COBRANZA = new HashSet<FUWEB_COBRANZA>();
        }
    
        public int ID_DESTINATARIOCOBRANZA { get; set; }
        public string NOMBRE { get; set; }
        public string VIGENTE { get; set; }
        public int NRO_SAC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUWEB_COBRANZA> FUWEB_COBRANZA { get; set; }
    }
}
