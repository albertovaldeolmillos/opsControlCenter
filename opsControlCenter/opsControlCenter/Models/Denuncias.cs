using System;
using System.ComponentModel;

namespace opsControlCenter.Models
{
    public class Denuncias
    {
        [DisplayName("Id")]
        public decimal FIN_ID { get; set; }
        [DisplayName("TipoId")]
        public decimal FIN_DFIN_ID { get; set; }
        [DisplayName("Tipo")]
        public string DFIN_DESCSHORT { get; set; }
        [DisplayName("Matricula")]
        public string FIN_VEHICLEID { get; set; }
        [DisplayName("Modelo")]
        public string FIN_MODEL { get; set; }
        [DisplayName("marca")]
        public string FIN_MANUFACTURER { get; set; }
        [DisplayName("Color")]
        public string FIN_COLOUR { get; set; }
        [DisplayName("CalleId")]
        public Nullable<decimal> FIN_STR_ID { get; set; }
        [DisplayName("CalleId")]
        public string STR_DESC { get; set; }
        [DisplayName("Numero")]
        public Nullable<decimal> FIN_STRNUMBER { get; set; }
        [DisplayName("Fecha")]
        public System.DateTime FIN_DATE { get; set; }
        [DisplayName("Comentario")]
        public string FIN_COMMENTS { get; set; }
        [DisplayName("UsuarioId")]
        public Nullable<decimal> FIN_USR_ID { get; set; }
        [DisplayName("Usuario")]
        public string USR_NAME { get; set; }
        [DisplayName("UnidadId")]
        public decimal FIN_UNI_ID { get; set; }
        [DisplayName("PDA")]
        public string UNI_DESCSHORT { get; set; }
        [DisplayName("StatusId")]
        public Nullable<decimal> FIN_STATUS { get; set; }
        [DisplayName("EstadoDetalle")]
        public string DSFIN_DESCSHORT { get; set; }
        [DisplayName("StatusAdmonId")]
        public decimal FIN_STATUSADMON { get; set; }
        [DisplayName("EstadoAdministrativo")]
        public string DSAFIN_DESCSHORT { get; set; }

    }
}