//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace opsControlCenter.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ALARMS_DEF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALARMS_DEF()
        {
            this.ALARMS = new HashSet<ALARMS>();
        }
    
        public decimal DALA_ID { get; set; }
        public string DALA_DESCSHORT { get; set; }
        public string DALA_DESCLONG { get; set; }
        public Nullable<decimal> DALA_LIT_ID { get; set; }
        public Nullable<decimal> DALA_DSTA_ID { get; set; }
        public decimal DALA_VERSION { get; set; }
        public decimal DALA_VALID { get; set; }
        public decimal DALA_DELETED { get; set; }
        public Nullable<decimal> DALA_DALV_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALARMS> ALARMS { get; set; }
    }
}
