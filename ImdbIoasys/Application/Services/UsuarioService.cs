using Application.Interfaces.Services;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) => _usuarioRepository = usuarioRepository;

        public async Task Alterar(Usuario usuario) => await _usuarioRepository.Alterar(usuario);

        public async Task<Usuario> GetAsync(Expression<Func<Usuario, bool>> expressao) => await _usuarioRepository.GetAsync(expressao);

        public async Task Incluir(Usuario usuario)
        {
            await _usuarioRepository.Incluir(usuario);
        }

        public async Task<IEnumerable<Usuario>> ListAsync(int pagina) => await _usuarioRepository.ListAsync(pagina);

        public async Task<bool> UsuarioExiste(Expression<Func<Usuario, bool>> expressao) => await _usuarioRepository.UsuarioExiste(expressao);
    }
}
