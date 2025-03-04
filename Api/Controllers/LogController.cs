using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService) => _logService = logService;

        [HttpGet("leilao/{leilaoId}/propriedade/{entidadeId}")]
        public async Task<IActionResult> GetLanceLog(int leilaoId, int entidadeId)
        {
            var log = await _logService.GetLogLances(leilaoId, entidadeId);
            if (log == null) return NotFound("Nenhum log encontrado para os parâmetros fornecidos.");

            return Ok(log);
        }
    }
}
