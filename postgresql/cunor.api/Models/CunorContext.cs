using Microsoft.EntityFrameworkCore;

namespace cunor.api.Models;

public class CunorContext : DbContext
{
    public DbSet<Curso> Curso { get; set; }

    public CunorContext(DbContextOptions options)
            : base(options)
    {

    }
}