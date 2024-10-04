using Microsoft.EntityFrameworkCore;
using Practico1LabFinal.Models;

namespace Practico1LabFinal.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ActorModel> Actores { get; set; }
        public DbSet<GeneroModel> Generos { get; set; }
        public DbSet<PeliculaModel> Peliculas { get; set; }
        public DbSet<PeliculaActorModel> PeliculasActores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeliculaActorModel>()
                .HasKey(pa => new { pa.PeliculaId, pa.PersonaId });
        }
    }
}
