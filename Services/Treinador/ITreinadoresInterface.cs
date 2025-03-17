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
    }
}
