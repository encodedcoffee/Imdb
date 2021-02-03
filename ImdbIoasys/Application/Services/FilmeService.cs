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

        public Task Alterar(Filme filme) => _filmeRepository.Alterar(filme);

        public Task<bool> FilmeExiste(int filmeId) => _filmeRepository.FilmeExiste(filmeId);

        public Task<Filme> GetAsync(int id) => _filmeRepository.GetAsync(id);

        public Task Incluir(Filme filme) => _filmeRepository.Incluir(filme);

        public Task<IEnumerable<Filme>> ListAsync() => _filmeRepository.ListAsync();
    }
}
