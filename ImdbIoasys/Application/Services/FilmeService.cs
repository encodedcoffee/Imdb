using Application.Interfaces.Services;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository) => _filmeRepository = filmeRepository;

        public async Task Alterar(Filme filme) => await _filmeRepository.Alterar(filme);
        public async Task<bool> FilmeExiste(int filmeId) => await _filmeRepository.FilmeExiste(filmeId);
        public async Task<Filme> GetAsync(int id) => await _filmeRepository.GetAsync(id);
        public async Task Incluir(Filme filme) => await _filmeRepository.Incluir(filme);
        public async Task<IEnumerable<Filme>> ListAsync(int pagina, Filme filme) => await _filmeRepository.ListAsync(pagina, filme);
        public async Task Votar(Voto voto) => await _filmeRepository.Votar(voto);
    }
}
