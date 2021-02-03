using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbConfiguration.EfCore
{
    public class ImdbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Voto> Votos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=ImdbIoasys;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voto>()
                .HasOne(voto => voto.Filme)
                .WithMany(filme => filme.Votos)
                .HasForeignKey(s => s.FilmeId);

            modelBuilder.Entity<Voto>()
                .HasOne(voto => voto.Usuario)
                .WithMany(usuario => usuario.Votos)
                .HasForeignKey(s => s.UsuarioId);
        }
    }
}
