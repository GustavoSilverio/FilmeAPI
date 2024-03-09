using FilmeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
        {
        }

        public DbSet<Filme> Filme { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Sessao> Sessao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>()
                .HasOne(c => c.Endereco)
                .WithOne(e => e.Cinema)
                .HasForeignKey<Cinema>(c => c.IdEndereco);

            modelBuilder.Entity<Sessao>()
                .HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId });

            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                 .WithMany(cinema => cinema.Sessoes)
                 .HasForeignKey(sessao => sessao.CinemaId);

            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                 .WithMany(filme => filme.Sessoes)
                 .HasForeignKey(sessao => sessao.FilmeId);
            
            modelBuilder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
