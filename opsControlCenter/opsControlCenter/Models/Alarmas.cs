namespace opsControlCenter.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alarmas
    {
        public decimal Id { get; set; }
        public decimal IdTipo { get; set; }
        public string Tipo { get; set; }
        public decimal Unidad { get; set; }
        public System.DateTime Inicio { get; set; }

    }
}
