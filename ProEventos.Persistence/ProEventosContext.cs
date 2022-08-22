using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>().HasKey(x => new { x.PalestranteId, x.EventoId});
           
            modelBuilder.Entity<Evento>()
                .HasMany(x => x.RedeSociais)
                .WithOne(x => x.Eventos)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                .HasMany(x => x.RedeSociais)
                .WithOne(x => x.Palestrantes)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
