using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> GetAsync(int id);
        Task<IEnumerable<Usuario>> ListAsync(int pagina);

        Task Alterar(Usuario usuario);
        Task<bool> UsuarioExiste(int usuarioId);
        Task Incluir(Usuario usuario);
    }
}
