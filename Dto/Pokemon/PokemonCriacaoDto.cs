using backend.Domain.Pokemons.Enums;

namespace backend.Dto.Pokemon
{
    public class PokemonCriacaoDto
    {
        public string Nome { get; set; }
        public string Habilidade { get; set; }
        public TipoPokemon Tipo { get; set; }
        public int Nivel { get; set; }
        public Guid TreinadorId { get; set; }

    }
}
