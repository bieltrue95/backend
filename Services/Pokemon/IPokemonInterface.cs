using backend.Dto.Pokemon;
using backend.Models;
using backend.Services.Pokemons;

namespace backend.Services.Pokemon
{
    public interface IPokemonInterface
    {
        Task<ResponseModel<PokemonModel>> BuscarPokemonPorId(Guid pokemonId);
        Task<ResponseModel<List<PokemonModel>>> BuscarPokemonPorTreinador(Guid treinadorId);
        Task<ResponseModel<List<PokemonModel>>> CriarPokemon(PokemonCriacaoDto pokemonCriacaoDto);
        Task<ResponseModel<List<PokemonModel>>> EditarPokemon(PokemonEdicaoDto pokemonEdicaoDto);
        Task<ResponseModel<List<PokemonModel>>> ExcluirPokemon(Guid pokemonId);
        Task<ResponseModel<List<PokemonModel>>> ListarPokemon();
    }
}
