using ImdbIoasys.Models;
using Microsoft.EntityFrameworkCore;

namespace ImdbIoasys.Data
{
    public class ImdbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=ImdbIoasys;Trusted_Connection=True;");
        }
    }
}
