using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IFilmeService
    {
        Task<Filme> GetAsync(int id);
        Task<IEnumerable<Filme>> ListAsync();
        Task Alterar(Filme filme);
        Task<bool> FilmeExiste(int filmeId);
        Task Incluir(Filme filme);
    }
}
