using backend.Dto.Treinador;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services.Treinadores
{
    public interface ITreinadoresInterface
    {
        Task<ResponseModel<List<TreinadorModel>>> ListarTreinadores();
        Task<ResponseModel<TreinadorModel>> BuscarTreinadorPorId(Guid treinadorId);
        Task<ResponseModel<TreinadorModel>> BuscarTreinadorPorPokemonId(Guid pokemonId);
        Task<ResponseModel<List<TreinadorModel>>> CriarTreinador(TreinadorCriacaoDto treinadorCriacaoDto);
        Task<ResponseModel<List<TreinadorModel>>> EditarTreinador(TreinadorEdicaoDto treinadorEdicaoDto);
        Task<ResponseModel<List<TreinadorModel>>> ExcluirTreinador(Guid treinadorId);

    }
}
