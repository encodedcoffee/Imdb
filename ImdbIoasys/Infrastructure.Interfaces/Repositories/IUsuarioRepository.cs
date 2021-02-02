using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetAsync(int id);
    }
}
