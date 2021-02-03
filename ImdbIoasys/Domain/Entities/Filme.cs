using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Filme
    {
        public int FilmeId { get; set; }
        public string Nome { get; set; }
        public string Diretor { get; set; }
        public string Atores { get; set; }
        public string Genero { get; set; }
        public ICollection<Voto> Votos { get; set; }
        public double Media => Votos?.Select(v => v.Classificacao).Average() ?? 0;
    }
}
