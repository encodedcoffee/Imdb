using System.Collections.Generic;

namespace Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public bool Administrador { get; set; }
        public ICollection<Voto> Votos { get; set; }
    }
}
