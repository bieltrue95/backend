using backend.Data;
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
                resposta.Mensagem = "Treinador localizado com sucesso!";
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
