using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> GetAsync(Expression<Func<Usuario, bool>> expressao);
        Task<IEnumerable<Usuario>> ListAsync(int pagina);

        Task Alterar(Usuario usuario);
        Task<bool> UsuarioExiste(Expression<Func<Usuario, bool>> expressao);
        Task Incluir(Usuario usuario);
    }
}
