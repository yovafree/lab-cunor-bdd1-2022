using Microsoft.EntityFrameworkCore;
using cunor.api.Models;

namespace cunor.api.Models;

public class CunorContext : DbContext
{
    public DbSet<Curso> Curso { get; set; }

    public DbSet<Colaborador> Colaborador { get; set; }

    public CunorContext(DbContextOptions options)
            : base(options)
    {

    }

    public DbSet<cunor.api.Models.Estudiante> Estudiante { get; set; }

    public DbSet<cunor.api.Models.Puesto> Puesto { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Addd the Postgres Extension for UUID generation
            modelBuilder.HasPostgresExtension("uuid-ossp");
        }
}