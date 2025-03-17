using backend.Data;
using backend.Dto.Pokemon;
using backend.Dto.Treinador;
using backend.Models;
using backend.Services.Pokemon;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace backend.Services.Pokemons
{
    public class PokemonService : IPokemonInterface
    {
        private readonly PokemonAPIDbContext _context;
        public PokemonService(PokemonAPIDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<List<PokemonModel>>> BuscarPokemonPorTreinador(Guid treinadorId)
        {
            ResponseModel<List<PokemonModel>> resposta = new ResponseModel<List<PokemonModel>>();

            try
            {
                var pokemon = await _context.Pokemons
                    .Include(t => t.Treinador)
                    .Where(pokemonDb => pokemonDb.Treinador.Id == treinadorId)
                    .ToListAsync();
                if (pokemon == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado !";
                    return resposta;
                }
                resposta.Dados = pokemon;
                resposta.Mensagem = $"Pokémons localizados com sucesso: {string.Join(", ", pokemon.Select(p => p.Nome))}";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<PokemonModel>> BuscarPokemonPorId(Guid pokemonId)
        {
            ResponseModel<PokemonModel> resposta = new ResponseModel<PokemonModel>();
            try
            {
                var pokemon = await _context.Pokemons.FirstOrDefaultAsync(pokemonDb => pokemonDb.Id == pokemonId);
                if (pokemon == null)
                {
                    resposta.Mensagem = "Nenhum registro foi localizado!";
                    return resposta;
                }
                resposta.Dados = pokemon;
                resposta.Mensagem = $"Pokemon '{pokemon.Nome}' localizado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


        public async Task<ResponseModel<List<PokemonModel>>> CriarPokemon(PokemonCriacaoDto pokemonCriacaoDto)
        {
            ResponseModel<List<PokemonModel>> resposta = new ResponseModel<List<PokemonModel>>();

            try
            {
                var treinador = await _context.Treinadores.FirstOrDefaultAsync(treinadorDb => treinadorDb.Id == pokemonCriacaoDto.TreinadorId);
                if (treinador == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado !";
                    return resposta;
                }
                var pokemon = new PokemonModel()
                {
                    Nome = pokemonCriacaoDto.Nome,
                    Habilidade = pokemonCriacaoDto.Habilidade,
                    Tipo = pokemonCriacaoDto.Tipo,
                    Nivel = pokemonCriacaoDto.Nivel,
                    Treinador = treinador
                };
                _context.Add(pokemon);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Pokemons.Include(t => t.Treinador).ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PokemonModel>>> EditarPokemon(PokemonEdicaoDto pokemonEdicaoDto)
        {
            ResponseModel<List<PokemonModel>> resposta = new ResponseModel<List<PokemonModel>>();
            try
            { 
                var pokemon = await _context.Pokemons
                    .Include(t => t.Treinador)
                    .FirstOrDefaultAsync(pokemonDb => pokemonDb.Id == pokemonEdicaoDto.Id);
                var treinador = await _context.Treinadores.FirstOrDefaultAsync(treinadorDb => treinadorDb.Id == pokemonEdicaoDto.Id);
                if (pokemon == null)
                {
                    resposta.Mensagem = "Nenhum registro foi localizado!";
                    return resposta;
                }
                pokemon.Nome = pokemonEdicaoDto.Nome;
                pokemon.Habilidade = pokemonEdicaoDto.Habilidade;
                pokemon.Tipo = pokemonEdicaoDto.Tipo;
                pokemon.Nivel = pokemonEdicaoDto.Nivel;

                _context.Update(pokemon);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pokemons.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<List<PokemonModel>>> ExcluirPokemon(Guid pokemonId)
        {
            ResponseModel<List<PokemonModel>> resposta = new ResponseModel<List<PokemonModel>>();

            try
            {

                var pokemon = await _context.Pokemons
                    .FirstOrDefaultAsync(PpokemonDb => PpokemonDb.Id == pokemonId);


                if (pokemon == null)
                {
                    resposta.Mensagem = "Treinador não foi localizado!";
                    return resposta;
                }


                _context.Pokemons.Remove(pokemon);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pokemons.ToListAsync();
                resposta.Mensagem = $"Pokemon '{pokemon.Nome}' excluído com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PokemonModel>>> ListarPokemon()
        {
            ResponseModel<List<PokemonModel>> resposta = new ResponseModel<List<PokemonModel>>();
            try
            {

                var listaPokemons = await _context.Pokemons.ToListAsync();

                resposta.Dados = listaPokemons;
                resposta.Mensagem = "Todos os pokemons foram listados !";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

    }
 }

        
