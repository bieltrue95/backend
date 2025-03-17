using backend.Data;
using backend.Dto.Treinador;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services.Treinadores
{
    public class TreinadoresService : ITreinadoresInterface
    {
        private readonly PokemonAPIDbContext _context;

        public TreinadoresService(PokemonAPIDbContext context)
        {
            _context = context;
        }



        public async Task<ResponseModel<List<TreinadorModel>>> ListarTreinadores()
        {
            ResponseModel<List<TreinadorModel>> resposta = new ResponseModel<List<TreinadorModel>>();
            try
            {

                var listaTreinadores = await _context.Treinadores.ToListAsync();

                resposta.Dados = listaTreinadores;
                resposta.Mensagem = "Todos os treinadores foram listados !";

                return resposta;

            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<TreinadorModel>> BuscarTreinadorPorId(Guid treinadorId)
        {
            ResponseModel<TreinadorModel> resposta = new ResponseModel<TreinadorModel>();
            try
            {
                var treinador = await _context.Treinadores.FirstOrDefaultAsync(treinadorDb =>treinadorDb.Id == treinadorId);
                if(treinador == null)
                {
                    resposta.Mensagem = "Nenhum registro foi localizado!";
                    return resposta;
                }
                resposta.Dados = treinador;
                resposta.Mensagem = $"Treinador '{treinador.Nome}' localizado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<TreinadorModel>> BuscarTreinadorPorPokemonId(Guid pokemonId)
        {
            ResponseModel<TreinadorModel> resposta = new ResponseModel<TreinadorModel>();

            try
            {
                var pokemon = await _context.Pokemons
                    .Include(p => p.Treinador)
                    .FirstOrDefaultAsync(pokemonBanco => pokemonBanco.Id == pokemonId);
                if(pokemon == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado !";
                    return resposta;
                }
                resposta.Dados = pokemon.Treinador;
                resposta.Mensagem = $"Treinador '{pokemon.Treinador.Nome}' localizado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TreinadorModel>>> CriarTreinador(TreinadorCriacaoDto treinadorCriacaoDto)
        {
            ResponseModel<List<TreinadorModel>> resposta = new ResponseModel<List<TreinadorModel>>();

            try
            {
                var treinador = new TreinadorModel()
                {
                    Nome = treinadorCriacaoDto.Nome,
                    DataCadastro = treinadorCriacaoDto.DataCadastro
                };
                _context.Add(treinador);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Treinadores.ToListAsync();
                resposta.Mensagem = $"Treinador '{treinador.Nome}' criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TreinadorModel>>> EditarTreinador(TreinadorEdicaoDto treinadorEdicaoDto)
        {
            ResponseModel<List<TreinadorModel>> resposta = new ResponseModel<List<TreinadorModel>>();
            try
            {
                var treinador = await _context.Treinadores.FirstOrDefaultAsync(treinadorBanco =>treinadorBanco.Id == treinadorEdicaoDto.Id );
                if (treinador == null)
                {
                    resposta.Mensagem = "Treinador não foi localizado !";
                    return resposta;
                }
                treinador.Nome = treinadorEdicaoDto.Nome;
                treinador.DataCadastro = treinadorEdicaoDto.DataCadastro;


                _context.Update(treinador);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Treinadores.ToListAsync();
                resposta.Mensagem = $"Treinador '{treinador.Nome}' editado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }


        public async Task<ResponseModel<List<TreinadorModel>>> ExcluirTreinador(Guid treinadorId)
        {
            ResponseModel<List<TreinadorModel>> resposta = new ResponseModel<List<TreinadorModel>>();

            try
            {
                
                var treinador = await _context.Treinadores.FirstOrDefaultAsync(treinadorBanco => treinadorBanco.Id == treinadorId);

                
                if (treinador == null)
                {
                    resposta.Mensagem = "Treinador não foi localizado!";
                    return resposta;
                }

                
                _context.Treinadores.Remove(treinador);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Treinadores.ToListAsync();
                resposta.Mensagem = $"Treinador '{treinador.Nome}' excluído com sucesso!";

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
