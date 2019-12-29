using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectAPI.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<TblEstado>()
            //     .HasOne(a => a.Alumno)
            //     .WithOne(a => a.Estado)
            //     .HasForeignKey<TblEstado>(a => a.IdEstado);

        }

        public DbSet<TblAlumno> Alumnos { get; set; }
        public DbSet<TblRegistroGrado> RegistroGrados { get; set; }
        public DbSet<TblTipoGrado> TipoGrados { get; set; }
        public DbSet<TblEstado> Estados { get; set; }
        public DbSet<TblMaestro> Maestros { get; set; }

    }
}
