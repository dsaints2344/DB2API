using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class TblMaestro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMaestro { get; set; }
        public string NombreMaestro { get; set; }
        public string ApellidoMaestro { get; set; }

        public virtual ICollection<TblRegistroGrado> TblRegistroGrados { get; set; }
    }
}
