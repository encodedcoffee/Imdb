using Application.Interfaces.Services;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) => _usuarioRepository = usuarioRepository;

        public async Task<Usuario> GetAsync(int id) => await _usuarioRepository.GetAsync(id);
    }
}
