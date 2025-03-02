using Application.DTOs.Logs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly LogService _logService;

        public LogController(LogService logService)
        {
            _logService = logService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddLog([FromBody] AddLogDto novoLog)
        {
            var resultado = await _logService.AddLog(novoLog);
            return Ok(resultado);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllLogs()
        {
            var logs = await _logService.GetAllLogs();
            return Ok(logs);
        }

        [HttpGet("filtrar-por-usuario/{usuarioId}")]
        public async Task<IActionResult> GetLogsByUsuario(int usuarioId)
        {
            var logs = await _logService.GetLogsByUsuario(usuarioId);
            return Ok(logs);
        }

        [HttpGet("filtrar-por-entidade/{entidade}")]
        public async Task<IActionResult> GetLogsByEntidade(string entidade)
        {
            var logs = await _logService.GetLogsByEntidade(entidade);
            return Ok(logs);
        }

        [HttpGet("filtrar-por-acao/{acao}")]
        public async Task<IActionResult> GetLogsByAcao(string acao)
        {
            var logs = await _logService.GetLogsByAcao(acao);
            return Ok(logs);
        }
    }
}