﻿using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<Filme> GetAsync(int id) => await dbSet.FindAsync(id);

        public async Task<IEnumerable<Filme>> ListAsync() => await dbSet.ToListAsync();

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