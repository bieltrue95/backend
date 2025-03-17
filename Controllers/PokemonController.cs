using backend.Dto.Pokemon;
using backend.Models;
using backend.Services.Pokemon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonInterface _pokemonInterface;
        public PokemonController(IPokemonInterface pokemonInterface)
        {
            _pokemonInterface = pokemonInterface;
        }

        [HttpGet("ListarPokemons")]
        public async Task<ActionResult<ResponseModel<List<PokemonModel>>>> ListarPokemon()
        {
            var listaPokemons = await _pokemonInterface.ListarPokemon();
            return Ok(listaPokemons);
        }

        [HttpGet("BuscarPokemonPorId/{pokemonId}")]
        public async Task<ActionResult<ResponseModel<PokemonModel>>> BuscarPokemonPorId(Guid pokemonId)
        {
            var pokemon = await _pokemonInterface.BuscarPokemonPorId(pokemonId);
            return Ok(pokemon);
        }
        [HttpGet("BuscarPokemonPorTreinador/{treinadorId}")]
        public async Task<ActionResult<ResponseModel<PokemonModel>>> BuscarPokemonPorTreinador(Guid treinadorId)
        {
            var pokemon = await _pokemonInterface.BuscarPokemonPorTreinador(treinadorId);
            return Ok(pokemon);
        }
        [HttpPost("CriarPokemon")]
        public async Task<ActionResult<ResponseModel<List<PokemonModel>>>> CriarPokemon(PokemonCriacaoDto pokemonCriacao)
        {
            var pokemon = await _pokemonInterface.CriarPokemon(pokemonCriacao);
            return Ok(pokemon);
        }
        [HttpPut("EditarPokemon")]
        public async Task<ActionResult<ResponseModel<List<PokemonModel>>>> EditarPokemon(PokemonEdicaoDto pokemonEdicao)
        {
            var pokemon = await _pokemonInterface.EditarPokemon(pokemonEdicao);
            return Ok(pokemon);
        }
        [HttpDelete("ExcluirPokemon")]
        public async Task<ActionResult<ResponseModel<List<PokemonModel>>>> ExcluirPokemon(Guid pokemonId)
        {
            var pokemon = await _pokemonInterface.ExcluirPokemon(pokemonId);
            return Ok(pokemon);
        }

    }
}
