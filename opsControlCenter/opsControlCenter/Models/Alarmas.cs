namespace opsControlCenter.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alarmas
    {
        public decimal ALA_ID { get; set; }
        public decimal ALA_DALA_ID { get; set; }
        public string Tipo { get; set; }
        public decimal ALA_UNI_ID { get; set; }
        public string Unidad { get; set; }
        public System.DateTime ALA_INIDATE { get; set; }

    }
}
