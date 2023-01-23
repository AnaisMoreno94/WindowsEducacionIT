using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsEducacionIT.Models
{
    [Table("Detalle")]
    public class Detalle
    {
        public int Id { get; set; }

        public int IDEstado { get; set; }
        [ForeignKey("IDEstado")]
        public Estado Estado { get; set; }

        public int IDPlanilla { get; set; }
        [ForeignKey("IDPlanilla")]
        public Planilla Planilla { get; set; }

    }
}
