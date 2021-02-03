using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Filme> dbSet;

        public FilmeRepository(DbContext dbContext)
        {
            _context = dbContext;
            dbSet = _context.Set<Filme>();
        }

        public async Task<Filme> GetAsync(int id)
        {
            var dbSetFilme = dbSet.Include(f => f.Votos);
            var filme = await dbSetFilme.FirstAsync(f => f.FilmeId == id);

            return filme;
        }

        public async Task<IEnumerable<Filme>> ListAsync(int pagina, Filme filme)
        {
            var filmes = dbSet.Where(f => true);

            if (!string.IsNullOrEmpty(filme?.Diretor))
                filmes = filmes.Where(f => f.Diretor.Contains(filme.Diretor));

            if(!string.IsNullOrEmpty(filme?.Nome))
                filmes = filmes.Where(f => f.Nome.Contains(filme.Nome));

            if (!string.IsNullOrEmpty(filme?.Genero))
                filmes = filmes.Where(f => f.Genero.Contains(filme.Genero));

            if (!string.IsNullOrEmpty(filme?.Atores))
                filmes = filmes.Where(f => f.Atores.Contains(filme.Atores));

            filmes = filmes.OrderByDescending(f => f.Votos.Count).ThenBy(f => f.Nome);
            filmes = filmes.AsNoTracking().Include(f => f.Votos);

            var filmesFiltrados = await (pagina > 0 ? filmes.Skip((pagina - 1) * 10).Take(10).ToListAsync() : filmes.ToListAsync());
            return filmesFiltrados;
        }

        public async Task Alterar(Filme filme)
        {
            _context.Entry(filme).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FilmeExiste(int filmeId) => await dbSet.AnyAsync(filme => filme.FilmeId == filmeId);

        public async Task Incluir(Filme filme)
        {
            dbSet.Add(filme);
            await _context.SaveChangesAsync();
        }

        public async Task Votar(Voto voto)
        {
            voto.Usuario = await _context.Set<Usuario>().FirstOrDefaultAsync(u => u.UsuarioId == voto.UsuarioId);
            voto.Filme = await _context.Set<Filme>().FirstOrDefaultAsync(f => f.FilmeId == voto.FilmeId);

            if (voto.VotoId > 0)
                _context.Entry(voto).State = EntityState.Modified;
            else
                _context.Set<Voto>().Add(voto);

            await _context.SaveChangesAsync();
        }
    }
}
