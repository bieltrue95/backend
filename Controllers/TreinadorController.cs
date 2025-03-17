using backend.Models;
using backend.Services.Treinadores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinadorController : ControllerBase
    {
        private readonly ITreinadoresInterface _treinadoresInterface;
        public TreinadorController(ITreinadoresInterface treinadorInterface)
        {
            _treinadoresInterface = treinadorInterface;
        }

        [HttpGet("ListarTreinadores")]
        public async Task<ActionResult<ResponseModel<List<TreinadorModel>>>> ListarTreinadores()
        {
            var listaTreinadores = await _treinadoresInterface.ListarTreinadores();
            return Ok(listaTreinadores);
        }

        [HttpGet("BuscarTreinadorPorId/{treinadorId}")]
        public async Task<ActionResult<ResponseModel<TreinadorModel>>> BuscarTreinadorPorId(Guid treinadorId)
        {
            var treinador = await _treinadoresInterface.BuscarTreinadorPorId(treinadorId);
            return Ok(treinador);
        }

    }
}
