using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Voto
    {
        public int VotoId { get; set; }
        public int Classificacao { get; set; }
        public int FilmeId { get; set; }
        
        [JsonIgnore]
        public Filme Filme { get; set; }
        public int UsuarioId { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}
