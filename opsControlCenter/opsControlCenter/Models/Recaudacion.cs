using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opsControlCenter.Models
{
    public partial class Recaudacion
    {
        public decimal COL_ID { get; set; }
        public decimal COL_UNI_ID { get; set; }
        public decimal COL_NUM { get; set; }
        public Nullable<System.DateTime> COL_DATE { get; set; }
        public System.DateTime COL_INIDATE { get; set; }
        public System.DateTime COL_ENDDATE { get; set; }
        public decimal COL_BACK_COL_TOTAL { get; set; }
        public string COL_COIN_SYMBOL { get; set; }
    }
}