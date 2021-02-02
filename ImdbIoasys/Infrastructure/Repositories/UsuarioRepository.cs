using Domain.Entities;
using GlobalUtils;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Usuario> dbSet;

        public UsuarioRepository(DbContext dbContext)
        {
            _context = dbContext;
            dbSet = _context.Set<Usuario>();
        }

        public async Task<Usuario> GetAsync(int id) => await dbSet.FindAsync(id);

        public async Task<IEnumerable<Usuario>> ListAsync() => await dbSet.ToListAsync();

        public async Task Alterar(Usuario usuario)
        {
            var usuarioAntigo = await GetAsync(usuario.UsuarioId);
            _context.Entry(usuarioAntigo).State = EntityState.Detached;

            usuario.Senha = !string.IsNullOrEmpty(usuario.Senha) ? usuario.Senha.Criptografar() : usuarioAntigo.Senha;
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UsuarioExiste(int usuarioId) => await dbSet.AnyAsync(usuario => usuario.UsuarioId == usuarioId);

        public async Task Incluir(Usuario usuario)
        {
            usuario.Senha = usuario.Senha.Criptografar();
            
            dbSet.Add(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
