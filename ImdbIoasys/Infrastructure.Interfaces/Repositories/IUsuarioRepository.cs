using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetAsync(Expression<Func<Usuario, bool>> expressao);
        Task<IEnumerable<Usuario>> ListAsync(int pagina);

        Task Alterar(Usuario usuario);
        Task<bool> UsuarioExiste(Expression<Func<Usuario, bool>> expressao);
        Task Incluir(Usuario usuario);
    }
}
