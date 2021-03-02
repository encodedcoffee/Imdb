using System.Collections.Generic;

namespace Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public int RegraAcesso { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
        public bool Administrador => RegraAcesso == ObterConstanteRegraAdministrador();
        public ICollection<Voto> Votos { get; set; }
        private int ObterConstanteRegraAdministrador() => 1;
    }
}
