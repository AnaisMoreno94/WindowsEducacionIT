using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WindowsEducacionIT.Models
{
    [Table("Planilla")]
    public class Planilla
    {
        public int Id{ get; set; }

        [Required]
        [Column(TypeName ="Date")]
        public DateTime Fecha { get; set; }

        public int IDCurso { get; set; }
        [ForeignKey("IDCurso")]
        public Curso Curso { get; set; }
       
        public int IDCarrera { get; set; }
        [ForeignKey("IDCarrera")]
        public Carrera Carrera { get; set; }

        public int IDMateria { get; set; }
        [ForeignKey("IDMateria")]
        public Materia Materia { get; set; }

        public int IDProfesor { get; set; }
        [ForeignKey("IDProfesor")]
        public Profesor Profesor { get; set; }


    }
}
