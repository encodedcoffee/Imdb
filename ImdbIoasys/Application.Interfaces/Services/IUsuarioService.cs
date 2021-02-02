using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> GetAsync(int id);
    }
}
