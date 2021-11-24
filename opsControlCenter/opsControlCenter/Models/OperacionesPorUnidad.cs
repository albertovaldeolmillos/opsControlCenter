namespace opsControlCenter.Models
{
    using System.ComponentModel;

    public partial class OperacionesPorUnidad
    {
        [DisplayName("UnidadId")]
        public decimal OPE_UNI_ID { get; set; }
        [DisplayName("Fecha")]
        public System.DateTime OPE_MOVDATE { get; set; }
        [DisplayName("Matrícula")]
        public string OPE_VEHICLEID{ get; set; }
        [DisplayName("TipoId")]
        public decimal OPE_DOPE_ID { get; set; }
        [DisplayName("Tipo")]
        public string DOPE_DESCSHORT { get; set; }
        [DisplayName("FormaPagoId")]
        public decimal OPE_DPAY_ID { get; set; }
        [DisplayName("FormaPago")]
        public string DPAY_DESCSHORT { get; set; }

    }
}