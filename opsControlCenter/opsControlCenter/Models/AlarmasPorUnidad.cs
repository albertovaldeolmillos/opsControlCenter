namespace opsControlCenter.Models
{
    using System.ComponentModel;

    public partial class AlarmasPorUnidad
    {
        [DisplayName("UnidadId")]
        public decimal ALA_UNI_ID { get; set; }
        [DisplayName("TipoId")]
        public decimal DALA_ID { get; set; }
        [DisplayName("Tipo")]
        public string DALA_DESCSHORT{ get; set; }
        [DisplayName("Descripción")]
        public string DALA_DESCLONG { get; set; }
        [DisplayName("Fecha")]
        public System.DateTime ALA_INIDATE { get; set; }
        [DisplayName("Duración")]
        public string DIFF { get; set; }
        [DisplayName("Activa")]
        public string ACTIVE { get; set; }

    }
}