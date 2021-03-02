using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer
{
    //[Table("AuditLog")]
    public class Log
    {

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(128)]
        public String TableName { get; set; }
        [Required]
        [MaxLength(50)]
        public String Action { get; set; }

        public String KeyValues { get; set; }
        public String OldValues { get; set; }
        public String NewValues { get; set; }



    }
}
