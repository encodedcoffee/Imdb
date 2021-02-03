using Domain.Entities;
using GlobalUtils;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<Usuario> GetAsync(Expression<Func<Usuario, bool>> expressao) => await dbSet.FirstOrDefaultAsync(expressao);

        public async Task<IEnumerable<Usuario>> ListAsync(int pagina) {
            const int tamanhoPagina = 10;
            var usuarios = await (
                                    pagina > 0 
                                    ? dbSet.Where(u => !u.Administrador && u.Ativo).Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina).OrderBy(u => u.Nome).ToListAsync() 
                                    : dbSet.Where(u => !u.Administrador && u.Ativo).OrderBy(u => u.Nome).ToListAsync()
                            );
            
            return usuarios;
        }

        public async Task Alterar(Usuario usuario)
        {
            var usuarioAntigo = await GetAsync(u => u.UsuarioId == usuario.UsuarioId);
            _context.Entry(usuarioAntigo).State = EntityState.Detached;

            usuario.Senha = !string.IsNullOrEmpty(usuario.Senha) ? usuario.Senha.Criptografar() : usuarioAntigo.Senha;
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UsuarioExiste(Expression<Func<Usuario, bool>> expressao) => await dbSet.AnyAsync(expressao);

        public async Task Incluir(Usuario usuario)
        {
            usuario.Senha = usuario.Senha.Criptografar();
            
            dbSet.Add(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
