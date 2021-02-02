namespace ImdbIoasys.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public bool Administrador { get; set; }
    }
}
