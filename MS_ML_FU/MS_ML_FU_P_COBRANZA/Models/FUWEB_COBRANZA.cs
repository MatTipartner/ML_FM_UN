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
    
    public partial class FUWEB_COBRANZA
    {
        public int ID_COBRANZA { get; set; }
        public Nullable<int> ID_TIPOFACTURACION { get; set; }
        public string SIGLA_COBROPRIMA { get; set; }
        public Nullable<int> ID_DESTINATARIOCOBRANZA { get; set; }
        public Nullable<int> ID_CALCULOPRIMA { get; set; }
        public Nullable<int> ID_TIPOPROCESOCOBRANZA { get; set; }
        public Nullable<int> DIAFRONTERA { get; set; }
        public string HES { get; set; }
        public string CONTRAPAGO { get; set; }
        public string PRECOBRANZA { get; set; }
        public string AUTOCOBRANZA { get; set; }
        public Nullable<int> ID_REPORTEFACTUACION { get; set; }
        public Nullable<int> ID_CONTABILIZACION { get; set; }
        public Nullable<int> ID_TIPOCOBRO { get; set; }
        public Nullable<int> DIACOBRO { get; set; }
        public Nullable<int> MESCOBRO { get; set; }
        public Nullable<int> MESCONVERSION { get; set; }
        public Nullable<int> DIACONVERSION { get; set; }
        public Nullable<int> NRO_POLIZA { get; set; }
    
        public virtual FUWEB_P_CALCULOPRIMA FUWEB_P_CALCULOPRIMA { get; set; }
        public virtual FUWEB_P_DESTINATARIOCOBRANZA FUWEB_P_DESTINATARIOCOBRANZA { get; set; }
        public virtual FUWEB_P_TIPOCOBRO FUWEB_P_TIPOCOBRO { get; set; }
        public virtual FUWEB_P_TIPOFACTURACIONCOBR FUWEB_P_TIPOFACTURACIONCOBR { get; set; }
    }
}
