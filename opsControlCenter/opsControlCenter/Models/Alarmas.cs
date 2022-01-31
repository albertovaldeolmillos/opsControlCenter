namespace opsControlCenter.Models
{
    using System;
    using System.ComponentModel;

    public partial class Alarmas
    {
        [DisplayName("Id")]
        public decimal ALA_ID { get; set; }
        [DisplayName("TipoId")]
        public decimal ALA_DALA_ID { get; set; }
        [DisplayName("Tipo")]
        public string DALA_DESCSHORT { get; set; }
        [DisplayName("UnidadId")]
        public decimal ALA_UNI_ID { get; set; }
        [DisplayName("Unidad")]
        public string UNI_DESCSHORT { get; set; }
        [DisplayName("Inicio")]
        public System.DateTime ALA_INIDATE { get; set; }
        [DisplayName("Nivel")]
        public Nullable<decimal> DALA_DALV_ID { get; set; }
    }
}
