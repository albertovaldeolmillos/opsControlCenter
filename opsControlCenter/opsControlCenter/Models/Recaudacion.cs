using System;
using System.ComponentModel;

namespace opsControlCenter.Models
{
    public partial class Recaudacion
    {
        [DisplayName("Id")]
        public decimal COL_ID { get; set; }
        [DisplayName("UnidadId")]
        public decimal COL_UNI_ID { get; set; }
        [DisplayName("unidad")]
        public string UNI_DESCSHORT { get; set; }
        [DisplayName("Número")]
        public decimal COL_NUM { get; set; }
        [DisplayName("Fecha")]
        public Nullable<System.DateTime> COL_DATE { get; set; }
        [DisplayName("Inicio")]
        public System.DateTime COL_INIDATE { get; set; }
        [DisplayName("Fin")]
        public System.DateTime COL_ENDDATE { get; set; }
        [DisplayName("Total")]
        public decimal COL_BACK_COL_TOTAL { get; set; }
        [DisplayName("Moneda")]
        public string COL_COIN_SYMBOL { get; set; }
    }
}