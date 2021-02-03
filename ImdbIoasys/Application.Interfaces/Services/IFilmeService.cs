using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IFilmeService
    {
        Task<Filme> GetAsync(int id);
        Task<IEnumerable<Filme>> ListAsync(int pagina, Filme filme);
        Task Alterar(Filme filme);
        Task<bool> FilmeExiste(int filmeId);
        Task Incluir(Filme filme);
        Task Votar(Voto voto);
    }
}
