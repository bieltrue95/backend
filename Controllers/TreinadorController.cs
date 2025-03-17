using backend.Dto.Treinador;
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
        [HttpGet("BuscarTreinadorPorPokemonId/{pokemonId}")]
        public async Task<ActionResult<ResponseModel<TreinadorModel>>> BuscarTreinadorPorPokemonId(Guid pokemonId)
        {
            var treinador = await _treinadoresInterface.BuscarTreinadorPorPokemonId(pokemonId);
            return Ok(treinador);
        }        
        [HttpPost("CriarTreinador")]
        public async Task<ActionResult<ResponseModel<List<TreinadorModel>>>> CriarTreinador(TreinadorCriacaoDto treinadorCriacaoDto)
        {
            var treinador = await _treinadoresInterface.CriarTreinador(treinadorCriacaoDto);
            return Ok(treinador);
        }            
        [HttpPut("EditarTreinador")]
        public async Task<ActionResult<ResponseModel<List<TreinadorModel>>>> EditarTreinador(TreinadorEdicaoDto treinadorEdicao)
        {
            var treinador = await _treinadoresInterface.EditarTreinador(treinadorEdicao);
            return Ok(treinador);
        }        
        [HttpDelete("ExcluirTreinador")]
        public async Task<ActionResult<ResponseModel<List<TreinadorModel>>>> ExcluirTreinador(Guid treinadorId)
        {
            var treinador = await _treinadoresInterface.ExcluirTreinador(treinadorId);
            return Ok(treinador);
        }

    }
}
