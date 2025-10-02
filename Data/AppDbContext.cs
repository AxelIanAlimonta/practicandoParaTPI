using Microsoft.EntityFrameworkCore;

namespace practicandoParaTPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Persona> Personas { get; set; }
}
