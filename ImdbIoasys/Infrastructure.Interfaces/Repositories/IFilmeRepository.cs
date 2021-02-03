using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        Task<Filme> GetAsync(int id);
        Task<IEnumerable<Filme>> ListAsync();
        Task Alterar(Filme filme);
        Task<bool> FilmeExiste(int filmeId);
        Task Incluir(Filme filme);
        Task Votar(Voto voto);
    }
}
