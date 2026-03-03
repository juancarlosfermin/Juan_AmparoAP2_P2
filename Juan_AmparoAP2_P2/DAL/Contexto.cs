using Microsoft.EntityFrameworkCore;
using Juan_AmparoAP2_P2.Models;

namespace Juan_AmparoAP2_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

    public DbSet<ViajesEspaciales> ViajesEspaciales { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ViajesEspaciales>().ToTable("ViajesEspaciales");
    }
}