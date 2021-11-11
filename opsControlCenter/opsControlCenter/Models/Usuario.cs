using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opsControlCenter.Models
{
    public partial class Usuario
    {
        public decimal USR_ID { get; set; }
        public decimal USR_ROL_ID { get; set; }
        public string USR_LOGIN { get; set; }
        public string USR_PASSWORD { get; set; }
        public string ROL_DESCSHORT { get; set; }
    }
}