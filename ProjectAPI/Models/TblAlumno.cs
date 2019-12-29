using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class TblAlumno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlumno { get; set; }

        public string NombreAlumno { get; set; }

        public string ApellidoAlumno { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")] 
        public DateTime FechaNacimiento { get; set; }

        public int tblRegistroGradoId { get; set; }
        public TblRegistroGrado RegistroGrado { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime FechaRegistro { get; set; }

        public int TblEstadoId { get; set; }
        public TblEstado Estado { get; set; }
    }
}
