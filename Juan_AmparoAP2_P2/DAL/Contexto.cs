using Microsoft.EntityFrameworkCore;
using Juan_AmparoAP2_P2.Models;
using Juan_AmparoAP2_P2.Services;

namespace Juan_AmparoAP2_P2.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<TiposPuntos> TiposPuntos { get; set; }
        public DbSet<AsignacionesPuntos> AsignacionesPuntos { get; set; }
        public DbSet<AsignacionesPuntosDetalle> AsignacionesPuntosDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estudiantes>().HasData(
                new Estudiantes { EstudianteId = 1, Nombres = "Ana Martinez", Email = "ana@yomail.com", Edad = 20, BalancePuntos = 0 },
                new Estudiantes { EstudianteId = 2, Nombres = "Carlos Perez", Email = "carlos@yopmail.com", Edad = 22, BalancePuntos = 0 },
                new Estudiantes { EstudianteId = 3, Nombres = "Laura Rodriguez", Email = "laura@yopmail.com", Edad = 21, BalancePuntos = 0 }
            );

            modelBuilder.Entity<TiposPuntos>().HasData(
                new TiposPuntos { TipoId = 1, Nombre = "Participacion", Descripcion = "Participacion en clase", ValorPuntos = 5, Color = "primary", Icono = "bi-hand-thumbs-up", Activo = true },
                new TiposPuntos { TipoId = 2, Nombre = "Tarea Entregada", Descripcion = "Entrega de tarea", ValorPuntos = 10, Color = "success", Icono = "bi-journal-check", Activo = true },
                new TiposPuntos { TipoId = 3, Nombre = "Proyecto", Descripcion = "Entrega de proyecto", ValorPuntos = 20, Color = "warning", Icono = "bi-lightbulb", Activo = true }
            );
        }
    }
}