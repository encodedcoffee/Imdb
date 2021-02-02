using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetAsync(int id);
        Task<IEnumerable<Usuario>> ListAsync();

        Task Alterar(Usuario usuario);
        Task<bool> UsuarioExiste(int usuarioId);
        Task Incluir(Usuario usuario);
    }
}
