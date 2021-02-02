using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContext dbContext;
        private readonly DbSet<Usuario> dbSet;

        public UsuarioRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<Usuario>();
        }

        public async Task<Usuario> GetAsync(int id) => await dbSet.FindAsync(id);
    }
}
