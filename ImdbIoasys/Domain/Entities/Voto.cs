namespace Domain.Entities
{
    public class Voto
    {
        public int VotoId { get; set; }
        public int Classificacao { get; set; }
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
