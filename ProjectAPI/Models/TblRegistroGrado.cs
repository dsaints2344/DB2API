using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class TblRegistroGrado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegistroGrado { get; set; }
        public TblMaestro Maestro { get; set; }
        public string Curso { get; set; }

        public int TblTipoGradoId { get; set; }
        public TblTipoGrado TipoGrado { get; set; }
    }
}
